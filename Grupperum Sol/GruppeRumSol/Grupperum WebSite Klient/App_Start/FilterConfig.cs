using System.Web;
using System.Web.Mvc;

namespace Grupperum_WebSite_Klient
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
