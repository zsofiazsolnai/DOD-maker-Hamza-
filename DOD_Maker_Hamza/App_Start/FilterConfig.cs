using System.Web;
using System.Web.Mvc;

namespace DOD_Maker_Hamza
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
