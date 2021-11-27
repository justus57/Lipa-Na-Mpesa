using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Lipa_Na_Mpesa.Controllers
{
    public class confirmctbController : ApiController
    {
        public HttpResponseMessage Post([FromBody] dynamic value)
        {
            var resp = new Models.Response { };

            var res = new Models.ValidateC2BRequestResponse { };

            string TransactionType = value.TransactionType;
            string TransID = value.TransID;
            string TransTime = value.TransTime;
            string TransAmount = value.TransAmount;
            string BusinessShortCode = value.BusinessShortCode;
            string BillRefNumber = value.BillRefNumber;
            string InvoiceNumber = value.InvoiceNumber;
            string OrgAccountBalance = value.OrgAccountBalance;
            string ThirdPartyTransID = value.ThirdPartyTransID;
            string MSISDN = value.MSISDN;
            string FirstName = value.FirstName;
            string MiddleName = value.MiddleName;
            string LastName = value.LastName;
     
            Log.WriteLog("Confirm C2B: ");
            Log.WriteLog(value.ToString());

            try
            {
                //string serverresponse = WebService.BC.LogC2BResults(TransID, MSISDN, BillRefNumber, BusinessShortCode, TransactionType, FirstName, MiddleName, LastName, InvoiceNumber, TransTime, Convert.ToDecimal(TransAmount), Convert.ToDecimal(OrgAccountBalance), ThirdPartyTransID);
                //Log.WriteLog(serverresponse);
            }
            catch (Exception es)
            {
                Log.WriteLog(es.Message);
            }
            resp = new Models.Response
            {
                status = "200",
                message = "Success"
            };
            return this.Request.CreateResponse(HttpStatusCode.OK, res);
        }
    }
}
