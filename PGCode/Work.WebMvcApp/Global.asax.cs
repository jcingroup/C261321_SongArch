using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;

using System.Web.WebPages;
using System.Web.Routing;
using System.Web.Optimization;
using DotWeb.CommSetup;

namespace DotWeb.AppStart
{
    public class MvcApplication : System.Web.HttpApplication
    {
        String VarCookie = CommWebSetup.WebCookiesId;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //DisplayModeProvider.Instance.Modes.Insert(0, new DefaultDisplayMode("zh-CN")
            //{
            //    ContextCondition = (Context => (Context.Request.Cookies[VarCookie + ".Lang"].Value == "zh-CN"))
            //});
        }
        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            var WebLang = new HttpCookie(VarCookie + ".Lang", System.Threading.Thread.CurrentThread.CurrentCulture.Name);
            Response.Cookies.Add(WebLang);

            //HttpCookie WebLang = Request.Cookies[VarCookie + ".Lang"];

            //if (WebLang == null)
            //{
            //    //強制預設語系
            //    //WebLang = new HttpCookie(VarCookie + ".Lang", "zh-CN");

            //    if (Request.UserLanguages.Length > 0)
            //        WebLang = new HttpCookie(VarCookie + ".Lang", Request.UserLanguages[0]);
            //    else
            //        WebLang = new HttpCookie(VarCookie + ".Lang", System.Threading.Thread.CurrentThread.CurrentCulture.Name);

            //    Response.Cookies.Add(WebLang);
            //}

            //if (WebLang != null)
            //{
            //    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(WebLang.Value);
            //    System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(WebLang.Value);
            //}
        }
    }
}
