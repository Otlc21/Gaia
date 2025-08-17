using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeleton
{
    public class Ticket_ProcessEDoc
    {
        public string _xml = $@"
<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:sec=""http://xml.amadeus.com/2010/06/Security_v1"" xmlns:link=""http://wsdl.amadeus.com/2010/06/ws/Link_v1"" xmlns:ses=""http://xml.amadeus.com/2010/06/Session_v3"" xmlns:typ=""http://xml.amadeus.com/2010/06/Types_v1"" xmlns:iat=""http://www.iata.org/IATA/2007/00/IATA2010.1"" xmlns:app=""http://xml.amadeus.com/2010/06/AppMdw_CommonTypes_v3"">
   <soapenv:Header xmlns:add=""http://www.w3.org/2005/08/addressing"">
	<add:MessageID>${{#TestCase#MessageId}}</add:MessageID>
	<add:Action>${{=request.operation.action}}</add:Action>
	<add:To>${{#Endpoint}}/${{#Project#WSAP}}</add:To>
	<awsse:Session TransactionStatusCode=""InSeries"" xmlns:awsse=""http://xml.amadeus.com/2010/06/Session_v3"">
		<awsse:SessionId>${{#TestCase#SessionId}}</awsse:SessionId>
		<awsse:SequenceNumber>${{=${{#TestCase#SequenceNumber}}+4}}</awsse:SequenceNumber>
		<awsse:SecurityToken>${{#TestCase#SecurityToken}}</awsse:SecurityToken>
	</awsse:Session>
</soapenv:Header>
   <soapenv:Body>
      <Ticket_ProcessEDoc>
         <msgActionDetails>
            <messageFunctionDetails>
               <messageFunction>131</messageFunction>
            </messageFunctionDetails>
         </msgActionDetails>
         <infoGroup>
            <docInfo>
               <documentDetails>
                  <number>${{Transfered Properties#ETK_number_01}}</number>
               </documentDetails>
            </docInfo>
         </infoGroup>
         <infoGroup>
            <docInfo>
               <documentDetails>
                  <number>${{Transfered Properties#ETK_number_02}}</number>
               </documentDetails>
            </docInfo>
         </infoGroup>
      </Ticket_ProcessEDoc>
   </soapenv:Body>
</soapenv:Envelope>
";
        public string _service = "TATREQ_23_1_1A";

        public string GetXML()
        {
            return _xml;
        }
        
        public string GetService()
        {
            return _service;
        }
    }
}
