using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ProcCore;
using ProcCore.WebCore;
using ProcCore.NetExtension;
using ProcCore.Business.Logic;
using ProcCore.Business.Logic.TablesDescription;
using ProcCore.ReturnAjaxResult;
using ProcCore.JqueryHelp.JQGridScript;
using Newtonsoft.Json;
using DotWeb.CommSetup;
using System.Globalization;

namespace DotWeb.Areas.Sys_Active.Controllers
{
    public class MemberMController : BaseActionSub<m_MemberM, a_MemberM, q_MemberM, MemberM, m_MemberS, a_MemberS, q_MemberS, MemberS>
    {
        #region Action and function section

        public RedirectResult Index()
        {
            return Redirect(Url.Action("ListGrid"));
        }

        public override ActionResult ListGrid(q_MemberM sh)
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

            acd = new a_MemberS() { Connection = getSQLConnection(), logPlamInfo = plamInfo };
            mdd = new m_MemberS() { ids = acd.GetIDX(), id = acd.GetIDX() };
            mdd.EditType = EditModeType.Insert;
            #region 新增欄位預設值設定
            mdd.IsHolder = true;
            #endregion
            HandleCollectDataToOptions();

            ViewBag.Caption = GetSystemInfo().prog_name;

            HandleRequest HRq = new HandleRequest();  //記錄QueryString
            HRq.Remove("Id"); //不需記ID
            ViewBag.QueryString = HRq.ToQueryString();
            HRq = null;

            return View("EditData", mdd);
        }
        public override ActionResult EditMasterDataByID(int id)
        {
            operationMode = OperationMode.EditModify;
            mdd = new m_MemberS() { ids = id, EditType = EditModeType.Modify };
            HandleCollectDataToOptions();

            ViewBag.Caption = GetSystemInfo().prog_name;

            HandleRequest HRq = new HandleRequest();  //記錄QueryString
            HRq.Remove("id"); //不需記ID
            ViewBag.QueryString = HRq.ToQueryString();
            HRq = null;

            return View("EditData", mdd);
        }

        protected override void HandleCollectDataToOptions()
        {
            //ViewBag.NewsKind_Option = MakeCollectDataToOptions(CodeSheet.NewsKind.ToDictionary(), false);
        }
        #endregion

