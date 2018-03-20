using System.Web.Mvc;
using ProcCore.Business.Logic;

namespace DotWeb.WebApp.Controllers
{
    public class ServiceController : WebFrontController
    {
        public ActionResult Index()
        {

            ViewBag.BodyClass = "Service";
            return View("Service", webInfo);
        }
    }
}