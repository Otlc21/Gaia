using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeleton
{
    public class Fare_MasterPricerTravelBoardSearch
    {
		static string _messageId;
		static string _to;
		static string _username;
		static string _nonce;
		static string _password;
		static string _created;
        static string _pseudoCityCode;
        static string _service = "FMPTBQ_24_1_1A";

        public Fare_MasterPricerTravelBoardSearch(string messageId,
			string to, string username, string nonce, string password,
			string created, string pseudoCityCode)
        {
            _messageId = messageId;
			_to = to;
			_username = username;
			_nonce = nonce;
			_password = password;
			_created = created;
			_pseudoCityCode = pseudoCityCode;
        }

        public static string _xml = $@"
<soap:Envelope
	xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/""
	xmlns:add=""http://www.w3.org/2005/08/addressing"">
	<soap:Header>
		<add:MessageID>{{0}}</add:MessageID>
		<add:Action>http://webservices.amadeus.com/{_service}</add:Action>
		<add:To>https://noded1.test.webservices.amadeus.com/{{1}}</add:To>
		<link:TransactionFlowLink
			xmlns:link=""http://wsdl.amadeus.com/2010/06/ws/Link_v1""/>
			<oas:Security
				xmlns:oas=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd"">
				<oas:UsernameToken
					xmlns:oas1=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd"" oas1:Id=""UsernameToken-1"">
					<oas:Username>{{2}}</oas:Username>
					<oas:Nonce EncodingType=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Base64Binary"">{{3}}</oas:Nonce>
					<oas:Password Type=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordDigest"">{{4}}</oas:Password>
					<oas1:Created>{{5}}</oas1:Created>
				</oas:UsernameToken>
			</oas:Security>
			<AMA_SecurityHostedUser
				xmlns=""http://xml.amadeus.com/2010/06/Security_v1"">
				<UserID POS_Type=""1"" PseudoCityCode=""{{6}}"" RequestorType=""U""/>
			</AMA_SecurityHostedUser>
		</soap:Header>
		<soap:Body>
			<Fare_MasterPricerTravelBoardSearch>
				<numberOfUnit>
					<unitNumberDetail>
						<numberOfUnits>2</numberOfUnits>
						<typeOfUnit>RC</typeOfUnit>
					</unitNumberDetail>
					<unitNumberDetail>
						<numberOfUnits>2</numberOfUnits>
						<typeOfUnit>PX</typeOfUnit>
					</unitNumberDetail>
				</numberOfUnit>
				<paxReference>
					<ptc>ADT</ptc>
					<traveller>
						<ref>1</ref>
					</traveller>
				</paxReference>
				<paxReference>
					<ptc>CHD</ptc>
					<traveller>
						<ref>2</ref>
					</traveller>
				</paxReference>
				<fareOptions>
					<pricingTickInfo>
						<pricingTicketing>
							<priceType>ET</priceType>
							<priceType>RP</priceType>
							<priceType>RU</priceType>
							<priceType>TAC</priceType>
						</pricingTicketing>
					</pricingTickInfo>
				</fareOptions>
				<travelFlightInfo />
				<itinerary>
					<requestedSegmentRef>
						<segRef>1</segRef>
					</requestedSegmentRef>
					<departureLocalization>
						<departurePoint>
							<locationId>GRU</locationId>
						</departurePoint>
					</departureLocalization>
					<arrivalLocalization>
						<arrivalPointDetails>
							<locationId>MIA</locationId>
						</arrivalPointDetails>
					</arrivalLocalization>
					<timeDetails>
						<firstDateTimeDetail>
							<date>041025</date>
						</firstDateTimeDetail>
					</timeDetails>
				</itinerary>
				<itinerary>
					<requestedSegmentRef>
						<segRef>2</segRef>
					</requestedSegmentRef>
					<departureLocalization>
						<departurePoint>
							<locationId>MIA</locationId>
						</departurePoint>
					</departureLocalization>
					<arrivalLocalization>
						<arrivalPointDetails>
							<locationId>GRU</locationId>
						</arrivalPointDetails>
					</arrivalLocalization>
					<timeDetails>
						<firstDateTimeDetail>
							<date>241025</date>
						</firstDateTimeDetail>
					</timeDetails>
				</itinerary>
			</Fare_MasterPricerTravelBoardSearch>
		</soap:Body>
	</soap:Envelope>
";

        public string GetXML()
        {
            return string.Format(_xml, _messageId, _to, _username,
				_nonce, _password, _created, _pseudoCityCode);
        }

        public string GetService()
        {
            return _service;
        }

    }
}
