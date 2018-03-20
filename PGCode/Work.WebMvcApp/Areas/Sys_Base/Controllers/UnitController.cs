﻿using Newtonsoft.Json;
using ProcCore.Business.Base;
using ProcCore.Business.Logic;
using ProcCore.Business.Logic.TablesDescription;
using ProcCore.JqueryHelp.JQGridScript;
using ProcCore.NetExtension;
using ProcCore.ReturnAjaxResult;
using ProcCore.WebCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace DotWeb.Areas.Sys_Base.Controllers
{
    public class UnitController : BaseAction<m_Unit, a_Unit, q_Unit, UnitData>
    {
        public UnitController()
        {
        }

        public RedirectResult Index()
        {
            return Redirect(Url.Action("ListGrid"));
        }

        public override ActionResult ListGrid(q_Unit sh)
        {
            operationMode = OperationMode.EnterList;
            HandleRequest HRq = new HandleRequest();
            //記錄QueryString
            HRq.encodeURIComponent = true;
            HRq.Remove("page");

            ViewBag.Page = QueryGridPage();
            ViewBag.Caption = GetSystemInfo().prog_name;
            ViewBag.AppendQuertString = HRq.ToQueryString();
            HRq = null;

            return View("ListData", sh);
        }

        public override ActionResult EditMasterNewData()
        {
            operationMode = OperationMode.EditInsert;
            md = new m_Unit();

            //設定預設值
            md.EditType = EditModeType.Insert;

            ac = new a_Unit();
            ac.Connection = getSQLConnection();
            HandleCollectDataToOptions();

            ViewBag.Caption = GetSystemInfo().prog_name;

            HandleRequest HRq = new HandleRequest();  //記錄QueryString
            HRq.Remove("Id"); //不需記ID
            ViewBag.QueryString = HRq.ToQueryString();
            HRq = null;
            return View("EditData", md);
        }

        public override ActionResult EditMasterDataByID(int id)
        {
            operationMode = OperationMode.EditModify;
            ac = new a_Unit();
            ac.Connection = getSQLConnection();

            RunOneDataEnd<m_Unit> HResult = ac.GetDataMaster(id, LoginUserId);
            md = HResult.SearchData;
            md.EditType = EditModeType.Modify;
            HandleResultCheck(HResult);
            HandleCollectDataToOptions();

            ViewBag.Caption = GetSystemInfo().prog_name;

            HandleRequest HRq = new HandleRequest();  //記錄QueryString
            HRq.Remove("id"); //不需記ID
            ViewBag.QueryString = HRq.ToQueryString();
            HRq = null;

            return View("EditData", md);
        }

        protected override void HandleCollectDataToOptions()
        {
            //ViewBag.NewsKind_Option = MakeDropDownOption(ac.GetGroupCodeValue("NewsKind"));
            a_User ac_User = new a_User() { Connection = getSQLConnection() };
            LogicAddress address = new LogicAddress() { Connection = this.getSQLConnection() };

            ViewBag.Unit_Option = MakeCollectDataToOptions(ac_User.MakeOption_Unit(), false);
            ViewBag.City_Option = MakeCollectDataToOptions(address.GetCity(), false);
            ViewBag.Country_Option = MakeCollectDataToOptions(address.GetCountry(""), false);
        }

        #region Ajax Call Section
        [HttpGet]
        public override string ajax_MasterGridData(q_Unit queryObj)
        {

            #region 連接BusinessLogicLibary資料庫並取得資料
            ac = new a_Unit();
            ac.Connection = this.getSQLConnection();
            RunQueryPackage<m_Unit> HResult = ac.SearchMaster(queryObj, LoginUserId);
            HandleResultCheck(HResult);
            #endregion
            #region 設定 Page物件 頁數 總筆數 每頁筆數
            int page = (queryObj.page == null ? 1 : queryObj.page.CInt());
            int startRecord = PageCount.PageInfo(page, this.DefPageSize, HResult.Count);
            #endregion
            #region 組成資料
            List<RowElement> setRowElement = new List<RowElement>();
            var Model = HResult.SearchData.Skip(startRecord).Take(this.DefPageSize);
            this.Tab = new UnitData();
            foreach (var md in Model)
            {
                List<String> setFields = new List<String>(5);

                RowElement GridRow = new RowElement() { id = md.id.ToString(), cell = new String[3] };

                setFields.Add(md.id.ToString());
                setFields.Add(md.unit_name);
                setFields.Add(md.sort.ToString());

                setRowElement.Add(new RowElement() { id = md.id.ToString(), cell = setFields.ToArray() });
            }
            #endregion
            #region 回傳JSON資料
            JQGridDataObject dataObj = new JQGridDataObject()
            {
                rows = setRowElement.ToArray(),
                total = PageCount.TotalPage,
                page = PageCount.Page,
                records = PageCount.RecordCount
            };

            return JsonConvert.SerializeObject(dataObj, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
            #endregion
        }

        [HttpPost]
        public override String ajax_MasterDeleteData(String id)
        {
            String[] deleteID = id.Split(',');

            ReturnAjaxInfo rAjaxResult = new ReturnAjaxInfo();
            ac = new a_Unit();
            ac.Connection = getSQLConnection();

            RunDeleteEnd HResult = ac.DeleteMaster(deleteID, LoginUserId);
            rAjaxResult = HandleResultAjaxFiles(HResult, Resources.Res.Data_Delete_Success);
            return JsonConvert.SerializeObject(rAjaxResult, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
        }
        public String ajax_MasterUpdata(m_Unit md)
        {
            ReturnAjaxInfo rAjaxResult = new ReturnAjaxInfo();

            a_Unit ac = new a_Unit();
            ac.Connection = getSQLConnection();

            if (md.EditType == EditModeType.Insert)
            {   //新增
                RunInsertEnd HResult = ac.InsertMaster(md, LoginUserId);
                rAjaxResult = HandleResultAjaxFiles(HResult, Resources.Res.Data_Insert_Success);
                rAjaxResult.id = HResult.InsertId;
            }
            else
            {
                //修改
                RunEnd HResult = ac.UpdateMaster(md, LoginUserId);
                rAjaxResult = HandleResultAjaxFiles(HResult, Resources.Res.Data_Update_Success);
                rAjaxResult.id = md.id;
            }
            return JsonConvert.SerializeObject(rAjaxResult, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
        }

        #endregion
    }
}
