using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Lipa_Na_Mpesa.Controllers
{
    public class LNMResponseController : ApiController
    {
        public HttpResponseMessage Post([FromBody] dynamic value)
        {
            var res = new Models.Response { };

            //Extract JSON using Newtonsoft
            string MerchantRequestID = value.Body.stkCallback.MerchantRequestID;
            string CheckoutRequestID = value.Body.stkCallback.CheckoutRequestID;
            int ResultCode = value.Body.stkCallback.ResultCode;
            string ResultDesc = value.Body.stkCallback.ResultDesc;

            //CallbackMetadata
            int Amount = 0;
            string MpesaReceiptNumber = "";
            string TransactionDate = "";
            string PhoneNumber = "";


            //loop through ResultParameter array
            if (value.Body.stkCallback.CallbackMetadata != null)
            {
                foreach (var item in value.Body.stkCallback.CallbackMetadata.Item)
                {
                    if (item.Name == "Amount")
                    {
                        Amount = Convert.ToInt32(item.Value.ToString());
                    }
                    if (item.Name == "MpesaReceiptNumber")
                    {
                        MpesaReceiptNumber = item.Value.ToString();
                    }
                    if (item.Name == "TransactionDate")
                    {
                        TransactionDate = item.Value.ToString();
                    }
                    if (item.Name == "PhoneNumber")
                    {
                        PhoneNumber = item.Value.ToString();
                    }
                }
            }
      
            Log.WriteLog("Lipa a MPESA Callback Response: ");
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
