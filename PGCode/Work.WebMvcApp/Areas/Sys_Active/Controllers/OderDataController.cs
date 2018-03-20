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
    public class OderDataController : BaseActionSub<m_Orders, a_Orders, q_Orders, Orders, m_Orders_Detail, a_Orders_Detail, q_Orders_Detail, Orders_Detail>
    {
        #region Action and function section
        public RedirectResult Index()
        {
            return Redirect(Url.Action("ListGrid"));
        }
        public override ActionResult ListGrid(q_Orders sh)
        {
            operationMode = OperationMode.EnterList;
            HandleRequest HRq = new HandleRequest(); //記錄QueryString            
            HRq.encodeURIComponent = true;
            HRq.Remove("page");

            ViewBag.Page = QueryGridPage();
            ViewBag.Caption = GetSystemInfo().prog_name;
            ViewBag.AppendQuertString = HRq.ToQueryString();
            HRq = null;
            sh.s_order_state = CodeSheet.OrderState.New.Code;
            return View("ListData", sh);
        }
        public override ActionResult EditMasterNewData()
        {
            operationMode = OperationMode.EditInsert;

            ac = new a_Orders() { Connection = getSQLConnection(), logPlamInfo = plamInfo };
            md = new m_Orders() { id = ac.GetIDX() };
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
            ac = new a_Orders() { Connection = getSQLConnection(), logPlamInfo = plamInfo };

            RunOneDataEnd<m_Orders> HResult = ac.GetDataMaster(id, LoginUserId);
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
            ViewBag.options_order_state = MakeCodeToOptions(CodeSheet.OrderState.MakeCodes(), false);
            ViewBag.options_pay_style = MakeCodeToOptions(CodeSheet.PayStyle.MakeCodes(), false);
            ViewBag.options_pay_state = MakeCodeToOptions(CodeSheet.PayState.MakeCodes(), false);
        }
        #endregion

        #region ajax call section
        [HttpPost]
        [ValidateInput(false)]
        public String ajax_MasterUpdata(m_Orders md)
        {
            ReturnAjaxInfo rAjaxResult = new ReturnAjaxInfo();
            String returnPicturePath = String.Empty;

            ac = new a_Orders() { Connection = getSQLConnection(), logPlamInfo = plamInfo }; ;

            if (md.oper == "add")
            {   //新增
                RunInsertEnd HResult = this.ac.InsertMaster(md, LoginUserId);
                rAjaxResult = HandleResultAjaxFiles(HResult, Resources.Res.Data_Insert_Success);
                rAjaxResult.id = HResult.InsertId;
            }
            else
            {
                //修改
                RunEnd HResult = this.ac.UpdateMaster(md, LoginUserId);
                rAjaxResult = HandleResultAjaxFiles(HResult, Resources.Res.Data_Update_Success);
                rAjaxResult.id = md.id;
            }
            return JsonConvert.SerializeObject(rAjaxResult, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
        }
        [HttpPost]
        public override String ajax_MasterDeleteData(String id)
        {
            String returnString = string.Empty;

            ReturnAjaxInfo rAjaxResult = new ReturnAjaxInfo();
            ac = new a_Orders() { Connection = getSQLConnection(), logPlamInfo = plamInfo }; ;

            RunDeleteEnd HResult = ac.DeleteMaster(id.Split(',').CInt(), LoginUserId);
            rAjaxResult = HandleResultAjaxFiles(HResult, Resources.Res.Data_Delete_Success);
            return JsonConvert.SerializeObject(rAjaxResult);
        }
        [HttpGet]
        public override String ajax_MasterGridData(q_Orders queryObj)
        {
            #region 連接BusinessLogicLibary資料庫並取得資料
            ac = new a_Orders() { Connection = getSQLConnection(), logPlamInfo = plamInfo }; ;

            RunQueryPackage<m_Orders> HResult = ac.SearchMaster(queryObj, LoginUserId);
            HandleResultCheck(HResult);
            #endregion
            #region 設定 Page物件 頁數 總筆數 每頁筆數
            int page = (queryObj.page == null ? 1 : queryObj.page.CInt());
            int startRecord = PageCount.PageInfo(page, this.DefPageSize, HResult.Count);
            #endregion
            #region 每行及每個欄位資料組成
            List<RowElement> setRowElement = new List<RowElement>();
            var Modules = HResult.SearchData.Skip(startRecord).Take(this.DefPageSize);
            foreach (m_Orders md in Modules)
            {
                List<String> setFields = new List<String>();

                setFields.Add(md.id.ToString());
                setFields.Add(md.order_serial);
                setFields.Add(md.receive_name);
                setFields.Add(md.transation_date.ToStandardDate());
                setFields.Add(md.receive_tel);
                setFields.Add(GetRecMessage(CodeSheet.OrderState.MakeCodes(),md.order_state));
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
            });
            #endregion
        }
        [HttpPost]
        public override String ajax_SubDataUpdate(m_Orders_Detail md)
        {
            ReturnAjaxInfo rAjaxResult = new ReturnAjaxInfo();
            String returnPicturePath = String.Empty;

            a_Orders_Detail acd = new a_Orders_Detail() { Connection = getSQLConnection(), logPlamInfo = plamInfo };
            acd.Connection = getSQLConnection();

            if (md.oper == "add")
            {   //新增
                RunInsertEnd HResult = acd.InsertMaster(md, LoginUserId);
                rAjaxResult = HandleResultAjaxFiles(HResult, Resources.Res.Data_Insert_Success);
                rAjaxResult.id = HResult.InsertId;
            }
            else if (md.oper == "edit")
            {
                //修改
                RunEnd HResult = acd.UpdateMaster(md, LoginUserId);
                rAjaxResult = HandleResultAjaxFiles(HResult, Resources.Res.Data_Update_Success);
                rAjaxResult.id = md.ids;
            }

            return JsonConvert.SerializeObject(rAjaxResult);
        }
        public override String ajax_DetailGridData(q_Orders_Detail ssh)
        {
            throw new NotImplementedException();
        }
        public override String ajax_DetailUpdata(m_Orders_Detail md)
        {
            throw new NotImplementedException();
        }
        public override String ajax_MasterSubGridData(q_Orders_Detail ssh)
        {
            #region 連接BusinessLogicLibary資料庫並取得資料
            acd = new a_Orders_Detail() { Connection = getSQLConnection(), logPlamInfo = plamInfo }; ;

            RunQueryPackage<m_Orders_Detail> HResult = acd.SearchMaster(ssh, LoginUserId);
            HandleResultCheck(HResult);
            #endregion
            #region 設定 Page物件 頁數 總筆數 每頁筆數
            int page = (ssh.page == null ? 1 : ssh.page.CInt());
            int startRecord = PageCount.PageInfo(page, this.DefPageSize, HResult.Count);
            #endregion
            #region 每行及每個欄位資料組成
            List<RowElement> setRowElement = new List<RowElement>();
            var Modules = HResult.SearchData.Skip(startRecord).Take(this.DefPageSize);
            foreach (m_Orders_Detail md in Modules)
            {
                List<String> setFields = new List<String>();
                setFields.Add(md.ids.ToString());
                setFields.Add(md.item_no.ToString());
                setFields.Add(md.product_id.ToString());
                setFields.Add(md.product_name);
                setFields.Add(md.unit_price.ToString());
                setFields.Add(md.currency);
                setFields.Add(md.unit_name);
                setFields.Add(md.amt.ToString());
                setFields.Add(md.subtotal.ToString());

                setRowElement.Add(new RowElement() { id = md.ids.ToString(), cell = setFields.ToArray() });
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
        public override String ajax_SubDataDelete(string id)
        {
            String returnString = string.Empty;

            ReturnAjaxInfo rAjaxResult = new ReturnAjaxInfo();
            acd = new a_Orders_Detail() { Connection = getSQLConnection(), logPlamInfo = plamInfo }; ;

            RunDeleteEnd HResult = acd.DeleteMaster(id.Split(',').CInt(), LoginUserId);
            rAjaxResult = HandleResultAjaxFiles(HResult, Resources.Res.Data_Delete_Success);
            return JsonConvert.SerializeObject(rAjaxResult);
        }
        [HttpPost]
        public String ajax_id_Category_L1()
        {
            return JsonConvert.SerializeObject(this.GetNewId(ProcCore.Business.CodeTable.Product_Category_L1));
        }
        public String ajax_id_Category_L2()
        {
            return JsonConvert.SerializeObject(this.GetNewId(ProcCore.Business.CodeTable.Product_Category_L2));
        }
        [HttpPost]
        public String ajax_RefreshTotal(int id)
        {
            a_Orders ac_Orders = new a_Orders() { Connection = getSQLConnection(), logPlamInfo = plamInfo };
            ac_Orders.CountTotal(id);
            var r = ac_Orders.GetDataMaster(id, LoginUserId);
            #region 回傳JSON資料
            return JsonConvert.SerializeObject(r.SearchData, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
            #endregion
        }
        #endregion
    }
}