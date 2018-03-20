using DotWeb.CommSetup;
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
using System.Xml;
using System.Xml.Linq;

namespace DotWeb.Areas.Sys_Active.Controllers
{
    public class NewsDataController : BaseAction<m_News, a_News, q_News, News>
    {
        #region Action and function section

        public RedirectResult Index()
        {
            return Redirect(Url.Action("ListGrid"));
        }

        public override ActionResult ListGrid(q_News sh)
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

            ac = new a_News() { Connection = getSQLConnection(), logPlamInfo = plamInfo };
            md = new m_News() { id = ac.GetIDX(ProcCore.Business.CodeTable.News) };
            md.EditType = EditModeType.Insert;
            #region 新增欄位預設值設定
            md.set_date = DateTime.Now;
            md.is_open = true;
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
            ac = new a_News() { Connection = getSQLConnection(), logPlamInfo = plamInfo }; ;

            RunOneDataEnd<m_News> HResult = ac.GetDataMaster(id, LoginUserId);
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

        /// <summary>
        /// 介面製作，例如Option Radio CheckBox 多項目
        /// </summary>
        protected override void HandleCollectDataToOptions()
        {
            ItemsManage itm = new ItemsManage() { Connection = getSQLConnection(), logPlamInfo = this.plamInfo };
            //ViewBag.Option_News_Category = MakeCollectDataToOptions(itm.i_News_Category(0),false);
        }
        #endregion

        #region ajax call section
        /// <summary>
        /// 新增修改提供給Ajax Form Call
        /// </summary>
        /// <returns>JSON format for jquery</returns>
        [HttpPost]
        [ValidateInput(false)]
        public String ajax_MasterUpdata(m_News md)
        {
            ReturnAjaxFiles rAjaxResult = new ReturnAjaxFiles();
            String returnPicturePath = String.Empty;

            ac = new a_News() { Connection = getSQLConnection(), logPlamInfo = plamInfo }; ;

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

        /// <summary>
        /// Grid Ajax 刪除資料 Section
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public override String ajax_MasterDeleteData(String id)
        {
            String returnString = string.Empty;

            ReturnAjaxFiles rAjaxResult = new ReturnAjaxFiles();
            ac = new a_News() { Connection = getSQLConnection(), logPlamInfo = plamInfo }; ;

            RunDeleteEnd HResult = ac.DeleteMaster(id.Split(',').CInt(), LoginUserId);
            rAjaxResult = HandleResultAjaxFiles(HResult, Resources.Res.Data_Delete_Success);
            return JsonConvert.SerializeObject(rAjaxResult, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
        }

        /// <summary>
        /// 由ajax從這裡下載資料 並搭配queryObj作為Search條件搜尋
        /// </summary>
        /// <param name="queryObj"></param>
        /// <returns></returns>
        [HttpGet]
        public override String ajax_MasterGridData(q_News queryObj)
        {
            #region 連接BusinessLogicLibary資料庫並取得資料
            ac = new a_News() { Connection = getSQLConnection(), logPlamInfo = plamInfo }; ;

            RunQueryPackage<m_News> HResult = ac.SearchMaster(queryObj, LoginUserId);
            HandleResultCheck(HResult);
            #endregion
            #region 設定 Page物件 頁數 總筆數 每頁筆數
            int page = (queryObj.page == null ? 1 : queryObj.page.CInt());
            int startRecord = PageCount.PageInfo(page, this.DefPageSize, HResult.Count);
            #endregion
            #region 每行及每個欄位資料組成
            List<RowElement> setRowElement = new List<RowElement>();
            var Modules = HResult.SearchData.Skip(startRecord).Take(this.DefPageSize);
            foreach (m_News md in Modules)
            {
                List<String> setFields = new List<String>(5);

                setFields.Add(md.id.ToString());
                setFields.Add(md.title);
                setFields.Add(md.set_date.ToStandardDate());
                setFields.Add(md.category_name);
                setFields.Add(md.is_open.BooleanValue(BooleanSheet.ynvx));
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

        #region ajax file upload handle
        [HttpPost]
        [ValidateInput(false)]
        public String ajax_UploadFine(int Id, String FilesKind, String hd_FileUp_EL)
        {
            ReturnAjaxFiles rAjaxResult = new ReturnAjaxFiles();
            
            #region
            String tpl_File = String.Empty;
            try
            {
                //只處理圖片
                if (FilesKind == "SingleImg")
                    HandImageSave(hd_FileUp_EL, Id, ImageFileUpParm.NewsBasicSingle, FilesKind);

                if (FilesKind == "DoubleImg")
                    HandImageSave(hd_FileUp_EL, Id, ImageFileUpParm.NewsBasicDouble, FilesKind);

                rAjaxResult.result = true;
                rAjaxResult.success = true;
                rAjaxResult.FileName = hd_FileUp_EL.GetFileName();

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
            DeleteSysFile(Id, FileKind, FileName, ImageFileUpParm.NewsBasicDouble);
            rAjaxResult.result = true;
            return JsonConvert.SerializeObject(rAjaxResult, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
        }
        #endregion

        private void UpFile() {
            //XML檔案管理測試

            XDocument xml = XDocument.Load(Server.MapPath("~/_Code/SysUpFiles/XMLFile.xml"));
            XElement root = xml.Root;
            XElement[] fileobjects = root.Elements().Where(
                x => x.Attribute("system-name").Value == "product" &&
                    x.Attribute("system-kind").Value == "prodlist"
                ).ToArray();

            XElement fileobject = fileobjects.Where(x => x.Attribute("system-id").Value == "3").FirstOrDefault();

            if (fileobject == null)
            {
                XElement sysfile = new XElement("sysfile");
                sysfile.SetAttributeValue("system-name", "product");
                sysfile.SetAttributeValue("system-kind", "prodlist");
                sysfile.SetAttributeValue("system-id", 3);
                root.Add(sysfile);

                XElement fileobj = new XElement("fileobj");
                fileobj.SetAttributeValue("file-name", "產品五.jpg");
                fileobj.SetAttributeValue("sort", "3");
                sysfile.Add(fileobj);

                XElement origin = new XElement("origin");
                origin.SetAttributeValue("unid", Guid.NewGuid());
                fileobj.Add(origin);

                XElement thumb = new XElement("thumb");
                thumb.SetAttributeValue("unid", Guid.NewGuid());
                fileobj.Add(thumb);

                XElement size = new XElement("size");
                size.SetAttributeValue("size", Guid.NewGuid());
                size.SetAttributeValue("size-value", "350");
                fileobj.Add(size);

                xml.Save(Server.MapPath("~/_Code/SysUpFiles/XMLFile.xml"));

                var r = root.Elements().Where(
                    x => x.Attribute("system-name").Value == "product" &&
                            x.Attribute("system-kind").Value == "prodlist" &&
                       (int)x.Attribute("system-id") == 3
                );

                //xml.Save(Server.MapPath("~/_Code/SysUpFiles/XMLFile.xml"));
            }
        }
    }
}