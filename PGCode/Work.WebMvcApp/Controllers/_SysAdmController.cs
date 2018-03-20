using System.Web.Mvc;
using ProcCore.Business.Logic;
using System;
namespace DotWeb.Controllers
{
    public class _SysAdmController : WebFrontController
    {
        public RedirectResult Index()
        {
            //後台登錄
            return Redirect("~/Sys_Base/SystemLogin/Index");
        }

        public ActionResult NotOpen() {
            return View();
        }


    }
}
