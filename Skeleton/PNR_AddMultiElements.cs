using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeleton
{
    public class PNR_AddMultiElements
    {
        public string _xml = $@"
<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:sec=""http://xml.amadeus.com/2010/06/Security_v1"" xmlns:typ=""http://xml.amadeus.com/2010/06/Types_v1"" xmlns:iat=""http://www.iata.org/IATA/2007/00/IATA2010.1"" xmlns:app=""http://xml.amadeus.com/2010/06/AppMdw_CommonTypes_v3"" xmlns:link=""http://wsdl.amadeus.com/2010/06/ws/Link_v1"" xmlns:ses=""http://xml.amadeus.com/2010/06/Session_v3"">
   <soapenv:Header xmlns:add=""http://www.w3.org/2005/08/addressing"">
	<add:MessageID>${{#TestCase#MessageId}}</add:MessageID>
	<add:Action>${{=request.operation.action}}</add:Action>
	<add:To>${{#Endpoint}}/${{#Project#WSAP}}</add:To>
	<awsse:Session TransactionStatusCode=""InSeries"" xmlns:awsse=""http://xml.amadeus.com/2010/06/Session_v3"">
		<awsse:SessionId>${{#TestCase#SessionId}}</awsse:SessionId>
		<awsse:SequenceNumber>${{=${{#TestCase#SequenceNumber}}+1}}</awsse:SequenceNumber>
		<awsse:SecurityToken>${{#TestCase#SecurityToken}}</awsse:SecurityToken>
	</awsse:Session>
</soapenv:Header>
   <soapenv:Body>
    <PNR_AddMultiElements>
         <pnrActions>
            <optionCode>0</optionCode>
         </pnrActions>
       <travellerInfo>
            <elementManagementPassenger>
               <reference>
                  <qualifier>PR</qualifier>
                  <number>1</number>
               </reference>
               <segmentName>NM</segmentName>
            </elementManagementPassenger>
            <passengerData>
               <travellerInformation>
                  <traveller>
                     <surname>Doe</surname>
                     <quantity>1</quantity>
                  </traveller>
                  <passenger>
                     <firstName>John</firstName>
                     <type>ADT</type>
                  </passenger>
               </travellerInformation>
               <dateOfBirth>
                  <dateAndTimeDetails>
                     <date>01JAN80</date>
                  </dateAndTimeDetails>
               </dateOfBirth>
            </passengerData>
         </travellerInfo>
         <travellerInfo>
            <elementManagementPassenger>
               <reference>
                  <qualifier>PR</qualifier>
                  <number>2</number>
               </reference>
               <segmentName>NM</segmentName>
            </elementManagementPassenger>
            <passengerData>
               <travellerInformation>
                  <traveller>
                     <surname>Roe</surname>
                     <quantity>1</quantity>
                  </traveller>
                  <passenger>
                     <firstName>Richard</firstName>
                     <type>ADT</type>
                  </passenger>
               </travellerInformation>
               <dateOfBirth>
                  <dateAndTimeDetails>
                     <date>01JAN80</date>
                  </dateAndTimeDetails>
               </dateOfBirth>
            </passengerData>
         </travellerInfo>
         <dataElementsMaster>
            <marker1/>
            <dataElementsIndiv>
               <elementManagementData>
                  <segmentName>RF</segmentName>
               </elementManagementData>
               <freetextData>
                  <freetextDetail>
                     <subjectQualifier>3</subjectQualifier>
                     <type>P22</type>
                  </freetextDetail>
                  <longFreetext>${{#Project#OfficeId}}</longFreetext>
               </freetextData>
            </dataElementsIndiv>
            <dataElementsIndiv>
               <elementManagementData>
                  <segmentName>OP</segmentName>
               </elementManagementData>
               <optionElement>
                  <optionDetail>
                     <officeId>${{#Project#OfficeId}}</officeId>
                  </optionDetail>
               </optionElement>
            </dataElementsIndiv>
            <dataElementsIndiv>
               <elementManagementData>
                  <segmentName>AP</segmentName>
               </elementManagementData>
               <freetextData>
                  <freetextDetail>
                     <subjectQualifier>3</subjectQualifier>
                     <type>6</type>
                  </freetextDetail>
                  <longFreetext>01232456346</longFreetext>
               </freetextData>
            </dataElementsIndiv>
            <dataElementsIndiv>
               <elementManagementData>
                  <segmentName>AP</segmentName>
               </elementManagementData>
               <freetextData>
                  <freetextDetail>
                     <subjectQualifier>3</subjectQualifier>
                     <type>7</type>
                  </freetextDetail>
                  <longFreetext>07890123456</longFreetext>
               </freetextData>
            </dataElementsIndiv>
            <dataElementsIndiv>
               <elementManagementData>
                  <segmentName>AP</segmentName>
               </elementManagementData>
               <freetextData>
                  <freetextDetail>
                     <subjectQualifier>3</subjectQualifier>
                     <type>P02</type>
                  </freetextDetail>
                  <longFreetext>test@test.com</longFreetext>
               </freetextData>
            </dataElementsIndiv>
            <dataElementsIndiv>
               <elementManagementData>
                  <segmentName>TK</segmentName>
               </elementManagementData>
               <ticketElement>
                  <ticket>
                     <indicator>OK</indicator>
                  </ticket>
               </ticketElement>
            </dataElementsIndiv>            
			
            <dataElementsIndiv>
		     <elementManagementData>
		      <segmentName>SSR</segmentName>
		     </elementManagementData>
		     <serviceRequest>
		      <ssr>
		       <type>CTCE</type>
		       <status>HK</status>
		       <companyId>YY</companyId>
		       <freetext>test//test.com</freetext>
		      </ssr>
		     </serviceRequest>
		  </dataElementsIndiv>
		  <dataElementsIndiv>
		     <elementManagementData>
		      <segmentName>SSR</segmentName>
		     </elementManagementData>
		     <serviceRequest>
		      <ssr>
		       <type>CTCM</type>
		       <status>HK</status>
		       <companyId>YY</companyId>
		       <freetext>19876543210/US</freetext>
		      </ssr>
		     </serviceRequest>
		  </dataElementsIndiv>
		  ${{Trip Properties#S01_commissionstring}}
            ${{Transfered Properties#S01_ssrstring}}
         </dataElementsMaster>
      </PNR_AddMultiElements>
   </soapenv:Body>
</soapenv:Envelope>
";
        public string _service = "PNRADD_22_1_1A";
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
