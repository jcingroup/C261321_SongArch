using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using ProcCore.Business.Logic;
using ProcCore.ReturnAjaxResult;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Xml;
using System.Xml.Linq;


namespace DotWeb.WebApp.Controllers
{
    public class IndexController : WebFrontController
    {
        public ActionResult Index()
        {
            return View(this.webInfo.product_category);
        }
    }
    public class LoginData
    {
        /// <summary>
        /// Input User Email
        /// </summary>
        public String user { get; set; }
        public String pwd { get; set; }
        /// <summary>
        /// 驗證碼
        /// </summary>
        public String valid { get; set; }
    }
    public class RegistData
    {
        public String email { get; set; }
        public String pwd { get; set; }
        public String pwd2 { get; set; }
        public String name { get; set; }
        public String tel { get; set; }
        public String valid { get; set; }
    }
}