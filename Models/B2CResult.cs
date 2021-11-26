using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lipa_Na_Mpesa.Models
{
    public class B2CResult
    {
        public Result Result { get; set; }
    }

    public class Result
    {
        public int ResultType { get; set; }
        public int ResultCode { get; set; }
        public string ResultDesc { get; set; }
        public string OriginatorConversationID { get; set; }
        public string ConversationID { get; set; }
        public string TransactionID { get; set; }
        public Resultparameters ResultParameters { get; set; }
        public Referencedata ReferenceData { get; set; }
    }

    public class Resultparameters
    {
        public Resultparameter[] ResultParameter { get; set; }
    }
        
    public class Resultparameter
    {
        public string Key { get; set; }
        public object Value { get; set; }
    }

    public class Referencedata
    {
        public Referenceitem ReferenceItem { get; set; }
    }

    public class Referenceitem
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }

}


