using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeleton
{
    public class Air_SellFromRecommendation
    {
        public string _xml = $@"
<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:sec=""http://xml.amadeus.com/2010/06/Security_v1"" xmlns:typ=""http://xml.amadeus.com/2010/06/Types_v1"" xmlns:iat=""http://www.iata.org/IATA/2007/00/IATA2010.1"" xmlns:app=""http://xml.amadeus.com/2010/06/AppMdw_CommonTypes_v3"" xmlns:link=""http://wsdl.amadeus.com/2010/06/ws/Link_v1"" xmlns:ses=""http://xml.amadeus.com/2010/06/Session_v3"">
   <soapenv:Header xmlns:add=""http://www.w3.org/2005/08/addressing"">
	<add:MessageID>${{#TestCase#MessageId}}</add:MessageID>
	<add:Action>${{=request.operation.action}}</add:Action>
	<add:To>${{#Endpoint}}/${{#Project#WSAP}}</add:To>
	<oas:Security xmlns:oas=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd"" xmlns:oas1=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd"">
		<oas:UsernameToken oas1:Id=""UsernameToken-1"">
			<oas:Username>${{#Project#UserId}}</oas:Username>
			<oas:Nonce EncodingType=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Base64Binary"">${{#TestCase#Nonce}}</oas:Nonce>
			<oas:Password Type=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordDigest"">${{#TestCase#Password}}</oas:Password>
			<oas1:Created>${{#TestCase#Created}}</oas1:Created>
		</oas:UsernameToken>
	</oas:Security>
	<AMA_SecurityHostedUser xmlns=""http://xml.amadeus.com/2010/06/Security_v1"">
		<UserID AgentDutyCode=""SU"" RequestorType=""U"" PseudoCityCode=""${{#Project#OfficeId}}"" POS_Type=""1""/>
	</AMA_SecurityHostedUser>
	<awsse:Session TransactionStatusCode=""Start"" xmlns:awsse=""http://xml.amadeus.com/2010/06/Session_v3""/>
</soapenv:Header>
   <soapenv:Body>
      <Air_SellFromRecommendation>
         <messageActionDetails>
            <messageFunctionDetails>
               <messageFunction>183</messageFunction>
               <additionalMessageFunction>M1</additionalMessageFunction>
            </messageFunctionDetails>
         </messageActionDetails>
         <itineraryDetails>
            <originDestinationDetails>
               <origin>${{Transfered Properties#S01_L01_boarding_airport}}</origin>
               <destination>${{Transfered Properties#S01_L01_off_airport}}</destination>
            </originDestinationDetails>
            <message>
               <messageFunctionDetails>
                  <messageFunction>183</messageFunction>
               </messageFunctionDetails>
            </message>
            <segmentInformation>
               <travelProductInformation>
                  <flightDate>
                     <departureDate>${{Transfered Properties#S01_L01_departure_date}}</departureDate>
                  </flightDate>
                  <boardPointDetails>
                     <trueLocationId>${{Transfered Properties#S01_L01_boarding_airport}}</trueLocationId>
                  </boardPointDetails>
                  <offpointDetails>
                     <trueLocationId>${{Transfered Properties#S01_L01_off_airport}}</trueLocationId>
                  </offpointDetails>
                  <companyDetails>
                     <marketingCompany>${{Transfered Properties#S01_L01_marketing_company}}</marketingCompany>
                  </companyDetails>
                  <flightIdentification>
                     <flightNumber>${{Transfered Properties#S01_L01_flight_number}}</flightNumber>
                     <bookingClass>${{Transfered Properties#S01_L01_booking_class}}</bookingClass>
                  </flightIdentification>
               </travelProductInformation>
               <relatedproductInformation>
                  <quantity>2</quantity>
                  <statusCode>NN</statusCode>
               </relatedproductInformation>
            </segmentInformation>
         </itineraryDetails>
         <itineraryDetails>
            <originDestinationDetails>
               <origin>${{Transfered Properties#S02_L01_boarding_airport}}</origin>
               <destination>${{Transfered Properties#S02_L01_off_airport}}</destination>
            </originDestinationDetails>
            <message>
               <messageFunctionDetails>
                  <messageFunction>183</messageFunction>
               </messageFunctionDetails>
            </message>
            <segmentInformation>
               <travelProductInformation>
                  <flightDate>
                     <departureDate>${{Transfered Properties#S02_L01_departure_date}}</departureDate>
                  </flightDate>
                  <boardPointDetails>
                     <trueLocationId>${{Transfered Properties#S02_L01_boarding_airport}}</trueLocationId>
                  </boardPointDetails>
                  <offpointDetails>
                     <trueLocationId>${{Transfered Properties#S02_L01_off_airport}}</trueLocationId>
                  </offpointDetails>
                  <companyDetails>
                     <marketingCompany>${{Transfered Properties#S02_L01_marketing_company}}</marketingCompany>
                  </companyDetails>
                  <flightIdentification>
                     <flightNumber>${{Transfered Properties#S02_L01_flight_number}}</flightNumber>
                     <bookingClass>${{Transfered Properties#S02_L01_booking_class}}</bookingClass>
                  </flightIdentification>
               </travelProductInformation>
               <relatedproductInformation>
                  <quantity>2</quantity>
                  <statusCode>NN</statusCode>
               </relatedproductInformation>
            </segmentInformation>
         </itineraryDetails>
      </Air_SellFromRecommendation>
   </soapenv:Body>
</soapenv:Envelope>
";
        public string _service = "ITAREQ_05_2_IA";
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
