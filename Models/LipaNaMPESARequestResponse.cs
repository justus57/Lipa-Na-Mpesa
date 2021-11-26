using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lipa_Na_Mpesa.Models
{
    public class LipaNaMPESARequestResponse
    {
        public string MerchantRequestID { get; set; }
        public string CheckoutRequestID { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseDescription { get; set; }
        public string CustomerMessage { get; set; }
    }
}

