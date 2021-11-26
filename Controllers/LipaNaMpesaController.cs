using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Lipa_Na_Mpesa.Controllers
{
    public class LipaNaMpesaController :ApiController
    {
        // Post: LipaNaMpesa
        public HttpResponseMessage Post([FromBody] Models.LipaNaMPESARequest value)
        {
            var res = new Models.Response { };

            //call Lipa Na MPESA to init STK Push
            string requestresponse = "";


            Models.LipaNaMPESARequestResponse jsonLNMRequestResponse = JsonConvert.DeserializeObject<Models.LipaNaMPESARequestResponse>(requestresponse);

            string MerchantRequestID = jsonLNMRequestResponse.MerchantRequestID;
            string CheckoutRequestID = jsonLNMRequestResponse.CheckoutRequestID;
            string ResponseCode = jsonLNMRequestResponse.ResponseCode;
            string ResponseDescription = jsonLNMRequestResponse.ResponseDescription;
            string CustomerMessage = jsonLNMRequestResponse.CustomerMessage;

            Log.WriteLog(MerchantRequestID);
            res = new Models.Response
            {
                status = "200",
                message = "Success"
            };
            return this.Request.CreateResponse(HttpStatusCode.OK, res);
        }
    }
}