using Lipa_Na_Mpesa.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace Lipa_Na_Mpesa.Controllers
{
    public class InitiateB2CController : ApiController
    {
        // Post: InitiateB2C
       
            public HttpResponseMessage Post([FromBody] B2CRequest value)
            {
                var res = new Response { };

                //create json
                string InitiatorName = value.InitiatorName;
                string SecurityCredential = value.SecurityCredential;
                string CommandID = value.CommandID;
                string Amount = value.Amount;
                string PartyA = value.PartyA;
                string PartyB = value.PartyB;
                string Remarks = value.Remarks;
                string QueueTimeOutURL = value.QueueTimeOutURL;
                string ResultURL = value.ResultURL;
                string Occasion = value.Occasion;

                //create json

                var b2c = new B2CRequest
                {
                    InitiatorName = InitiatorName,
                    SecurityCredential = SecurityCredential,
                    CommandID = CommandID,
                    Amount = Amount,
                    PartyA = PartyA,
                    PartyB = PartyB,
                    Remarks = Remarks,
                    QueueTimeOutURL = QueueTimeOutURL,
                    ResultURL = ResultURL,
                    Occasion = Occasion
                };

                JavaScriptSerializer js = new JavaScriptSerializer();
                string body = js.Serialize(b2c);

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                var client = new RestClient("https://sandbox.safaricom.co.ke/mpesa/b2c/v1/paymentrequest");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", "Bearer BeQAwTwxmkLRka5oH27yakU6SzG6YESJ");
                request.AddHeader("Content-Type", "application/json");

                request.AddParameter("application/json", body, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

                string requestresponse = response.Content;

                B2CRequestResponse jsonB2CRequestResponse = JsonConvert.DeserializeObject<B2CRequestResponse>(requestresponse);

                string ConversationID = jsonB2CRequestResponse.ConversationID;
                string OriginatorConversationID = jsonB2CRequestResponse.OriginatorConversationID;
                string ResponseCode = jsonB2CRequestResponse.ResponseCode;
                string ResponseDescription = jsonB2CRequestResponse.ResponseDescription;

                string requestId = jsonB2CRequestResponse.requestId;
                string errorCode = jsonB2CRequestResponse.errorCode;
                string errorMessage = jsonB2CRequestResponse.errorMessage;

                Log.WriteLog(errorMessage);

                res = new Response
                {
                    status = "200",
                    message = "Success"
                };
                return this.Request.CreateResponse(HttpStatusCode.OK, res);
            }
        

    }
}