using Newtonsoft.Json;
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

namespace DotWeb.Areas.Sys_Active.Controllers
{
    public class News_CategoryController : BaseAction<m_News_Category, a_News_Category, q_News_Category, News_Category>
    {
        #region Action and function section

        public RedirectResult Index()
        {
            return Redirect(Url.Action("ListGrid"));
        }
        public override ActionResult ListGrid(q_News_Category sh)
        {
            operationMode = OperationMode.EnterList;
            HandleRequest HRq = new HandleRequest(); //記錄QueryString            
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


            ac = new a_News_Category() { Connection = getSQLConnection(), logPlamInfo = plamInfo };
            md = new m_News_Category() { id = ac.GetIDX() ,is_open = true};
            md.EditType = EditModeType.Insert;
            #region 新增欄位預設值設定
            //md.SetDate = DateTime.Now;
            #endregion
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
            ac = new a_News_Category() { Connection = getSQLConnection(), logPlamInfo = plamInfo }; ;

            RunOneDataEnd<m_News_Category> HResult = ac.GetDataMaster(id, LoginUserId);
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
            //ViewBag.NewsKind_Option = MakeCollectDataToOptions(CodeSheet.NewsKind.ToDictionary(), false);
        }
        #endregion

        #region ajax call section
        [HttpPost]
        [ValidateInput(false)]
        public String ajax_MasterUpdata(m_News_Category md)
        {
            ReturnAjaxFiles rAjaxResult = new ReturnAjaxFiles();
            String returnPicturePath = String.Empty;

            a_News_Category acd = new a_News_Category() { Connection = getSQLConnection(), logPlamInfo = plamInfo };
            acd.Connection = getSQLConnection();

            if (md.oper == "add")
            {   //新增
                RunInsertEnd HResult = acd.InsertMaster(md, LoginUserId);
                rAjaxResult = HandleResultAjaxFiles(HResult, Resources.Res.Data_Insert_Success);
                rAjaxResult.id = HResult.InsertId;
            }
            else
            {
                //修改
                RunEnd HResult = acd.UpdateMaster(md, LoginUserId);
                rAjaxResult = HandleResultAjaxFiles(HResult, Resources.Res.Data_Update_Success);
                rAjaxResult.id = md.id;
            }

            return JsonConvert.SerializeObject(rAjaxResult, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
        }
        [HttpPost]
        public override String ajax_MasterDeleteData(String id)
        {
            String returnString = string.Empty;

            ReturnAjaxFiles rAjaxResult = new ReturnAjaxFiles();
            ac = new a_News_Category() { Connection = getSQLConnection(), logPlamInfo = plamInfo }; ;

            RunDeleteEnd HResult = ac.DeleteMaster(id.Split(',').CInt(), LoginUserId);
            rAjaxResult = HandleResultAjaxFiles(HResult, Resources.Res.Data_Delete_Success);
            return JsonConvert.SerializeObject(rAjaxResult, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
        }
        [HttpGet]
        public override String ajax_MasterGridData(q_News_Category queryObj)
        {
            #region 連接BusinessLogicLibary資料庫並取得資料
            ac = new a_News_Category() { Connection = getSQLConnection(), logPlamInfo = plamInfo }; ;

            RunQueryPackage<m_News_Category> HResult = ac.SearchMaster(queryObj, LoginUserId);
            HandleResultCheck(HResult);
            #endregion
            #region 設定 Page物件 頁數 總筆數 每頁筆數
            int page = (queryObj.page == null ? 1 : queryObj.page.CInt());
            int startRecord = PageCount.PageInfo(page, this.DefPageSize, HResult.Count);
            #endregion
            #region 每行及每個欄位資料組成
            List<RowElement> setRowElement = new List<RowElement>();
            var Modules = HResult.SearchData.Skip(startRecord).Take(this.DefPageSize);
            foreach (m_News_Category md in Modules)
            {
                List<String> setFields = new List<String>(5);

                setFields.Add(md.id.ToString());
                setFields.Add(md.category_name);
                setFields.Add(md.sort.ToString());
                setFields.Add(md.is_open.ToString());
                setRowElement.Add(new RowElement() { id = md.id.ToString(), cell = setFields.ToArray() });
            }
            #endregion
            #region 回傳JSON資料

            return JsonConvert.SerializeObject(new JQGridDataObject()
            {
                rows = setRowElement.ToArray(),
                total = PageCount.TotalPage,
                page = PageCount.Page,
                records = PageCount.RecordCount
            }, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
            #endregion
        }
        #endregion

        [HttpPost]
        [ValidateInput(false)]
        public String ajax_GetAddNewID()
        {
            ReturnAjaxFiles rAjaxResult = new ReturnAjaxFiles();
            rAjaxResult.result = true;
            return JsonConvert.SerializeObject(this.GetNewId(), new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
        }
    }
}