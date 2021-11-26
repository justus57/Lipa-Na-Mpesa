using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lipa_Na_Mpesa.Models
{
    public class B2CRequestResponse
    {
        public string ConversationID { get; set; }
        public string OriginatorConversationID { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseDescription { get; set; }
        //
        public string requestId { get; set; }
        public string errorCode { get; set; }
        public string errorMessage { get; set; }
    }
}




