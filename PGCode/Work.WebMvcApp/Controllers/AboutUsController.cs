using System.Web.Mvc;
using ProcCore.Business.Logic;
using System.Collections;
using System.Collections.Generic;

namespace DotWeb.WebApp.Controllers
{
    public class AboutUsController : WebFrontController
    {
        
        public ActionResult Index()
        {
            a_Page_Context ac = new a_Page_Context() { Connection = getSQLConnection(), logPlamInfo = plamInfo };
            webInfo.page_context = ac.GetDataMaster(1, 0).SearchData;

            ViewBag.BodyClass = "AboutUs";
            return View("AboutUs", webInfo);
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
        }
	}
}