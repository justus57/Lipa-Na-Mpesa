using System.Web;
using System.Web.Mvc;

namespace Lipa_Na_Mpesa
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
