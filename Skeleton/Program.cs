using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace Skeleton
{
    internal class Program
    {
        static string _wsap = "1ASIWREART6";
        static string _officeId = "ORL1S2403";
        static string _userId = "WSRT6REA";
        static string _passwordClear = "T&bm5wjNAChU";

        static string _action = "http://webservices.amadeus.com/";
        static string _url = "https://noded1.test.webservices.amadeus.com/";

        static void Main(string[] args)
        {
            int PasswordLength = _passwordClear.Length;

            var nonceBytes = Encoding.UTF8.GetBytes(Guid.NewGuid()
                .ToString()
                .Replace("-", "")
                .Substring(0, 8));
            string nonce = Convert.ToBase64String(nonceBytes);

            string messageId = Guid.NewGuid().ToString();

            string timeStamp = string.Empty;
            DateTime dateTime = DateTime.UtcNow;
            timeStamp = dateTime.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");

            string passwordDigest = string.Empty;
            passwordDigest = PasswordDigest(nonce, _passwordClear, timeStamp);

            var service = new Fare_MasterPricerTravelBoardSearch(messageId,
                _wsap, _userId, nonce, passwordDigest, timeStamp, _officeId);
            string XMLVerb = service.GetXML();

            string reply = CallAmadeus(XMLVerb, service.GetService(), _wsap);
            Console.WriteLine(reply);
            Console.ReadKey();
        }

        private static string PasswordDigest(string nonce, string password, string timeStamp)
        {
            byte[] decodedNonce = Convert.FromBase64String(nonce);
            byte[] bytePasswd = Encoding.UTF8.GetBytes(password);

            SHA1 sha1Passwd = SHA1Managed.Create();
            byte[] hashPasswd = sha1Passwd.ComputeHash(bytePasswd);
            SHA1 sha1Salted = SHA1Managed.Create();
            byte[] byteTimeStamp = Encoding.UTF8.GetBytes(timeStamp);

            sha1Salted.TransformBlock(decodedNonce, 0, decodedNonce.Length, decodedNonce, 0);
            sha1Salted.TransformBlock(byteTimeStamp, 0, byteTimeStamp.Length, byteTimeStamp, 0);
            sha1Salted.TransformFinalBlock(hashPasswd, 0, hashPasswd.Length);
            
            byte[] saltedPasswd = sha1Salted.Hash;
            return Convert.ToBase64String(saltedPasswd);
        }

        public static string CallAmadeus(string message, string verb, string wsap)
        {
            string reply = string.Empty;

            try
            {
                var url = _url + wsap;
                var action = _action + verb;

                byte[] byteArray = Encoding.UTF8.GetBytes(message);
                WebRequest webRequest = WebRequest.Create(url);
                HttpWebRequest request = (HttpWebRequest)webRequest;
                request.Credentials = CredentialCache.DefaultCredentials;
                request.ContentLength = byteArray.Length;
                request.ContentType = "text/xml;charset=\"utf-8\"";
                request.Method = "POST";
                request.Accept = "text/xml";
                request.Headers.Add("SOAPAction", action);
                request.UserAgent = "Realize Travel AIR";

                Stream requestStream = request.GetRequestStream();
                requestStream.Write(byteArray, 0, byteArray.Length);
                requestStream.Close();

                HttpWebResponse wr = (HttpWebResponse)request.GetResponse();
                StreamReader srd = new StreamReader(wr.GetResponseStream());
                reply = srd.ReadToEnd();
            }
            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    using (StreamReader srd = new StreamReader(ex.Response.GetResponseStream()))
                    {
                        reply = srd.ReadToEnd();
                    }
                }
            }

            XDocument doc = XDocument.Parse(reply);
            return doc.ToString();
        }


    }
}
