using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using ProcCore;
using ProcCore.WebCore;
using ProcCore.NetExtension;
using ProcCore.Business.Logic;
using ProcCore.Business.Logic.TablesDescription;
using ProcCore.ReturnAjaxResult;
using ProcCore.JqueryHelp.JQGridScript;
using DotWeb.CommSetup;
using Newtonsoft.Json;

namespace DotWeb.Areas.Sys_Active.Controllers
{
    public class ParamController : BaseController
    {
        #region action and function section
        public ActionResult Index()
        {
            ViewBag.Caption = GetSystemInfo().prog_name;
            a_Parm PARMDataHandle = new a_Parm(getSQLConnection()) { logPlamInfo = this.plamInfo };
            return View("EditData", PARMDataHandle.GetParm);
        }

        [HttpPost]
        [ValidateInput(false)]
        public String ajax_MasterUpdata(m_Parm md)
        {
            a_Parm PARMDataHandle = new a_Parm(this.getSQLConnection()) { logPlamInfo = this.plamInfo };

            PARMDataHandle.Open = md.Open;
            PARMDataHandle.DF_Can_Sell_Amt = md.DF_Can_Sell_Amt;
            //PARMDataHandle.ValidDate = md.ValidDate;
            PARMDataHandle.Update();

            ReturnAjaxFiles rAjaxResult = new ReturnAjaxFiles();
            rAjaxResult.title = Resources.Res.Info_WorkResult;
            rAjaxResult.result = true;
            rAjaxResult.message = "參數更新完成";
            return JsonConvert.SerializeObject(rAjaxResult, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
        }
        #endregion
    }
}
