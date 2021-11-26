using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Lipa_Na_Mpesa
{
    public class WebService
    {
        //public static WebRef.MPESAIntegration BC
        //{

        //    get
        //    {
        //        string user = "agencybanking";
        //        string pwd = "B@nking324..";
        //        string domain = "stima-sacco";
        //        string serverUrl = "http://agencytestdb.stima-sacco.local:7720/STIMADBNEW/WS/STIMASACCO/Codeunit/MPESAIntegration";

        //        var ws = new WebRef.MPESAIntegration();

        //        try
        //        {
        //            ServicePointManager.Expect100Continue = true;
        //            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

        //            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

        //            var credentials = new NetworkCredential(user, pwd, domain);
        //            //  ws.UseDefaultCredentials = true;
        //            ws.Url = string.Format(serverUrl);
        //            ws.PreAuthenticate = true;
        //            ws.Credentials = credentials;
        //        }
        //        catch (Exception ex)
        //        {
        //            ex.Data.Clear();
        //            Log.WriteLog("Base: " + ex.Message);
        //        }
        //        return ws;
        //    }
        //}
    }
}