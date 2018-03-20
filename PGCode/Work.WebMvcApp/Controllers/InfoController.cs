using System.Web.Mvc;
using ProcCore.Business.Logic;

namespace DotWeb.WebApp.Controllers
{
    public class InfoController : WebFrontController
    {
        public ActionResult Index()
        {

            ViewBag.BodyClass = "Info";
            return View("Info", webInfo);
        }
    }
}