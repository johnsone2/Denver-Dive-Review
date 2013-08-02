using System.Web;
using System.Web.Mvc;

namespace Denver_Dive_Review
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}