using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeleton
{
    public class FOP_CreateFormOfPayment
    {
        public string _xml = $@"
<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:sec=""http://xml.amadeus.com/2010/06/Security_v1"" xmlns:link=""http://wsdl.amadeus.com/2010/06/ws/Link_v1"" xmlns:ses=""http://xml.amadeus.com/2010/06/Session_v3"" xmlns:tfop=""http://xml.amadeus.com/TFOPCQ_19_2_1A"">
   <soapenv:Header xmlns:add=""http://www.w3.org/2005/08/addressing"">
	<add:MessageID>${{#TestCase#MessageId}}</add:MessageID>
	<add:Action>${{=request.operation.action}}</add:Action>
	<add:To>${{#Endpoint}}/${{#Project#WSAP}}</add:To>
	<awsse:Session TransactionStatusCode=""InSeries"" xmlns:awsse=""http://xml.amadeus.com/2010/06/Session_v3"">
		<awsse:SessionId>${{#TestCase#SessionId}}</awsse:SessionId>
		<awsse:SequenceNumber>${{=${{#TestCase#SequenceNumber}}+2}}</awsse:SequenceNumber>
		<awsse:SecurityToken>${{#TestCase#SecurityToken}}</awsse:SecurityToken>
	</awsse:Session>
</soapenv:Header>
   <soapenv:Body>     
	<FOP_CreateFormOfPayment>
	  <transactionContext>
	    <transactionDetails>
	      <code>FP</code>
	    </transactionDetails>
	  </transactionContext>
	  <fopGroup>
	    <fopReference/>
	    <mopDescription>
	      <fopSequenceNumber>
	        <sequenceDetails>
	          <number>1</number>
	        </sequenceDetails>
	      </fopSequenceNumber>
	      <mopDetails>
	        <fopPNRDetails>
	          <fopDetails>
	            <fopCode>CASH</fopCode>
	          </fopDetails>
	        </fopPNRDetails>
	      </mopDetails>
	    </mopDescription>
	  </fopGroup>
	</FOP_CreateFormOfPayment>
   </soapenv:Body>
</soapenv:Envelope>
";
        public string _service = "TFOPCQ_19_2_1A";

    }
}
