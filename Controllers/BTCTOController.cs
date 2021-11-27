using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Lipa_Na_Mpesa.Controllers
{
    public class BTCTOController : ApiController
    {
        public HttpResponseMessage Post([FromBody] dynamic dynamicstuff)
        {
            var res = new Models.Response { };


            Log.WriteLog("------------------------------------------------------------------------------------------------------------------------------------------------------------------");

            Log.WriteLog("B2C QueTimeout Response: ");
            Log.WriteLog(dynamicstuff.ToString());

            Log.WriteLog("------------------------------------------------------------------------------------------------------------------------------------------------------------------");


            res = new Models.Response
            {
                status = "200",
                message = "Success"
            };
            return this.Request.CreateResponse(HttpStatusCode.OK, res);
        }
    }
}
