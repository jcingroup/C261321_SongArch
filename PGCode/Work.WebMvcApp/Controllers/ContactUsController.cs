using System.Web.Mvc;
using ProcCore.Business.Logic;

namespace DotWeb.WebApp.Controllers
{
    public class ContactUsController : WebFrontController
    {
        public ActionResult Index()
        {
            ViewBag.BodyClass = "ContactUs";
            return View("ContactUs", webInfo);
        }
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
        }
	}
}