using Lipa_Na_Mpesa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;


namespace Lipa_Na_Mpesa.Controllers
{
    public class ValidateB2CController :ApiController
    {
        // Post: ValidateB2C
        public HttpResponseMessage Post([FromBody] dynamic value)
        {
            var res = new ValidateC2BRequestResponse { };

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
            //log values
            int ResultCode = 0;
            string ResultDesc = "";


            if (Convert.ToInt32(TransAmount) >= 10) // validate here
            {
                ResultCode = 0;
                ResultDesc = "Accepted";
            }
            else
            {
                ResultCode = 1;
                ResultDesc = "Rejected";
            }

            try
            {
               // string serverresponse = WebService.BC.LogC2BResults(TransID, MSISDN, BillRefNumber, BusinessShortCode, TransactionType, FirstName, MiddleName, LastName, InvoiceNumber, TransTime, Convert.ToDecimal(TransAmount), Convert.ToDecimal(OrgAccountBalance), ThirdPartyTransID);
               // Log.WriteLog(serverresponse);
            }
            catch (Exception es)
            {
                Log.WriteLog(es.Message);
            }




            res = new ValidateC2BRequestResponse
            {
                ResultCode = ResultCode,
                ResultDesc = ResultDesc
            };
            return this.Request.CreateResponse(HttpStatusCode.OK, res);
        }
    }
}