        #region ajax call section
        [HttpPost]
        [ValidateInput(false)]
        public String ajax_MasterUpdata(m_MemberM md)
        {
            ReturnAjaxFiles rAjaxResult = new ReturnAjaxFiles();
            String returnPicturePath = String.Empty;

            ac = new a_MemberM() { Connection = getSQLConnection(), logPlamInfo = plamInfo }; ;

            if (md.EditType == EditModeType.Insert)
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

            ReturnAjaxFiles rAjaxResult = new ReturnAjaxFiles();
            ac = new a_MemberM() { Connection = getSQLConnection(), logPlamInfo = plamInfo }; ;

            RunDeleteEnd HResult = ac.DeleteMaster(id.Split(',').CInt(), LoginUserId);
            rAjaxResult = HandleResultAjaxFiles(HResult, Resources.Res.Data_Delete_Success);
            return JsonConvert.SerializeObject(rAjaxResult, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
        }

        [HttpGet]
        public override string ajax_MasterGridData(q_MemberM queryObj)
        {
            #region 連接BusinessLogicLibary資料庫並取得資料
            ac = new a_MemberM() { Connection = getSQLConnection(), logPlamInfo = plamInfo };

            queryObj.MaxRecord = 5;
            RunQueryPackage<m_MemberM> HResult = ac.SearchMaster(queryObj, LoginUserId);
            HandleResultCheck(HResult);
            #endregion
            #region 設定 Page物件 頁數 總筆數 每頁筆數
            int page = (queryObj.page == null ? 1 : queryObj.page.CInt());
            int startRecord = PageCount.PageInfo(page, 5, HResult.Count);
            #endregion
            #region 每行及每個欄位資料組成
            List<RowElement> setRowElement = new List<RowElement>();
            var Modules = HResult.SearchData.Skip(startRecord).Take(5);
            foreach (m_MemberM md in Modules)
            {
                List<String> setFields = new List<String>(5);

                setFields.Add(md.id.ToString());
                setFields.Add(md.name);
                setFields.Add(md.tel);
                setFields.Add(md.address);
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
        public override string ajax_SubDataUpdate(m_MemberS md)
        {
            ReturnAjaxInfo rAjaxResult = new ReturnAjaxInfo();
            String returnPicturePath = String.Empty;

            acd = new a_MemberS() { Connection = getSQLConnection(), logPlamInfo = plamInfo }; ;

            if (md.EditType == EditModeType.Insert)
            {   //新增
                RunInsertEnd HResult = this.acd.InsertMaster(md, LoginUserId);
                rAjaxResult = HandleResultAjaxFiles(HResult, Resources.Res.Data_Insert_Success);
                rAjaxResult.id = HResult.InsertId;
            }
            else
            {
                //修改
                RunEnd HResult = this.acd.UpdateMaster(md, LoginUserId);
                rAjaxResult = HandleResultAjaxFiles(HResult, Resources.Res.Data_Update_Success);
                rAjaxResult.id = md.id;
            }
            return JsonConvert.SerializeObject(rAjaxResult, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
        }
        public override string ajax_DetailGridData(q_MemberS queryObj)
        {
            #region 連接BusinessLogicLibary資料庫並取得資料
            acd = new a_MemberS() { Connection = getSQLConnection(), logPlamInfo = plamInfo };

            RunQueryPackage<m_MemberS> HResult = acd.SearchMaster(queryObj, LoginUserId);
            HandleResultCheck(HResult);
            #endregion
            #region 設定 Page物件 頁數 總筆數 每頁筆數
            int page = (queryObj.page == null ? 1 : queryObj.page.CInt());
            int startRecord = PageCount.PageInfo(page, 10, HResult.Count);
            #endregion
            #region 每行及每個欄位資料組成
            List<RowElement> setRowElement = new List<RowElement>();
            var Modules = HResult.SearchData.Skip(startRecord).Take(10);
            foreach (m_MemberS md in Modules)
            {
                List<String> setFields = new List<String>();

                setFields.Add(md.IsHolder.BooleanValue(BooleanSheet.ynv));
                setFields.Add(md.name);
                setFields.Add(md.gender.BooleanValue(BooleanSheet.sex));
                setFields.Add(md.bornsign);
                setFields.Add(md.lbirthday);
                setFields.Add(md.tel);
                setFields.Add(md.mobile);
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
        public override string ajax_DetailUpdata(m_MemberS md)
        {
            throw new NotImplementedException();
        }
        public override string ajax_MasterSubGridData(q_MemberS ssh)
        {
            #region 連接BusinessLogicLibary資料庫並取得資料
            acd = new a_MemberS() { Connection = getSQLConnection(), logPlamInfo = plamInfo };

            RunQueryPackage<m_MemberS> HResult = acd.SearchMaster(ssh, LoginUserId);
            HandleResultCheck(HResult);
            #endregion
            #region 設定 Page物件 頁數 總筆數 每頁筆數
            int page = (ssh.page == null ? 1 : ssh.page.CInt());
            int startRecord = PageCount.PageInfo(page, this.DefPageSize, HResult.Count);
            #endregion
            #region 每行及每個欄位資料組成
            List<RowElement> setRowElement = new List<RowElement>();
            var Modules = HResult.SearchData.Skip(startRecord).Take(this.DefPageSize);
            foreach (m_MemberS md in Modules)
            {
                List<String> setFields = new List<String>();
                setFields.Add(md.name);
                setFields.Add(md.gender.BooleanValue(BooleanSheet.sex));
                setFields.Add(md.lbirthday);
                setFields.Add(md.tel);
                setFields.Add(md.address);

                setRowElement.Add(new RowElement() { id = md.id.ToString(), cell = setFields.ToArray() });
            }
            #endregion
            #region 回傳JSON資料

            return JsonConvert.SerializeObject(new JQGridDataObject()
            {
                rows = setRowElement.ToArray(),
                total = PageCount.TotalPage,
                page = 10,
                records = PageCount.RecordCount
            }, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
            #endregion
        }
        public override string ajax_SubDataDelete(String id)
        {
            String returnString = string.Empty;

            ReturnAjaxInfo rAjaxResult = new ReturnAjaxInfo();
            acd = new a_MemberS() { Connection = getSQLConnection(), logPlamInfo = plamInfo }; ;

            RunDeleteEnd HResult = acd.DeleteMaster(id.Split(',').CInt(), LoginUserId);
            rAjaxResult = HandleResultAjaxFiles(HResult, Resources.Res.Data_Delete_Success);
            return JsonConvert.SerializeObject(rAjaxResult, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
        }

        [HttpPost]
        public String ajax_CaleLaur(DateTime dt)
        {
            var clObj = new System.Globalization.ChineseLunisolarCalendar();
            LDate r = new LDate() { Y = clObj.GetYear(dt), M = clObj.GetMonth(dt), D = clObj.GetDayOfMonth(dt) };
            var l = clObj.GetLeapMonth(dt.Year);
            if (l > 0 && r.M > l) r.M--;
            //解決農曆潤月問題
            return JsonConvert.SerializeObject(r, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
        }

        [HttpPost]
        public String ajax_CaleSor(int Y, int M, int D)
        {
            var clObj = new System.Globalization.ChineseLunisolarCalendar();
            var dt = clObj.ToDateTime(Y, M, D, 0, 0, 0, 0);
            return JsonConvert.SerializeObject(dt.ToStandardDate(), new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
        }

        [HttpPost]
        public String ajax_CaleYearSign(int Y)
        {
            a_BornSign ac_BornSign = new a_BornSign() { Connection = getSQLConnection(), logPlamInfo = plamInfo };
            var Sign = ac_BornSign.GetDataMaster(Y, LoginUserId).SearchData;
            return JsonConvert.SerializeObject(Sign, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
        }

        [HttpPost]
        public String ajax_GetMemberData(int id)
        {
            a_MemberS ac_MemberS = new a_MemberS() { Connection = getSQLConnection(), logPlamInfo = plamInfo };
            var r = ac_MemberS.GetDataMaster(id, LoginUserId);
            return JsonConvert.SerializeObject(r.SearchData, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
        }

        #endregion

        #region ajax file upload handle
        [HttpPost]
        [ValidateInput(false)]
        public String ajax_UploadFine(int Id, String FilesKind, String hd_FileUp_EL)
        {
            //hd_FileUp_EL
            ReturnAjaxFiles rAjaxResult = new ReturnAjaxFiles();

            #region
            String tpl_File = String.Empty;
            try
            {
                //判斷是否為圖片檔
                if (!IMGExtDef.Any(x => x == hd_FileUp_EL.GetFileExt()))
                {
                    HandFineSave(hd_FileUp_EL, Id, new FilesUpScope(), FilesKind, false);
                    rAjaxResult.result = true;
                    rAjaxResult.success = true;
                    rAjaxResult.FileName = hd_FileUp_EL.GetFileName();
                }
                else
                {
                    HandImageSave(hd_FileUp_EL, Id, ImageFileUpParm.NewsBasic, FilesKind);
                    rAjaxResult.result = true;
                    rAjaxResult.success = true;
                    rAjaxResult.FileName = hd_FileUp_EL.GetFileName();
                }
            }
            catch (LogicError ex)
            {
                rAjaxResult.result = false;
                rAjaxResult.success = false;
                rAjaxResult.error = GetRecMessage(ex.Message);
            }
            catch (Exception ex)
            {
                rAjaxResult.result = false;
                rAjaxResult.success = false;
                rAjaxResult.error = ex.Message;
            }
            #endregion
            return JsonConvert.SerializeObject(rAjaxResult, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
        }

        [HttpPost]
        [ValidateInput(false)]
        public String ajax_ListFiles(int Id, String FileKind)
        {
            ReturnAjaxFiles rAjaxResult = new ReturnAjaxFiles();
            rAjaxResult.filesObject = ListSysFiles(Id, FileKind);
            rAjaxResult.result = true;
            return JsonConvert.SerializeObject(rAjaxResult, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
        }

        [HttpPost]
        [ValidateInput(false)]
        public String ajax_DeleteFiles(int Id, String FileKind, String FileName)
        {
            ReturnAjaxFiles rAjaxResult = new ReturnAjaxFiles();
            DeleteSysFile(Id, FileKind, FileName, ImageFileUpParm.NewsBasic);
            rAjaxResult.result = true;
            return JsonConvert.SerializeObject(rAjaxResult, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
        }
        #endregion
    }
}