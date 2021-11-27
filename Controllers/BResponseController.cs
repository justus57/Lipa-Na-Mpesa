using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Lipa_Na_Mpesa.Controllers
{
    public class BResponseController : ApiController
    {
      //  public HttpResponseMessage Post([FromBody] Models.B2CResult value)
        public HttpResponseMessage Post([FromBody] dynamic value)
        {
            var res = new Models.Response { };

            //Extract JSON using Newtonsoft

            int ResultType = value.Result.ResultType;
            int ResultCode = value.Result.ResultCode;
            string ResultDesc = value.Result.ResultDesc;
            string OriginatorConversationID = value.Result.OriginatorConversationID;
            string ConversationID = value.Result.ConversationID;
            string TransactionID = value.Result.TransactionID;
            //Result params
            int TransactionAmount = 0;
            string TransactionReceipt = "";
            string B2CRecipientIsRegisteredCustomer = "";
            int B2CChargesPaidAccountAvailableFunds = 0;
            string ReceiverPartyPublicName = "";
            string TransactionCompletedDateTime = "";
            int B2CUtilityAccountAvailableFunds = 0;
            int B2CWorkingAccountAvailableFunds = 0;

            string QueueTimeoutURL = value.Result.ReferenceData.ReferenceItem.Value;
            
            //loop through ResultParameter array
            if(value.Result.ResultParameters != null)
            {
                foreach (var item in value.Result.ResultParameters.ResultParameter)
                {
                    if (item.Key == "TransactionAmount")
                    {
                        TransactionAmount = Convert.ToInt32(item.Value.ToString());
                    }
                    if (item.Key == "TransactionReceipt")
                    {
                        TransactionReceipt = item.Value.ToString();
                    }
                    if (item.Key == "B2CRecipientIsRegisteredCustomer")
                    {
                        B2CRecipientIsRegisteredCustomer = item.Value.ToString();
                    }
                    if (item.Key == "B2CChargesPaidAccountAvailableFunds")
                    {
                        B2CChargesPaidAccountAvailableFunds = Convert.ToInt32(item.Value.ToString());
                    }
                    if (item.Key == "ReceiverPartyPublicName")
                    {
                        ReceiverPartyPublicName = item.Value.ToString();
                    }
                    if (item.Key == "TransactionCompletedDateTime")
                    {
                        TransactionCompletedDateTime = item.Value.ToString();
                    }
                    if (item.Key == "B2CUtilityAccountAvailableFunds")
                    {
                        B2CUtilityAccountAvailableFunds = Convert.ToInt32(item.Value.ToString());
                    }
                    if (item.Key == "B2CWorkingAccountAvailableFunds")
                    {
                        B2CWorkingAccountAvailableFunds = Convert.ToInt32(item.Value.ToString());
                    }
                }
            }

            try
            {
               //string response = WebService.BC.LogB2CAPIResponse(ConversationID, OriginatorConversationID, ResultCode, ResultDesc, TransactionID,TransactionReceipt, TransactionAmount, ReceiverPartyPublicName, B2CUtilityAccountAvailableFunds, B2CWorkingAccountAvailableFunds, TransactionCompletedDateTime, B2CChargesPaidAccountAvailableFunds);
               //Log.WriteLog(response);
            }
            catch (Exception ex)
            {              
                Log.WriteLog("LogB2CAPIResponse: " + ex.Message);
            }

            //log values
            Log.WriteLog("B2C Result Response: ");
            Log.WriteLog(value.ToString());

            res = new Models.Response
            {
                status = "200",
                message = "Success"
            };
            return this.Request.CreateResponse(HttpStatusCode.OK, res);
        }
    }
}
