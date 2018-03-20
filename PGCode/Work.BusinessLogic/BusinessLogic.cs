using ProcCore.Business.Base;
using ProcCore.Business.Logic.TablesDescription;
using ProcCore.DatabaseCore;
using ProcCore.DatabaseCore.DataBaseConnection;
using ProcCore.DatabaseCore.SQLContextHelp;
using ProcCore.NetExtension;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;

namespace ProcCore.Business
{
    public enum CodeTable
    {
        Base, Product, News, Orders, OrdersDetail, Member, Product_Category_L1, Product_Category_L2, Product_Tree
    }
    public enum SNType
    {
        Orders, Product
    }
}
namespace ProcCore.Business.Logic
{
    #region Code Value Replay
    public static class CodeSheet
    {
        public static NewsCategory NewsCategory = new NewsCategory()
        {
            Active = new _Code() { Code = "Active", Value = "最新活動", LangCode = "C_NewsCategory_Active" },
            News = new _Code() { Code = "News", Value = "最新消息", LangCode = "C_NewsCategory_News" },
            Post = new _Code() { Code = "Post", Value = "最新公告", LangCode = "C_NewsCategory_Post" }
        };
        public static UserState UserState = new UserState()
        {
            Normal = new _Code() { Code = "Normal", Value = "正常", LangCode = "C_UserState_Normal" },
            Stop = new _Code() { Code = "Stop", Value = "停止", LangCode = "C_UserState_Stop" },
            Pause = new _Code() { Code = "Pause", Value = "暫停", LangCode = "C_UserState_Pause" }
        };
        public static ProductState ProductState = new ProductState()
        {
            Normal = new _Code() { Code = "Normal", Value = "正常", LangCode = "C_ProductState_Normal" },
            Stop = new _Code() { Code = "Stop", Value = "停止", LangCode = "C_ProductState_Short" }
        };
        public static MemberState MemberState = new MemberState()
        {
            New = new _Code() { Code = "New", Value = "新加入Email驗證中", LangCode = "C_MemberState_New" },
            EmailPass = new _Code() { Code = "EmailPass", Value = "Email已驗證等待審核通過", LangCode = "C_MemberState_EmailPass" },
            Normal = new _Code() { Code = "Normal", Value = "正常", LangCode = "C_MemberState_Normal" },
            Stop = new _Code() { Code = "Stop", Value = "停權", LangCode = "C_MemberState_Stop" }

        };
        public static OrderState OrderState = new OrderState()
        {
            New = new _Code() { Code = "New", Value = "新訂單", LangCode = "C_OrderState_New" },
            Handle = new _Code() { Code = "Handle", Value = "處理中", LangCode = "C_OrderState_Handle" },
            Close = new _Code() { Code = "Close", Value = "完成", LangCode = "C_OrderState_Close" },
            Cancel = new _Code() { Code = "Cancel", Value = "取消", LangCode = "C_OrderState_Cancel" }
        };
        public static ShelfSatet ShelfSatet = new ShelfSatet()
        {
            Off = new _Code() { Code = "Off", Value = "下架", LangCode = "C_ShelfSatet_Off" },
            On = new _Code() { Code = "On", Value = "上架", LangCode = "C_ShelfSatet_On" }
        };
        public static PayStyle PayStyle = new PayStyle()
        {
            ATM = new _Code() { Code = "ATM", Value = "ATM轉帳", LangCode = "C_PayStyle_ATM" },
            PAY = new _Code() { Code = "PAY", Value = "貨到付款", LangCode = "C_PayStyle_PAY" }
        };
        public static PayState PayState = new PayState()
        {
            Waiting = new _Code() { Code = "Waiting", Value = "尚未付款", LangCode = "C_PayState_Waiting" },
            Insufficient = new _Code() { Code = "Insufficient", Value = "付款不足", LangCode = "C_PayState_Insufficient" },
            Finish = new _Code() { Code = "Finish", Value = "完成付款", LangCode = "C_PayState_Finish" }
        };

        public static ProductCategory ProductCategory = new ProductCategory()
        {
            Building = new _Code() { Code = "Building", Value = "土木工程", LangCode = "C_ProductCategory_Building" },
            Factory = new _Code() { Code = "Factory", Value = "廠房工程", LangCode = "C_ProductCategory_Factory" },
            Steel = new _Code() { Code = "Steel", Value = "鋼構工程", LangCode = "C_ProductCategory_Steel" }
        };

    }
    public class NewsCategory : BaseSheet
    {
        public NewsCategory() { this.HeadCode = "NewsCategory"; }
        public _Code Active { get; set; }
        public _Code News { get; set; }
        public _Code Post { get; set; }
        public override List<_Code> MakeCodes()
        {
            this.Codes = new List<_Code>(); this.Codes.AddRange(new _Code[] { this.Active, this.News, this.Post }); return base.MakeCodes();
        }
    }
    public class UserState : BaseSheet
    {
        public UserState() { this.HeadCode = "UserState"; }
        public _Code Normal { get; set; }
        public _Code Stop { get; set; }
        public _Code Pause { get; set; }
        public override List<_Code> MakeCodes()
        {
            this.Codes = new List<_Code>(); this.Codes.AddRange(new _Code[] { this.Normal, this.Stop, this.Pause }); return base.MakeCodes();
        }
    }
    public class ProductState : BaseSheet
    {
        public ProductState() { this.HeadCode = "ProductState"; }
        public _Code Normal { get; set; }
        public _Code Stop { get; set; }
        public override List<_Code> MakeCodes()
        {
            this.Codes = new List<_Code>(); this.Codes.AddRange(new _Code[] { this.Normal, this.Stop }); return base.MakeCodes();
        }
    }
    public class MemberState : BaseSheet
    {
        public MemberState() { this.HeadCode = "MemberState"; }
        public _Code New { get; set; }
        public _Code Normal { get; set; }
        public _Code Stop { get; set; }
        public _Code EmailPass { get; set; }
        public override List<_Code> MakeCodes()
        {
            this.Codes = new List<_Code>(); this.Codes.AddRange(new _Code[] { this.New, this.Normal, this.Stop, this.EmailPass }); return base.MakeCodes();
        }
    }
    public class OrderState : BaseSheet
    {
        public OrderState() { this.HeadCode = "OrderState"; }
        public _Code New { get; set; }
        public _Code Handle { get; set; }
        public _Code Close { get; set; }
        public _Code Cancel { get; set; }
        public override List<_Code> MakeCodes()
        {
            this.Codes = new List<_Code>(); this.Codes.AddRange(new _Code[] { this.New, this.Handle, this.Close, this.Cancel }); return base.MakeCodes();
        }
    }
    public class ShelfSatet : BaseSheet
    {
        public ShelfSatet() { this.HeadCode = "ShelfSatet"; }
        public _Code Off { get; set; }
        public _Code On { get; set; }
        public override List<_Code> MakeCodes()
        {
            this.Codes = new List<_Code>(); this.Codes.AddRange(new _Code[] { this.Off, this.On }); return base.MakeCodes();
        }
    }
    public class PayStyle : BaseSheet
    {
        public PayStyle() { this.HeadCode = "PayStyle"; }
        public _Code ATM { get; set; }
        public _Code PAY { get; set; }
        public override List<_Code> MakeCodes()
        {
            this.Codes = new List<_Code>(); this.Codes.AddRange(new _Code[] { this.ATM, this.PAY }); return base.MakeCodes();
        }
    }
    public class ProductCategory : BaseSheet
    {
        public ProductCategory() { this.HeadCode = "ProductCategory"; }
        public _Code Building { get; set; }
        public _Code Factory { get; set; }
        public _Code Steel { get; set; }
        public override List<_Code> MakeCodes()
        {
            this.Codes = new List<_Code>(); 
            this.Codes.AddRange(new _Code[] { this.Building, this.Factory, this.Steel }); 
            return base.MakeCodes();
        }

        public Product[] product { get; set; }
    }

    public class PayState : BaseSheet
    {
        public PayState() { this.HeadCode = "PayState"; }
        public _Code Waiting { get; set; }
        public _Code Insufficient { get; set; }
        public _Code Finish { get; set; }
        public override List<_Code> MakeCodes()
        {
            this.Codes = new List<_Code>(); this.Codes.AddRange(new _Code[] { this.Waiting, this.Insufficient, this.Finish }); return base.MakeCodes();
        }
    }


    #endregion
    public static class BooleanSheet
    {
        #region ReplayArea

        public static BooleanSheetBase Boolean = new BooleanSheetBase()
        {
            TrueValue = "True",
            FalseValue = "False"
        };

        public static BooleanSheetBase sex = new BooleanSheetBase()
        {
            TrueValue = "男",
            FalseValue = "女"
        };

        public static BooleanSheetBase yn = new BooleanSheetBase()
        {
            TrueValue = "是",
            FalseValue = "否"
        };

        public static BooleanSheetBase ynv = new BooleanSheetBase()
        {
            TrueValue = "✔",
            FalseValue = ""
        };

        public static BooleanSheetBase ynvx = new BooleanSheetBase()
        {
            TrueValue = "✔",
            FalseValue = "✕"
        };

        #endregion
    }
    public class snObject
    {
        public int y { get; set; }
        public int m { get; set; }
        public int d { get; set; }
        public int w { get; set; }
        public int sn_max { get; set; }
    }
    #region System Base Class
    #region Address Logic Handle
    public class LogicAddress : LogicBase
    {
        public Dictionary<String, String> GetCity()
        {
            TablePack<_AddressCity> dataWork = new TablePack<_AddressCity>(Connection) { };

            dataWork.SelectFields(x => x.city);
            dataWork.OrderByFields(x => x.sort);
            return dataWork.DataByAdapter().dicMakeKeyValue(0, 0);
        }
        public Dictionary<String, String> GetCountry(String city)
        {
            TablePack<_AddressCounty> dataWork = new TablePack<_AddressCounty>(Connection) { };

            dataWork.SelectFields(x => x.county);
            dataWork.WhereFields(x => x.city, city);
            dataWork.OrderByFields(x => x.sort);
            return dataWork.DataByAdapter().dicMakeKeyValue(0, 0);
        }
        public RunQueryPackage<m__Adr_zh_TW> GetRoadIndex_TW(String key)
        {
            #region 全域變數宣告
            RunQueryPackage<m__Adr_zh_TW> r = new RunQueryPackage<m__Adr_zh_TW>();
            #endregion

            TablePack<_Adr_zh_TW> dataWork = new TablePack<_Adr_zh_TW>(Connection) { TableModule = new _Adr_zh_TW() };
            dataWork.TopLimit = 10;
            dataWork.SelectFields(x => x.zip);
            dataWork.SelectFields(x => x.data);
            dataWork.WhereFields(x => x.data, key, WhereCompareType.LikeRight);
            r.SearchData = dataWork.DataByAdapter<m__Adr_zh_TW>();
            return r;
        }
        public String GetZip(String city, String country)
        {
            TablePack<_AddressCounty> dataWork = new TablePack<_AddressCounty>(Connection) { };

            dataWork.SelectFields(x => x.zip);
            dataWork.WhereFields(x => x.city, city);
            dataWork.WhereFields(x => x.county, country);

            DataTable dt = dataWork.DataByAdapter();
            return dt.Rows.Count > 0 ? dt.Rows[0][dataWork.TableModule.zip.N].ToString() : "";
        }
    }

    #endregion
    #region Address

    public class m__Adr_zh_TW
    {
        public String zip { get; set; }
        public String data { get; set; }
    }

    #endregion
    #region Code Sheet
    public class BaseSheet
    {
        public int CodeGroup { get; set; }
        public String HeadCode { get; set; }
        public CommConnection Connection { get; set; }
        protected List<_Code> Codes { get; set; }

        public virtual List<_Code> MakeCodes()
        {
            return this.Codes;
        }
        public Dictionary<String, String> ToDictionary()
        {
            Dictionary<String, String> d = new Dictionary<String, String>();
            foreach (_Code _C in this.MakeCodes())
            {
                d.Add(_C.Code, _C.Value);
            }
            return d;
        }
    }
    public class _Code
    {
        public String Code { get; set; }
        public String LangCode { get; set; }
        public String Value { get; set; }
    }
    #endregion
    #region Boolean Sheet
    public class BooleanSheetBase
    {
        public String TrueValue { get; set; }
        public String FalseValue { get; set; }
    }


    #endregion
    #region System Program Menu

    public class SYSMenu : LogicBase
    {
        private int _LoginUserID;
        private String _WebAppPath;

        public SYSMenu(int LoginUserID, String WebAppPath, CommConnection conn)
        {
            _LoginUserID = LoginUserID;
            _WebAppPath = WebAppPath;
            this.Connection = conn;

            ProgData TObj = new ProgData();
            TablePack<ProgData> dataWork = new TablePack<ProgData>(Connection) { TableModule = TObj };
            dataWork.WhereFields(x => x.ishidden, false);
            dataWork.WhereFields(x => x.isfolder, true);
            dataWork.OrderByFields(x => x.sort);

            DataTable dt = dataWork.DataByAdapter();

            List<MenuFoler> menuFolder = new List<MenuFoler>();

            foreach (DataRow dr in dt.Rows)
            {
                MenuFoler Folder = new MenuFoler(this._LoginUserID, WebAppPath);
                Folder.Connection = this.Connection;
                Folder.prod_id = dr[TObj.id.N].ToString();
                Folder.AllowMobile = (Boolean)dr[TObj.ismb.N];

                if (Folder.GetMenuItem.Count() > 0)
                {
                    menuFolder.Add(Folder);
                }
                this.GetMenuFolder = menuFolder.ToArray();
            }
        }

        public MenuFoler[] GetMenuFolder { get; set; }
    }
    public class MenuFoler : LogicBase
    {
        private String _id;
        private String _WebAppPath;
        private int _LoginUserID;

        public MenuFoler(int LoginUserID, string WebAppPath)
        {
            _WebAppPath = WebAppPath;
            _LoginUserID = LoginUserID;
        }

        public String prod_id
        {
            get
            {
                return _id;
            }
            set
            {
                this._id = value;
                ProgData TObj = new ProgData();
                TablePack<ProgData> dataWork = new TablePack<ProgData>(Connection) { TableModule = TObj };
                TObj.KeyFieldModules[TObj.id.N].V = this._id;

                var dt = dataWork.GetDataByKey<m_ProgData>();

                FolderName = dt.prog_name;
                Sort = dt.sort;

                dataWork = null;
                dataWork = new TablePack<ProgData>(Connection) { TableModule = TObj };
                //dataWork.Reset();
                dataWork.WhereFields(x => x.ishidden, false);
                dataWork.WhereFields(x => x.isfolder, false);
                dataWork.WhereFields(x => x.sort, Sort, WhereCompareType.LikeRight);
                dataWork.OrderByFields(x => x.sort);

                var item = dataWork.DataByAdapter<m_ProgData>();

                List<MenuItem> Item = new List<MenuItem>();

                Int32[] 管理者專用系統Id = new Int32[] { 0 }; //系統是管理者專用的

                foreach (var q in item)
                {
                    PowerHave pHave = new PowerHave();
                    pHave.Connection = this.Connection;
                    pHave.SetPower(this._LoginUserID, q.id);

                    if (pHave.PowerDataSet.GetPower(PowersName.Manage).HavePower)
                    {
                        MenuItem mItem = new MenuItem(_WebAppPath);
                        if (管理者專用系統Id.Contains(q.id))
                        {
                            if (_LoginUserID == 1) //這是指admin帳號
                            {
                                mItem.Connection = this.Connection;
                                mItem.prod_id = q.id.ToString();
                                mItem.AllowMobile = q.ismb;
                                Item.Add(mItem);
                            }
                        }
                        else
                        {
                            mItem.Connection = this.Connection;
                            mItem.prod_id = q.id.ToString();
                            mItem.AllowMobile = q.ismb;
                            Item.Add(mItem);
                        }
                    }
                }
                this.GetMenuItem = Item.ToArray();
            }
        }
        public String FolderName { get; set; }
        public String Sort { get; set; }
        public String Link { get; set; }
        public Boolean AllowMobile { get; set; }
        public MenuItem[] GetMenuItem { get; set; }
    }
    public class MenuItem : LogicBase
    {
        string _WebAppPath = String.Empty;
        public MenuItem(String WebAppPath)
        {
            _WebAppPath = WebAppPath;
        }
        private String _id;
        public String prod_id
        {
            get
            {
                return _id;
            }
            set
            {
                this._id = value;
                ProgData TObj = new ProgData();
                TablePack<ProgData> dataWork = new TablePack<ProgData>(Connection) { TableModule = TObj };
                TObj.KeyFieldModules[TObj.id.N].V = this._id;

                DataTable dt = dataWork.GetDataByKey();

                this.Link = _WebAppPath + dt.Rows[0][TObj.area.N].ToString() + "/" + dt.Rows[0][TObj.controller.N].ToString() + "/" + dt.Rows[0][TObj.action.N].ToString();
                this.ItemName = dt.Rows[0][TObj.prog_name.N].ToString();
            }
        }
        public String ItemName { get; set; }
        public String Link { get; set; }
        public Boolean AllowMobile { get; set; }
    }

    #endregion
    #region Power
    public enum PowersName
    {
        Controller, Manage, List, AddNew, Modify, Delete, Verify, Rely, Print
    }

    public class Power
    {
        public int Id { get; set; }
        public PowersName name { get; set; }
        public int ManagementIntSerial { get; set; }
        public Boolean IsManagement { get; set; }
        public Boolean HavePower { get; set; }
    }
    public class PowerData
    {
        public PowerData()
        {
            #region 設定權限核心資料

            this.Powers = new Power[] { 
                new Power { Id = 1, name = PowersName.Controller, ManagementIntSerial = System.Math.Pow(2, 0).CInt() },
                new Power { Id = 2, name = PowersName.Manage, ManagementIntSerial = System.Math.Pow(2, 1).CInt() },
                new Power { Id = 3, name = PowersName.List, ManagementIntSerial = System.Math.Pow(2, 2).CInt() },
                new Power { Id = 4, name = PowersName.AddNew, ManagementIntSerial = System.Math.Pow(2, 3).CInt() },
                new Power { Id = 5, name = PowersName.Modify, ManagementIntSerial = System.Math.Pow(2, 4).CInt() },
                new Power { Id = 6, name = PowersName.Delete, ManagementIntSerial = System.Math.Pow(2, 5).CInt() }
               // new Power { Id = 7, name = PowersName.Verify, ManagementIntSerial = System.Math.Pow(2, 6).CInt() },
               // new Power { Id = 8, name = PowersName.Rely, ManagementIntSerial = System.Math.Pow(2, 7).CInt() },
               // new Power { Id = 9, name = PowersName.Print, ManagementIntSerial = System.Math.Pow(2, 8).CInt() }
            };

            #endregion
        }

        public Power[] Powers { get; set; }

        public Power GetPower(PowersName p)
        {
            return this.Powers.Where(x => x.name == p).FirstOrDefault();
        }
    }
    public class PowerManagement : PowerData
    {
        int _PowerSerial;

        public PowerManagement()
            : base()
        {

        }

        /// <summary>
        /// ProgData的權碼
        /// </summary>
        /// <param name="GetPowerSerial"></param>
        public PowerManagement(int GetPowerSerial)
            : base()
        {
            this._PowerSerial = GetPowerSerial;
            foreach (Power p in Powers)
            {
                p.IsManagement = (p.ManagementIntSerial & this.PowerSerial) > 0;
            }
        }

        public int PowerSerial
        {
            get { return this._PowerSerial; }
            set
            {
                this._PowerSerial = value;
                foreach (Power p in Powers)
                {
                    p.IsManagement = (p.ManagementIntSerial & this.PowerSerial) > 0;
                }
            }
        }
        public int Unit { get; set; }
    }
    public class PowerHave : LogicBase
    {
        public PowerHave()
        {
            PowerDataSet = new PowerData();
        }

        public void SetPower(int UserId, int ProgId)
        {
            a_User ac = new a_User() { Connection = this.Connection };

            RunOneDataEnd<m_User> HResult = ac.GetDataMaster(UserId, 0); //查詢此User的單位代碼

            m_User md = HResult.SearchData;

            if (md.isadmin)
                foreach (Power p in this.PowerDataSet.Powers)
                    p.HavePower = true;
            else
            {
                String sql = "Select PowerID From _PowerUsers Where UserID=@UserID and ProgID=@ProgID UNION ALL Select PowerID From _PowerUnit Where UnitID=@UnitID and ProgID=@ProgID";

                Params("@UserID", UserId);
                Params("@UnitID", md.unit);
                Params("@ProgID", ProgId);

                DataTable dt = ExecuteData(sql);

                foreach (DataRow dr in dt.Rows)
                {
                    int powerId = dr["PowerID"].CInt();

                    if (powerId == this.PowerDataSet.GetPower(PowersName.Controller).Id) //PowerId是 Controller，
                        foreach (Power p in this.PowerDataSet.Powers)
                            p.HavePower = true;
                    else
                        this.PowerDataSet.Powers[powerId - 1].HavePower = true;
                }

                dt.Dispose();
                dt = null;
            }
        }

        /// <summary>
        /// 陣列式權限處理
        /// </summary>
        public PowerData PowerDataSet { get; set; }
    }
    public class m_PowerMaster
    {

        private PowerData _pwd;
        public m_PowerMaster()
        {

            _pwd = new PowerData();

            pw1 = _pwd.GetPower(PowersName.Controller);
            pw2 = _pwd.GetPower(PowersName.Manage);
            pw3 = _pwd.GetPower(PowersName.List);
            pw4 = _pwd.GetPower(PowersName.AddNew);
            pw5 = _pwd.GetPower(PowersName.Modify);
            pw6 = _pwd.GetPower(PowersName.Delete);
            //            pw7 = _pwd.GetPower(PowersName.Verify);
            //            pw8 = _pwd.GetPower(PowersName.Rely);
            //            pw9 = _pwd.GetPower(PowersName.Print);
            Powers = new List<Power>();
            Powers.Add(pw1);
            Powers.Add(pw2);
            Powers.Add(pw3);
            Powers.Add(pw4);
            Powers.Add(pw5);
            Powers.Add(pw6);
            //Powers.Add(pw7);
            //Powers.Add(pw8);
            //Powers.Add(pw9);
        }

        public int progid { get; set; }
        public String progname { get; set; }

        public Power pw1 { get; set; }
        public Power pw2 { get; set; }
        public Power pw3 { get; set; }
        public Power pw4 { get; set; }
        public Power pw5 { get; set; }
        public Power pw6 { get; set; }
        //public Power pw7 { get; set; }
        //public Power pw8 { get; set; }
        //public Power pw9 { get; set; }

        public List<Power> Powers { get; set; }
    }
    #endregion
    #region Power for unit
    public class q_PowerUnit : QueryBase
    {
        public int Unit { get; set; }
    }
    public class a_PowerUnit : LogicBase
    {
        public RunUpdateEnd UpdateMaster(m_PowerUnit md, string AccountID)
        {
            RunUpdateEnd r = new RunUpdateEnd();
            _PowerUnit TObj = new _PowerUnit();

            try
            {
                Connection.BeginTransaction();
                TablePack<_PowerUnit> dataWork = new TablePack<_PowerUnit>(Connection) { TableModule = TObj };
                if (md.check)
                {
                    //新增
                    dataWork.NewRow();
                    dataWork.SetDataRowValue(x => x.ProgID, md.prog);
                    dataWork.SetDataRowValue(x => x.PowerID, md.power);
                    dataWork.SetDataRowValue(x => x.UnitID, md.unit);
                    dataWork.SetDataRowValue(x => x.AccessUnit, 1);
                    dataWork.AddRow();
                    dataWork.UpdateDataAdapter();
                }
                else
                {
                    //刪除

                    dataWork.WhereFields(x => x.ProgID, md.prog, WhereCompareType.Equel);
                    dataWork.WhereFields(x => x.PowerID, md.power, WhereCompareType.Equel);
                    dataWork.WhereFields(x => x.UnitID, md.unit, WhereCompareType.Equel);

                    DataTable dt_Origin = dataWork.DataByAdapter();
                    dataWork.DeleteAll();
                    dataWork.UpdateDataAdapter();
                }

                Connection.EndCommit();
                r.Result = true;
                return r;
            }
            catch (LogicRoll ex)
            {
                Connection.Rollback();

                r.Result = false;
                r.ErrType = BusinessErrType.Logic;
                r.Message = ex.Message;
                return r;
            }
            catch (Exception ex)
            {
                Connection.Rollback();
                r.Result = false;
                r.ErrType = BusinessErrType.System;
                r.Message = PackErrMessage(ex);
                return r;
            }
            finally
            {

            }

        }
        public RunQueryPackage<m_PowerMaster> SearchMaster(q_PowerUnit qr, int AccountID)
        {
            RunQueryPackage<m_PowerMaster> r = new RunQueryPackage<m_PowerMaster>();
            _PowerUnit TObj = new _PowerUnit();
            try
            {
                PowerManagement PowerMG = new PowerManagement(); //計算所需要顯示的權限

                TablePack<ProgData> dataWork = new TablePack<ProgData>(Connection) { TableModule = new ProgData() };
                dataWork.SelectFields(x => new { x.id, x.prog_name, x.isfolder, x.power_serial });
                dataWork.WhereFields(x => x.isfolder, false);
                dataWork.OrderByFields(x => x.sort);

                m_ProgData[] m_progdatas = dataWork.DataByAdapter<m_ProgData>();

                TablePack<_PowerUnit> PowerUnitWork = new TablePack<_PowerUnit>(Connection) { TableModule = new _PowerUnit() };
                PowerUnitWork.TableModule.ProgID.Alias = "prog";
                PowerUnitWork.TableModule.PowerID.Alias = "power";

                PowerUnitWork.SelectFields(x => new { x.ProgID, x.PowerID });
                PowerUnitWork.WhereFields(x => x.UnitID, qr.Unit);

                m_PowerUnit[] PowerQuery = PowerUnitWork.DataByAdapter<m_PowerUnit>();

                List<m_PowerMaster> k = new List<m_PowerMaster>();

                foreach (var dr in m_progdatas)
                {
                    PowerMG.PowerSerial = dr.power_serial;

                    m_PowerMaster pm = new m_PowerMaster();
                    pm.progid = dr.id;
                    pm.progname = dr.prog_name;

                    foreach (Power p in pm.Powers)
                    {
                        p.IsManagement = PowerMG.Powers.Single(x => x.Id == p.Id).IsManagement;
                        p.HavePower = PowerQuery.Where(x => x.prog == dr.id && x.power == p.Id).Count() > 0;
                    }
                    k.Add(pm);
                }

                r.SearchData = k.ToArray();
                r.Result = true;
                return r;
            }
            catch (LogicRoll ex)
            {
                r.Result = false;
                r.ErrType = BusinessErrType.Logic;
                r.Message = ex.Message;
                return r;
            }
            catch (Exception ex)
            {
                r.Result = false;
                r.ErrType = BusinessErrType.System;
                r.Message = PackErrMessage(ex);
                return r;
            }

        }
        public Dictionary<String, String> CollectKeyValueData_Unit()
        {
            UnitData TObj = new UnitData();// 取得Table物
            TablePack<UnitData> dataWork = new TablePack<UnitData>(Connection) { LoginUserID = 0 };
            dataWork.SelectFields(x => new { x.id, x.unit_name });
            dataWork.OrderByFields(x => x.sort);
            return dataWork.DataByAdapter().dicMakeKeyValue(0, 1);
        }
    }
    public class m_PowerUnit : ModuleBase
    {
        public int unit { get; set; }
        public int prog { get; set; }
        public int power { get; set; }
        public Boolean check { get; set; }
    }
    #endregion
    #region Power for users
    public class q_PowerUser : QueryBase
    {
        public int user { get; set; }
    }
    public class a_PowerUser : LogicBase
    {
        public RunUpdateEnd UpdateMaster(m_PowerUser md, string AccountID)
        {
            RunUpdateEnd r = new RunUpdateEnd();
            _PowerUsers TObj = new _PowerUsers();
            try
            {
                Connection.BeginTransaction();
                TablePack<_PowerUsers> dataWork = new TablePack<_PowerUsers>(Connection) { TableModule = TObj };
                if (md.check)
                {
                    //新增
                    dataWork.NewRow();
                    dataWork.SetDataRowValue(x => x.ProgID, md.prog);
                    dataWork.SetDataRowValue(x => x.PowerID, md.power);
                    dataWork.SetDataRowValue(x => x.UserID, md.user);
                    dataWork.SetDataRowValue(x => x.UnitID, 1);
                    dataWork.AddRow();
                    dataWork.UpdateDataAdapter();
                }
                else
                {
                    //刪除
                    dataWork.WhereFields(x => x.ProgID, md.prog);
                    dataWork.WhereFields(x => x.PowerID, md.power);
                    dataWork.WhereFields(x => x.UserID, md.user);

                    DataTable dt_Origin = dataWork.DataByAdapter();
                    dataWork.DeleteAll();
                    dataWork.UpdateDataAdapter();
                }

                Connection.EndCommit();
                r.Result = true;
                return r;
            }
            catch (LogicRoll ex)
            {
                Connection.Rollback();

                r.Result = false;
                r.ErrType = BusinessErrType.Logic;
                r.Message = ex.Message;
                return r;
            }
            catch (Exception ex)
            {
                Connection.Rollback();
                r.Result = false;
                r.ErrType = BusinessErrType.System;
                r.Message = PackErrMessage(ex);
                return r;
            }
            finally
            {

            }

        }
        public RunQueryPackage<m_PowerMaster> SearchMaster(q_PowerUser qr, int AccountID)
        {
            RunQueryPackage<m_PowerMaster> r = new RunQueryPackage<m_PowerMaster>();
            _PowerUnit TObj = new _PowerUnit();
            try
            {
                PowerManagement PowerMG = new PowerManagement(); //計算所需要顯示的權限

                TablePack<ProgData> dataWork = new TablePack<ProgData>(Connection) { TableModule = new ProgData() };
                dataWork.SelectFields(x => new { x.id, x.prog_name, x.isfolder, x.power_serial });
                dataWork.WhereFields(x => x.isfolder, false);
                dataWork.OrderByFields(x => x.sort);

                m_ProgData[] m_progdatas = dataWork.DataByAdapter<m_ProgData>();

                TablePack<_PowerUsers> PowerUserWork = new TablePack<_PowerUsers>(Connection) { TableModule = new _PowerUsers() };
                PowerUserWork.TableModule.ProgID.Alias = "prog";
                PowerUserWork.TableModule.PowerID.Alias = "power";

                PowerUserWork.SelectFields(x => new { x.ProgID, x.PowerID });
                PowerUserWork.WhereFields(x => x.UserID, qr.user);

                m_PowerUser[] PowerQuery = PowerUserWork.DataByAdapter<m_PowerUser>();

                List<m_PowerMaster> k = new List<m_PowerMaster>();

                foreach (var dr in m_progdatas)
                {
                    PowerMG.PowerSerial = dr.power_serial;

                    m_PowerMaster pm = new m_PowerMaster();
                    pm.progid = dr.id;
                    pm.progname = dr.prog_name;

                    foreach (Power p in pm.Powers)
                    {
                        p.IsManagement = PowerMG.Powers.Single(x => x.Id == p.Id).IsManagement;
                        p.HavePower = PowerQuery.Where(x => x.prog == dr.id && x.power == p.Id).Count() > 0;
                    }
                    k.Add(pm);
                }

                r.SearchData = k.ToArray();
                r.Result = true;
                return r;
            }
            catch (LogicRoll ex)
            {
                r.Result = false;
                r.ErrType = BusinessErrType.Logic;
                r.Message = ex.Message;
                return r;
            }
            catch (Exception ex)
            {
                r.Result = false;
                r.ErrType = BusinessErrType.System;
                r.Message = PackErrMessage(ex);
                return r;
            }

        }
        public Dictionary<String, String> CollectKeyValueData_Users()
        {
            UserData TObj = new UserData();
            TablePack<UserData> dataWork = new TablePack<UserData>(Connection) { TableModule = TObj };

            dataWork.SelectFields(x => x.id);
            dataWork.SelectFields(x => x.user_name);
            dataWork.WhereFields(x => x.id, 1, WhereCompareType.UnEquel);
            dataWork.OrderByFields(x => x.id);

            DataTable dt = dataWork.DataByAdapter();
            return dt.dicMakeKeyValue(0, 1);
        }
    }
    public class m_PowerUser : ModuleBase
    {
        public int prog { get; set; }
        public int power { get; set; }
        public int user { get; set; }

        public Boolean check { get; set; }
    }
    #endregion
    #region ProgData
    public class a_WebInfo : LogicBase
    {
        public m_ProgData GetSystemInfo(String area, String controller, String action)
        {
            m_ProgData md = new m_ProgData();

            ProgData TObj = new ProgData();
            TablePack<ProgData> dataWork = new TablePack<ProgData>(Connection) { TableModule = TObj };

            if (!String.IsNullOrEmpty(area))
            {
                dataWork.WhereFields(x => x.area, area);
            }

            if (!String.IsNullOrEmpty(controller))
            {
                dataWork.WhereFields(x => x.controller, controller);
            }

            if (!String.IsNullOrEmpty(action))
            {
                dataWork.WhereFields(x => x.action, action);
            }

            DataTable dt = dataWork.DataByAdapter();
            if (dt.Rows.Count > 0)
            {
                md.prog_name = dt.Rows[0][TObj.prog_name.N].ToString();
                md.id = dt.Rows[0][TObj.id.N].CInt();
                return md;
            }
            else
            {
                return md;
            }
        }
    }
    public class q_ProgData : QueryBase
    {
        public string s_prog_name { set; get; }
        public string s_controller { set; get; }
        public string s_area { set; get; }
    }
    public class n_ProgData : SubQueryBase
    {
    }
    public class m_ProgData : ModuleBase
    {
        public int id { get; set; }
        public String area { get; set; }
        public String controller { get; set; }
        public String action { get; set; }
        public String path { get; set; }
        public String page { get; set; }
        public String prog_name { get; set; }
        public String sort { get; set; }
        public Boolean isfolder { get; set; }
        public Boolean ishidden { get; set; }
        public Boolean isRoute { get; set; }
        public Boolean ismb { get; set; }
        public int power_serial { get; set; }
        public PowerManagement PowerItem { get; set; }
        public List<int> GetPowerItems { get; set; }

    }
    public class a_ProgData : LogicBase<m_ProgData, q_ProgData, ProgData>
    {
        public override RunInsertEnd InsertMaster(m_ProgData md, int AccountID)
        {
            #region Declare area
            RunInsertEnd r = new RunInsertEnd(); //宣告回傳物件
            #endregion
            try
            {
                #region main working
                Connection.BeginTransaction(); //開始交易鎖定
                TablePack<ProgData> dataWork = new TablePack<ProgData>(Connection) { LoginUserID = AccountID };

                dataWork.NewRow(); //開始新橧作業 產生新的一行
                #region 指派值

                dataWork.SetDataRowValue(x => x.id, md.id);
                dataWork.SetDataRowValue(x => x.area, md.area);
                dataWork.SetDataRowValue(x => x.controller, md.controller);
                dataWork.SetDataRowValue(x => x.action, md.action);
                dataWork.SetDataRowValue(x => x.path, md.path);
                dataWork.SetDataRowValue(x => x.page, md.page);
                dataWork.SetDataRowValue(x => x.prog_name, md.prog_name);
                dataWork.SetDataRowValue(x => x.sort, md.sort);
                dataWork.SetDataRowValue(x => x.isfolder, md.isfolder);
                dataWork.SetDataRowValue(x => x.ishidden, md.ishidden);
                dataWork.SetDataRowValue(x => x.isRoute, md.isRoute);
                dataWork.SetDataRowValue(x => x.ismb, md.ismb);

                foreach (int i in md.GetPowerItems)
                {
                    md.power_serial += i;
                }

                dataWork.SetDataRowValue(x => x.power_serial, md.power_serial);
                dataWork.UpdateFieldsInfo(UpdateFieldsInfoType.Insert);
                #endregion
                dataWork.AddRow(); //加載至DataTable
                dataWork.UpdateDataAdapter(); //更新 DataBase Server

                Connection.EndCommit(); //交易確認

                r.Rows = dataWork.AffetCount; //取得影響筆數
                r.InsertId = dataWork.InsertAutoFieldsID; //取得新增後自動新增欄位的值
                r.Result = true; //回傳本次執行結果為成功

                return r;
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System;//系統執行失敗
                r.Message = PackErrMessage(ex); //回傳失敗訊息
                return r;
                #endregion
            }
        }
        public override RunUpdateEnd UpdateMaster(m_ProgData md, int AccountID)
        {
            RunUpdateEnd r = new RunUpdateEnd();
            try
            {
                Connection.BeginTransaction();
                TablePack<ProgData> dataWork = new TablePack<ProgData>(Connection) { LoginUserID = AccountID };

                dataWork.TableModule.KeyFieldModules[dataWork.TableModule.id.N].V = md.id; //取得ID欄位的值
                DataTable dt_Origin = dataWork.GetDataByKey(); //取得Key值的Data

                dataWork.EditFirstRow();
                #region 指派值
                dataWork.SetDataRowValue(x => x.area, md.area);
                dataWork.SetDataRowValue(x => x.controller, md.controller);
                dataWork.SetDataRowValue(x => x.action, md.action);
                dataWork.SetDataRowValue(x => x.path, md.path);
                dataWork.SetDataRowValue(x => x.page, md.page);
                dataWork.SetDataRowValue(x => x.prog_name, md.prog_name);
                dataWork.SetDataRowValue(x => x.sort, md.sort);
                dataWork.SetDataRowValue(x => x.isfolder, md.isfolder);
                dataWork.SetDataRowValue(x => x.ishidden, md.ishidden);
                dataWork.SetDataRowValue(x => x.isRoute, md.isRoute);

                foreach (int i in md.GetPowerItems)
                {
                    md.power_serial += i;
                }

                dataWork.SetDataRowValue(x => x.power_serial, md.power_serial);
                dataWork.UpdateFieldsInfo(UpdateFieldsInfoType.Update);
                #endregion
                dt_Origin.Dispose();
                dataWork.UpdateDataAdapter();

                Connection.EndCommit();

                r.Rows = dataWork.AffetCount;
                r.Result = true;

                return r;
            }
            catch (LogicRoll ex)
            {
                Connection.Rollback();

                r.Result = false;
                r.ErrType = BusinessErrType.Logic;
                r.Message = ex.Message;
                return r;
            }
            catch (Exception ex)
            {
                Connection.Rollback();
                r.Result = false;
                r.ErrType = BusinessErrType.System;
                r.Message = PackErrMessage(ex);
                return r;
            }
            finally
            {
            }

        }
        public override RunDeleteEnd DeleteMaster(Int32[] ids, int AccountID)
        {
            RunDeleteEnd r = new RunDeleteEnd();
            try
            {
                Connection.BeginTransaction();
                //1、要刪除的資料先選出來
                TablePack<ProgData> dataWork = new TablePack<ProgData>(Connection) { LoginUserID = AccountID };
                dataWork.SelectFields(x => x.id);
                dataWork.WhereFields(x => x.id, ids);

                DataTable dt_Origin = dataWork.DataByAdapter();

                //2、進行全部刪除
                dataWork.DeleteAll(); //先刪除DataTable
                dataWork.UpdateDataAdapter(); //在更新至DataBase Server
                Connection.EndCommit();
                r.Result = true;
                return r;
            }
            catch (LogicRoll ex)
            {
                Connection.Rollback();
                r.Result = false;
                r.ErrType = BusinessErrType.Logic;
                r.Message = ex.Message;
                return r;
            }
            catch (Exception ex)
            {
                Connection.Rollback();
                r.Result = false;
                r.ErrType = BusinessErrType.System;
                r.Message = PackErrMessage(ex);
                return r;
            }
        }

        public override RunQueryPackage<m_ProgData> SearchMaster(q_ProgData qr, int AccountID)
        {
            #region 全域變數宣告
            RunQueryPackage<m_ProgData> r = new RunQueryPackage<m_ProgData>();
            #endregion
            try
            {
                #region Select Data 區段 By 條件
                #region 設定輸出至Grid欄位 以下方式請注音 1、只適合單一Table 2、主要用於Grid顯示，如此方式不適合，可自行組SQL字串再夜由至ExecuteData達行
                TablePack<ProgData> dataWork = new TablePack<ProgData>(Connection) { LoginUserID = AccountID };

                dataWork.SelectFields(x => new { x.id, x.prog_name, x.isfolder, x.area, x.controller, x.sort, x.ismb });
                dataWork.TopLimit = 1000;
                #endregion
                #region 設定Where條件
                if (qr.s_prog_name != null)
                {
                    dataWork.WhereFields(x => x.prog_name, qr.s_prog_name, WhereCompareType.Like);
                }
                #endregion
                #region 設定排序
                if (qr.sidx == null)
                {
                    //預設排序
                    dataWork.OrderByFields(x => x.sort, OrderByType.ASC);
                }
                else
                {
                    dataWork.OrderByFields(x => x.sort, OrderByType.ASC);
                }
                #endregion
                #region 輸出成DataTable
                r.SearchData = dataWork.DataByAdapter<m_ProgData>();
                r.Result = true;
                return r;
                #endregion
                #endregion
            }
            catch (LogicRoll ex)
            {
                r.Result = false;
                r.ErrType = BusinessErrType.Logic;
                r.Message = ex.Message;
                return r;
            }
            catch (Exception ex)
            {
                r.Result = false;
                r.ErrType = BusinessErrType.System;
                r.Message = PackErrMessage(ex);
                return r;
            }

        }
        public RunQueryPackage<m_ProgData> SearchMasterLVL1(int AccountID)
        {
            #region 全域變數宣告
            RunQueryPackage<m_ProgData> r = new RunQueryPackage<m_ProgData>();
            #endregion
            try
            {
                #region Select Data 區段 By 條件
                #region 設定輸出至Grid欄位 以下方式請注音 1、只適合單一Table 2、主要用於Grid顯示，如此方式不適合，可自行組SQL字串再夜由至ExecuteData達行
                TablePack<ProgData> dataWork = new TablePack<ProgData>(Connection) { LoginUserID = AccountID };

                dataWork.SelectFields(x => x.id);
                dataWork.SelectFields(x => x.prog_name);
                dataWork.SelectFields(x => x.isfolder);
                dataWork.SelectFields(x => x.area);
                dataWork.SelectFields(x => x.controller);
                dataWork.SelectFields(x => x.sort);
                dataWork.SelectFields(x => x.ismb);
                dataWork.TopLimit = 100;
                #endregion
                #region 設定Where條件
                dataWork.WhereFields(x => x.isfolder, true);
                #endregion
                #region 設定排序
                dataWork.OrderByFields(x => x.sort);
                #endregion
                #region 輸出成DataTable
                r.SearchData = dataWork.DataByAdapter<m_ProgData>();
                r.Result = true;
                return r;
                #endregion
                #endregion
            }
            catch (LogicRoll ex)
            {
                r.Result = false;
                r.ErrType = BusinessErrType.Logic;
                r.Message = ex.Message;
                return r;
            }
            catch (Exception ex)
            {
                r.Result = false;
                r.ErrType = BusinessErrType.System;
                r.Message = PackErrMessage(ex);
                return r;
            }

        }
        public RunQueryPackage<m_ProgData> SearchMasterLVL2(n_ProgData qr, int AccountID)
        {
            #region 全域變數宣告
            RunQueryPackage<m_ProgData> r = new RunQueryPackage<m_ProgData>();
            #endregion
            try
            {
                #region Select Data 區段 By 條件
                #region 設定輸出至Grid欄位 以下方式請注意 1、只適合單一Table 2、主要用於Grid顯示，如此方式不適合，可自行組SQL字串再夜由至ExecuteData達行
                TablePack<ProgData> dataWork = new TablePack<ProgData>(Connection) { LoginUserID = AccountID };

                dataWork.SelectFields(x => x.sort);
                dataWork.TableModule.KeyFieldModules[dataWork.TableModule.id.N].V = qr.id;
                dataWork.TopLimit = 1;
                #endregion
                #region 設定Where條件
                #endregion

                #region 輸出Class
                m_ProgData md = dataWork.GetDataByKey<m_ProgData>();

                dataWork.Reset();
                dataWork.SelectFields(x => new { x.id, x.prog_name, x.isfolder, x.area, x.controller, x.sort });

                dataWork.WhereFields(x => x.sort, md.sort.Substring(0, 3), WhereCompareType.LikeRight);
                dataWork.WhereFields(x => x.isfolder, false);
                dataWork.OrderByFields(x => x.sort);

                r.SearchData = dataWork.DataByAdapter<m_ProgData>();
                r.Result = true;

                dataWork.Dispose();

                return r;
                #endregion
                #endregion
            }
            catch (LogicRoll ex)
            {
                r.Result = false;
                r.ErrType = BusinessErrType.Logic;
                r.Message = ex.Message;
                return r;
            }
            catch (Exception ex)
            {
                r.Result = false;
                r.ErrType = BusinessErrType.System;
                r.Message = PackErrMessage(ex);
                return r;
            }

        }

        public override RunOneDataEnd<m_ProgData> GetDataMaster(int id, int AccountID)
        {
            RunOneDataEnd<m_ProgData> r = new RunOneDataEnd<m_ProgData>();
            //md = new m_ProgData();
            try
            {
                TablePack<ProgData> dataWork = new TablePack<ProgData>(Connection) { };
                dataWork.TableModule.KeyFieldModules[dataWork.TableModule.id.N].V = id; //設定KeyValue
                m_ProgData md = dataWork.GetDataByKey<m_ProgData>(); //取得Key該筆資料

                if (md == null)
                    throw new LogicRoll("Log_Err_MustHaveData"); //此區一定有資料傳出，如無資料因檢查前端id值是否有誤

                md.PowerItem = new PowerManagement(md.power_serial);

                r.SearchData = md;
                r.Result = true;
                return r;
            }
            catch (LogicRoll ex)
            {
                r.Result = false;
                r.ErrType = BusinessErrType.Logic;
                r.Message = ex.Message;
                return r;
            }
            catch (Exception ex)
            {
                r.Result = false;
                r.ErrType = BusinessErrType.System;
                r.Message = PackErrMessage(ex);
                return r;
            }
        }
        public override RunOneDataEnd<m_ProgData> GetDataMaster(int[] id, int accountId)
        {
            throw new NotImplementedException();
        }
    }
    #endregion
    #region User
    public class Password : ModuleBase
    {
        public int id { get; set; }
        public string password_o { get; set; }
        public string password_n { get; set; }
        public string password_s { get; set; }
    }
    public class q_User : QueryBase
    {
        public string s_name { set; get; }
        public string s_account { set; get; }
    }
    public class m_User : ModuleBase
    {
        public int id { get; set; }
        public String account { get; set; }
        public String password { get; set; }
        public String user_name { get; set; }
        public int unit { get; set; }
        public String unit_name { get; set; }
        public String state { get; set; }
        public Boolean isadmin { get; set; }
        public String type { get; set; }
        public String email { get; set; }
    }
    public class a_User : LogicBase<m_User, q_User, UserData>
    {
        public RunUpdateEnd UpdateMasterPassword(Password pwd, string AccountID)
        {
            RunUpdateEnd r = new RunUpdateEnd();
            UserData TObj = new UserData();
            Connection.BeginTransaction();

            try
            {
                TablePack<UserData> dataWork = new TablePack<UserData>(Connection) { TableModule = TObj };

                dataWork.SelectFields(x => new { user_id = x.id, x.password });
                dataWork.WhereFields(x => x.id, pwd.id);

                m_User md = dataWork.DataByAdapter<m_User>().FirstOrDefault();

                String GetNowPassword = md.password;

                if (GetNowPassword != pwd.password_o)
                    throw new LogicRoll("Log_Err_Password");

                if (GetNowPassword == pwd.password_n)
                    throw new LogicRoll("Log_Err_NewPasswordSame");

                if (pwd.password_s != pwd.password_n)
                    throw new LogicRoll("Log_Err_NewPasswordNotSure");

                dataWork.EditFirstRow();
                dataWork.SetDataRowValue(x => x.password, pwd.password_n);
                //dataWork.UpdateFieldsInfo(UpdateFieldsInfoType.Update);
                dataWork.UpdateDataAdapter();

                Connection.EndCommit();
                r.Result = true;
                return r;
            }
            catch (LogicRoll ex)
            {
                Connection.Rollback();

                r.Result = false;
                r.ErrType = BusinessErrType.Logic;
                r.Message = ex.Message;
                return r;
            }
            catch (Exception ex)
            {
                Connection.Rollback();
                r.Result = false;
                r.ErrType = BusinessErrType.System;
                r.Message = PackErrMessage(ex);
                return r;
            }
        }
        public LoginSate SystemLogin(String account, String password)
        {
            UserData TObj = new UserData();
            TablePack<UserData> dataWork = new TablePack<UserData>(Connection) { TableModule = TObj };
            LoginSate loginState = new LoginSate();
            try
            {
                dataWork.SelectFields(x => x.id);
                dataWork.SelectFields(x => x.account);
                dataWork.SelectFields(x => x.password);
                dataWork.SelectFields(x => x.user_name);
                dataWork.SelectFields(x => x.unit_id);
                dataWork.SelectFields(x => x.state);
                dataWork.SelectFields(x => x.isadmin);

                dataWork.WhereFields(x => x.account, account);
                dataWork.WhereFields(x => x.password, password);

                DataTable dt = dataWork.DataByAdapter();

                if (dt.Rows.Count == 0)
                    throw new LogicRoll("Login_Err_Password");

                if (dt.Rows[0][TObj.state.N].ToString() != "Normal")
                    throw new LogicRoll("Login_Err_Normal");

                else
                {
                    loginState.Id = (int)dt.Rows[0][TObj.id.N];
                    loginState.IsAdmin = (Boolean)dt.Rows[0][TObj.isadmin.N];
                    loginState.Unit = (int)dt.Rows[0][TObj.unit_id.N];
                    loginState.Result = true;
                    loginState.Acccount = (String)dt.Rows[0][TObj.account.N];

                    Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, "登入檢查完成。");

                    return loginState;
                }
            }
            catch (LogicRoll ex)
            {
                loginState.Result = false;
                loginState.ErrType = BusinessErrType.Logic;
                loginState.Message = ex.Message;
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return loginState;
            }
            catch (Exception ex)
            {
                loginState.Result = false;
                loginState.ErrType = BusinessErrType.System;
                loginState.Message = PackErrMessage(ex);
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return loginState;
            }
        }
        public override RunInsertEnd InsertMaster(m_User md, int AccountID)
        {
            RunInsertEnd r = new RunInsertEnd();

            UserData TObj = new UserData();

            try
            {
                Connection.BeginTransaction();
                TablePack<UserData> dataWork = new TablePack<UserData>(Connection) { TableModule = TObj };

                dataWork.NewRow();

                dataWork.SetDataRowValue(x => x.id, md.id);
                dataWork.SetDataRowValue(x => x.account, md.account);
                dataWork.SetDataRowValue(x => x.password, md.password);
                dataWork.SetDataRowValue(x => x.user_name, md.user_name);
                dataWork.SetDataRowValue(x => x.unit_id, md.unit);
                dataWork.SetDataRowValue(x => x.state, md.state);
                dataWork.SetDataRowValue(x => x.isadmin, md.isadmin);
                dataWork.SetDataRowValue(x => x.type, md.type);
                dataWork.SetDataRowValue(x => x.email, md.email);


                dataWork.UpdateFieldsInfo(UpdateFieldsInfoType.Insert);

                dataWork.AddRow();

                dataWork.UpdateDataAdapter();
                Connection.EndCommit();

                r.Rows = dataWork.AffetCount; //取得影響筆數
                r.InsertId = dataWork.InsertAutoFieldsID; //取得新增後自動新增欄位的值

                r.Result = true;

                return r;
            }
            catch (LogicRoll ex)
            {
                Connection.Rollback();
                r.Result = false;
                r.ErrType = BusinessErrType.Logic;
                r.Message = ex.Message;
                return r;
            }
            catch (Exception ex)
            {
                Connection.Rollback();
                r.Result = false;
                r.ErrType = BusinessErrType.System;
                r.Message = PackErrMessage(ex);
                return r;
            }

        }
        public override RunUpdateEnd UpdateMaster(m_User md, int AccountID)
        {
            RunUpdateEnd r = new RunUpdateEnd();
            Connection.BeginTransaction();
            UserData TObj = new UserData();
            try
            {
                TablePack<UserData> dataWork = new TablePack<UserData>(Connection) { TableModule = TObj };
                dataWork.TableModule.KeyFieldModules[TObj.id.N].V = md.id; //取得ID欄位的值
                DataTable dt_Origin = dataWork.GetDataByKey(); //取得Key值的Data

                dataWork.EditFirstRow();

                dataWork.SetDataRowValue(x => x.user_name, md.user_name);
                dataWork.SetDataRowValue(x => x.unit_id, md.unit);
                dataWork.SetDataRowValue(x => x.state, md.state);
                dataWork.SetDataRowValue(x => x.isadmin, md.isadmin);
                dataWork.SetDataRowValue(x => x.type, md.type);
                dataWork.SetDataRowValue(x => x.email, md.email);

                dataWork.UpdateDataAdapter();
                Connection.EndCommit();

                r.Rows = dataWork.AffetCount;
                r.Result = true;

                return r;
            }
            catch (LogicRoll ex)
            {
                Connection.Rollback();

                r.Result = false;
                r.ErrType = BusinessErrType.Logic;
                r.Message = ex.Message;
                return r;
            }
            catch (Exception ex)
            {
                Connection.Rollback();
                r.Result = false;
                r.ErrType = BusinessErrType.System;
                r.Message = PackErrMessage(ex);
                return r;
            }
            finally
            {
            }
        }
        public RunDeleteEnd DeleteMaster(String[] DeleteID, int AccountID)
        {
            RunDeleteEnd r = new RunDeleteEnd();
            UserData TObj = new UserData();
            Connection.BeginTransaction();

            try
            {
                //1、要刪除的資料先選出來
                TablePack<UserData> dataWork = new TablePack<UserData>(Connection) { TableModule = TObj };
                dataWork.SelectFields(x => x.id);
                dataWork.WhereFields(x => x.id, DeleteID);

                DataTable dt_Origin = dataWork.DataByAdapter();

                //2、進行全部刪除
                dataWork.DeleteAll(); //先刪除DataTable
                dataWork.UpdateDataAdapter(); //在更新至DataBase Server
                Connection.EndCommit();
                r.Result = true;
                return r;
            }
            catch (LogicRoll ex)
            {
                Connection.Rollback();
                r.Result = false;
                r.ErrType = BusinessErrType.Logic;
                r.Message = ex.Message;
                return r;
            }
            catch (Exception ex)
            {
                Connection.Rollback();
                r.Result = false;
                r.ErrType = BusinessErrType.System;
                r.Message = PackErrMessage(ex);
                return r;
            }
        }
        public override RunQueryPackage<m_User> SearchMaster(q_User qr, Int32 AccountID)
        {
            #region 全域變數宣告
            RunQueryPackage<m_User> r = new RunQueryPackage<m_User>();
            UserData TObj = new UserData();
            #endregion

            try
            {
                #region Select Data 區段 By 條件

                #region 設定輸出至Grid欄位 以下方式請注音 1、只適合單一Table 2、主要用於Grid顯示，如此方式不適合，可自行組SQL字串再夜由至ExecuteData達行
                Table2Join<UserData, UnitData> dataWork = new Table2Join<UserData, UnitData>(Connection) { Table1Module1 = new UserData(), Table1Module2 = new UnitData() };
                dataWork.SelectFields((x, y) => new { user_id = x.id, x.account, x.user_name, y.unit_name, x.state, x.isadmin });
                dataWork.JoinField(x => x.unit_id, y => y.id, JoinType.Inner);
                #endregion

                #region 設定Where條件
                //系統帳號不列出
                dataWork.WhereFields((x, y) => x.id, 1, WhereCompareType.UnEquel);
                if (qr.s_account != null)
                {
                    dataWork.WhereFields((x, y) => x.account, qr.s_account);
                }

                if (qr.s_name != null)
                {
                    dataWork.WhereFields((x, y) => x.user_name, qr.s_name, WhereCompareType.Equel);
                }
                #endregion

                #region 設定排序
                if (qr.sidx == null)
                {
                    //預設排序
                    dataWork.OrderByFields((x, y) => x.id, OrderByType.DESC);
                }
                else
                {
                    dataWork.OrderByFields((x, y) => x.id, OrderByType.ASC);
                }
                #endregion

                #region 輸出成DataTable
                r.SearchData = dataWork.DataByAdapter<m_User>();
                r.Result = true;
                return r;
                #endregion

                #endregion
            }

            catch (LogicRoll ex)
            {
                #region 羅輯錯誤區區段
                r.Result = false;
                r.ErrType = BusinessErrType.Logic;
                r.Message = ex.Message;
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region 系統錯誤區
                r.Result = false;
                r.ErrType = BusinessErrType.System;
                r.Message = PackErrMessage(ex);
                return r;
                #endregion
            }
        }
        public override RunOneDataEnd<m_User> GetDataMaster(int id, int AccountID)
        {
            RunOneDataEnd<m_User> r = new RunOneDataEnd<m_User>();

            try
            {
                // 取得Table物件 簡化長度
                UserData TObj = new UserData();

                TablePack<UserData> dataWork = new TablePack<UserData>(Connection) { TableModule = TObj };
                TObj.KeyFieldModules[TObj.id.N].V = id; //設定KeyValue
                r.SearchData = dataWork.GetDataByKey<m_User>(); //取得Key該筆資料

                if (r.SearchData == null) //如有資料
                    throw new LogicRoll("Log_Err_MustHaveData"); //此區一定有資料傳出，如無資料因檢查前端id值是否有誤

                r.Result = true;
                return r;
            }
            catch (LogicRoll ex)
            {
                r.Result = false;
                r.ErrType = BusinessErrType.Logic;
                r.Message = ex.Message;
                return r;
            }
            catch (Exception ex)
            {
                r.Result = false;
                r.ErrType = BusinessErrType.System;
                r.Message = PackErrMessage(ex);
                return r;
            }
        }
        public override RunDeleteEnd DeleteMaster(int[] ids, int accountId)
        {
            throw new NotImplementedException();
        }
        public override RunOneDataEnd<m_User> GetDataMaster(int[] ids, int accountId)
        {
            throw new NotImplementedException();
        }

        public Boolean Exists_Account(String account, int accountId)
        {
            RunQueryPackage<m_User> r = new RunQueryPackage<m_User>();
            TablePack<UserData> dataWork = new TablePack<UserData>(Connection) { LoginUserID = accountId };
            dataWork.SelectFields(x => new { user_id = x.id });
            dataWork.WhereFields(x => x.account, account);

            r.SearchData = dataWork.DataByAdapter<m_User>();
            r.Result = true;
            return r.SearchData.Count() > 0;
        }
        public Dictionary<String, String> MakeOption_Unit()
        {
            UnitData TObj = new UnitData();

            TablePack<UnitData> dataWork = new TablePack<UnitData>(Connection) { TableModule = TObj };

            dataWork.SelectFields(x => x.id);
            dataWork.SelectFields(x => x.unit_name);
            dataWork.OrderByFields(x => x.sort, OrderByType.ASC);

            return dataWork.DataByAdapter().dicMakeKeyValue(0, 1);
        }
        public Dictionary<String, String> MakeOption_UsersState()
        {
            return CodeSheet.UserState.ToDictionary();
        }
    }
    #endregion
    #region Unit
    public class q_Unit : QueryBase
    {
        public string s_name { set; get; }
    }

    public class m_Unit : ModuleBase
    {
        public int id { get; set; }
        public String unit_name { get; set; }
        public int sort { get; set; }
    }

    public class a_Unit : LogicBase<m_Unit, q_Unit, UnitData>
    {
        public override RunInsertEnd InsertMaster(m_Unit md, int AccountID)
        {
            RunInsertEnd r = new RunInsertEnd();
            Connection.BeginTransaction();
            UnitData TObj = new UnitData();
            try
            {
                TablePack<UnitData> dataWork = new TablePack<UnitData>(Connection) { TableModule = TObj };

                dataWork.NewRow(); //開始新橧作業 產生新的一行
                #region 指派值
                dataWork.SetDataRowValue(x => x.id, md.id);
                dataWork.SetDataRowValue(x => x.unit_name, md.unit_name);
                dataWork.SetDataRowValue(x => x.sort, md.sort);
                #endregion
                dataWork.AddRow(); //加載至DataTable
                dataWork.UpdateDataAdapter(); //更新 DataBase Server

                Connection.EndCommit();

                r.Rows = dataWork.AffetCount; //取得影響筆數
                r.InsertId = dataWork.InsertAutoFieldsID; //取得新增後自動新增欄位的值
                r.Result = true; //回傳本次執行結果為成功

                return r;
            }
            catch (LogicRoll ex)
            {
                Connection.Rollback();
                r.Result = false;
                r.ErrType = BusinessErrType.Logic;
                r.Message = ex.Message;
                return r;
            }
            catch (Exception ex)
            {
                Connection.Rollback();
                r.Result = false;
                r.ErrType = BusinessErrType.System;
                r.Message = PackErrMessage(ex);
                return r;
            }
        }
        public override RunUpdateEnd UpdateMaster(m_Unit md, int AccountID)
        {
            RunUpdateEnd r = new RunUpdateEnd();
            Connection.BeginTransaction();
            UnitData TObj = new UnitData();
            try
            {
                TablePack<UnitData> dataWork = new TablePack<UnitData>(Connection) { TableModule = TObj };

                dataWork.TableModule.KeyFieldModules[TObj.id.N].V = md.id; //取得ID欄位的值
                DataTable dt_Origin = dataWork.GetDataByKey(); //取得Key值的Data

                dataWork.EditFirstRow();
                #region 指派值
                dataWork.SetDataRowValue(x => x.unit_name, md.unit_name);
                dataWork.SetDataRowValue(x => x.sort, md.sort);

                dataWork.UpdateFieldsInfo(UpdateFieldsInfoType.Update);
                #endregion
                dt_Origin.Dispose();
                dataWork.UpdateDataAdapter();

                Connection.EndCommit();

                r.Rows = dataWork.AffetCount;
                r.Result = true;

                return r;
            }
            catch (LogicRoll ex)
            {
                Connection.Rollback();

                r.Result = false;
                r.ErrType = BusinessErrType.Logic;
                r.Message = ex.Message;
                return r;
            }
            catch (Exception ex)
            {
                Connection.Rollback();
                r.Result = false;
                r.ErrType = BusinessErrType.System;
                r.Message = PackErrMessage(ex);
                return r;
            }
            finally
            {
            }

        }
        public RunDeleteEnd DeleteMaster(String[] DeleteID, int AccountID)
        {
            RunDeleteEnd r = new RunDeleteEnd();
            Connection.BeginTransaction();
            UnitData TObj = new UnitData();
            try
            {
                //1、要刪除的資料先選出來
                TablePack<UnitData> dataWork = new TablePack<UnitData>(Connection) { TableModule = TObj };
                dataWork.SelectFields(x => x.id);
                dataWork.WhereFields(x => x.id, DeleteID);

                DataTable dt_Origin = dataWork.DataByAdapter();

                //2、進行全部刪除
                dataWork.DeleteAll(); //先刪除DataTable
                dataWork.UpdateDataAdapter(); //在更新至DataBase Server
                Connection.EndCommit();
                r.Result = true;
                return r;
            }
            catch (LogicRoll ex)
            {
                Connection.Rollback();
                r.Result = false;
                r.ErrType = BusinessErrType.Logic;
                r.Message = ex.Message;
                return r;
            }
            catch (Exception ex)
            {
                Connection.Rollback();
                r.Result = false;
                r.ErrType = BusinessErrType.System;
                r.Message = PackErrMessage(ex);
                return r;
            }
        }
        public override RunQueryPackage<m_Unit> SearchMaster(q_Unit qr, int AccountID)
        {
            #region 全域變數宣告
            RunQueryPackage<m_Unit> r = new RunQueryPackage<m_Unit>();
            #endregion

            try
            {
                #region Select Data 區段 By 條件

                #region 設定輸出至Grid欄位 以下方式請注音 1、只適合單一Table 2、主要用於Grid顯示，如此方式不適合，可自行組SQL字串再夜由至ExecuteData達行
                TablePack<UnitData> dataWork = new TablePack<UnitData>(Connection) { TableModule = new UnitData() };
                dataWork.SelectFields(x => new { unit_id = x.id, x.unit_name, x.sort });
                #endregion

                #region 設定Where條件
                if (qr.s_name != null)
                {
                    dataWork.WhereFields(x => x.unit_name, qr.s_name, WhereCompareType.Like);
                }
                #endregion

                #region 設定排序
                if (qr.sidx == null)
                {
                    //預設排序
                    dataWork.OrderByFields(x => x.sort, OrderByType.DESC);
                }
                else
                {
                    dataWork.OrderByFields(x => x.sort, OrderByType.ASC);
                }
                #endregion

                #region 輸出成DataTable
                r.SearchData = dataWork.DataByAdapter<m_Unit>();
                r.Result = true;
                return r;
                #endregion

                #endregion
            }

            catch (LogicRoll ex)
            {
                #region 羅輯錯誤區區段
                r.Result = false;
                r.ErrType = BusinessErrType.Logic;
                r.Message = ex.Message;
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region 系統錯誤區
                r.Result = false;
                r.ErrType = BusinessErrType.System;
                r.Message = PackErrMessage(ex);
                return r;
                #endregion
            }
        }
        public override RunOneDataEnd<m_Unit> GetDataMaster(int[] ids, int accountId)
        {
            throw new NotImplementedException();
        }
        public override RunOneDataEnd<m_Unit> GetDataMaster(int id, int AccountID)
        {
            RunOneDataEnd<m_Unit> r = new RunOneDataEnd<m_Unit>();
            string sql = string.Empty;
            m_Unit md = new m_Unit();
            try
            {
                // 取得Table物件 簡化長度
                UnitData TObj = new UnitData();

                TablePack<UnitData> dataWork = new TablePack<UnitData>(Connection) { TableModule = TObj };
                TObj.KeyFieldModules[TObj.id.N].V = id; //設定KeyValue
                r.SearchData = dataWork.GetDataByKey<m_Unit>(); //取得Key該筆資料

                if (r.SearchData == null) //如有資料
                    throw new LogicRoll("Log_Err_MustHaveData"); //此區一定有資料傳出，如無資料因檢查前端id值是否有誤


                r.Result = true;
                return r;
            }
            catch (LogicRoll ex)
            {
                r.Result = false;
                r.ErrType = BusinessErrType.Logic;
                r.Message = ex.Message;
                return r;
            }
            catch (Exception ex)
            {
                r.Result = false;
                r.ErrType = BusinessErrType.System;
                r.Message = PackErrMessage(ex);
                return r;
            }
        }
        public override RunDeleteEnd DeleteMaster(int[] ids, int accountId)
        {
            throw new NotImplementedException();
        }

    }
    #endregion
    #region _Lang
    /// <summary>
    /// 查詢表單模組
    /// </summary>
    public class q__Lang : QueryBase
    {
        public String s_lang { get; set; }
        public Boolean? s_isuse { get; set; }
    }
    public class m__Lang : ModuleBase
    {
        public String lang { get; set; }
        public String area { get; set; }
        public String memo { get; set; }
        public Boolean isuse { get; set; }
        public Byte sort { get; set; }
    }
    /// <summary>
    /// The _Lang system database communicate module.   
    /// </summary>
    public class a__Lang : LogicBase<m__Lang, q__Lang, _Lang>
    {
        public override RunInsertEnd InsertMaster(m__Lang md, int accountId)
        {
            throw new NotImplementedException();
        }
        public override RunUpdateEnd UpdateMaster(m__Lang md, int accountId)
        {
            throw new NotImplementedException();
        }
        public override RunDeleteEnd DeleteMaster(int[] ids, int accountId)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// _Lang Table進行動態多條件查詢資料動作。
        /// </summary>
        /// <param name="qr">>傳入q__Lang class，class需先行建立(new)，其class各項屬性值需指定完成再行傳入</param>
        /// <param name="accountId">傳入Login使用者Id值</param>
        /// <returns>回傳RunQueryPackage<m__Lang>m__Lang</m__Lang> class，請參閱RunQueryPackage說明。</returns>
        public override RunQueryPackage<m__Lang> SearchMaster(q__Lang qr, int accountId)
        {
            #region 變數宣告
            RunQueryPackage<m__Lang> r = new RunQueryPackage<m__Lang>();
            #endregion
            try
            {
                #region Select Data 區段 By 條件
                #region 設定輸出至Grid欄位 以下方式請注意 1、只適合單一Table 2、主要用於Grid顯示，如此方式不適合，可自行組SQL字串再夜由至ExecuteData執行
                TablePack<_Lang> dataWork = new TablePack<_Lang>(Connection) { LoginUserID = accountId };
                dataWork.SelectFields(x => new { x.lang, x.area });
                #endregion

                #region 設定Where條件

                if (qr.s_isuse != null)
                    dataWork.WhereFields(x => x.isuse, qr.s_isuse);

                if (qr.s_lang != null)
                    dataWork.WhereFields(x => x.lang, qr.s_lang);

                #endregion

                #region 設定排序
                dataWork.OrderByFields(x => x.sort); //預設排序

                #endregion

                #region 輸出物件陣列
                r.SearchData = dataWork.DataByAdapter<m__Lang>();
                r.Result = true;
                return r;
                #endregion
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        /// <summary>
        /// _Lang Table進行主鍵值查詢資料動作。
        /// </summary>
        /// <param name="id">傳入主鍵Value</param>
        /// <param name="accountId">傳入Login使用者Id值</param>
        /// <returns>回傳RunOneDataEnd<m__Lang>m__Lang</m__Lang> class，請參閱RunOneDataEnd說明。</returns>
        public override RunOneDataEnd<m__Lang> GetDataMaster(int id, int accountId)
        {
            #region 變數宣告
            RunOneDataEnd<m__Lang> r = new RunOneDataEnd<m__Lang>();

            #endregion
            try
            {
                #region Main working
                TablePack<_Lang> dataWork = new TablePack<_Lang>(Connection) { LoginUserID = accountId };
                //dataWork.TableModule.KeyFieldModules[dataWork.TableModule.id.N].V = id; //設定KeyValue
                m__Lang md = dataWork.GetDataByKey<m__Lang>(); //取得Key該筆資料

                if (md == null) //如無資料
                    throw new LogicRoll("Log_Err_MustHaveData"); //此區一定有資料傳出，如無資料應檢查前端id值是否有誤

                r.SearchData = md;
                r.Result = true;
                dataWork.Dispose(); //釋放資料
                return r;
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        public override RunOneDataEnd<m__Lang> GetDataMaster(int[] id, int accountId)
        {
            throw new NotImplementedException();
        }
    }
    #endregion
    #region _WebVisitData
    /// <summary>
    /// 查詢表單模組
    /// </summary>
    public class q__WebVisitData : QueryBase
    {
        public String s_title { set; get; }
    }
    /// <summary>
    /// 系統資料結構描述模組    /// </summary>

    public class m__WebVisitData : ModuleBase
    {
        public Int32 id { get; set; }
        public String ip { get; set; }
        public DateTime setdate { get; set; }
        public String browser { get; set; }
        public String source { get; set; }
        public String page { get; set; }
    }

    /// <summary>
    /// The _WebVisitData system database communicate module.   /// </summary>
    public class a__WebVisitData : LogicBase<m__WebVisitData, q__WebVisitData, _WebVisitData>
    {
        /// <summary>
        /// _WebVisitData Table進行新增資料動作。
        /// </summary>
        /// <param name="md">傳入m__WebVisitData class，class需先行建立(new)，其class各項屬性值需指定完成再行傳入</param>
        /// <param name="accountId">傳入Login使用者Id值</param>
        /// <returns>回傳RunInsertEnd class，請參閱RunInsertEnd說明。</returns>
        public override RunInsertEnd InsertMaster(m__WebVisitData md, int accountId)
        {
            #region Variable declare area
            RunInsertEnd r = new RunInsertEnd(); //宣告回傳物件
            #endregion
            try
            {
                #region Main working
                Connection.BeginTransaction(); //開始交易鎖定
                TablePack<_WebVisitData> dataWork = new TablePack<_WebVisitData>(Connection) { LoginUserID = accountId };

                dataWork.NewRow(); //開始新橧作業 產生新的一行
                #region 指派值

                dataWork.SetDataRowValue(x => x.id, md.id);
                dataWork.SetDataRowValue(x => x.ip, md.ip);
                dataWork.SetDataRowValue(x => x.setdate, md.setdate);
                dataWork.SetDataRowValue(x => x.browser, md.browser);
                dataWork.SetDataRowValue(x => x.source, md.source);
                dataWork.SetDataRowValue(x => x.page, md.page);

                //dataWork.UpdateFieldsInfo(UpdateFieldsInfoType.Insert);
                //進行更新時 需同時更新系統欄位 _InsertUserID，_InsertDateTime
                #endregion
                dataWork.AddRow(); //加載至DataTable
                dataWork.UpdateDataAdapter(); //更新 DataBase Server

                Connection.EndCommit(); //交易確認

                r.Rows = dataWork.AffetCount; //取得影響筆數
                r.InsertId = dataWork.InsertAutoFieldsID; //取得新增後自動新增欄位的值
                r.Result = true; //回傳本次執行結果為成功
                dataWork.Dispose(); //釋放資料

                return r;
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼

                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);

                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System;//系統執行失敗
                r.Message = PackErrMessage(ex); //回傳失敗訊息
                return r;
                #endregion
            }
        }
        /// <summary>
        /// _WebVisitData Table進行更新資料動作。
        /// </summary>
        /// <param name="md">傳入m__WebVisitData class，class需先行建立(new)，其class各項屬性值需指定完成再行傳入</param>
        /// <param name="accountId">傳入Login使用者Id值</param>
        /// <returns>回傳RunUpdateEnd class，請參閱RunUpdateEnd說明。</returns>
        public override RunUpdateEnd UpdateMaster(m__WebVisitData md, int accountId)
        {
            #region Variable declare area
            RunUpdateEnd r = new RunUpdateEnd();
            #endregion
            try
            {
                #region Main Working
                Connection.BeginTransaction();
                TablePack<_WebVisitData> dataWork = new TablePack<_WebVisitData>(Connection) { LoginUserID = accountId };

                dataWork.TableModule.KeyFieldModules[dataWork.TableModule.id.N].V = md.id; //取得ID欄位的值
                m__WebVisitData md_Origin = dataWork.GetDataByKey<m__WebVisitData>(); //取得Key值的Data

                if (md_Origin == null) //如有資料
                    throw new LogicRoll("Log_Err_MustHaveData"); //此區一定有資料傳出，如無資料應檢查前端id值是否有誤

                dataWork.EditFirstRow(); //編輯第一筆資料，正常只會有一筆資料。
                #region 指派值

                dataWork.SetDataRowValue(x => x.id, md.id);
                dataWork.SetDataRowValue(x => x.ip, md.ip);
                dataWork.SetDataRowValue(x => x.setdate, md.setdate);
                dataWork.SetDataRowValue(x => x.browser, md.browser);
                dataWork.SetDataRowValue(x => x.source, md.source);
                dataWork.SetDataRowValue(x => x.page, md.page);


                dataWork.UpdateFieldsInfo(UpdateFieldsInfoType.Update); //指定進行更新時 需同時更新系統欄位 _UpdateUserID，_UpdateDateTime
                #endregion
                md_Origin = null;
                dataWork.UpdateDataAdapter(); //進行變更至Database Server

                Connection.EndCommit();

                r.Rows = dataWork.AffetCount; //取得影響筆數
                r.Result = true;
                dataWork.Dispose(); //釋放資料
                return r;
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System;//系統執行失敗
                r.Message = PackErrMessage(ex); //回傳失敗訊息
                return r;
                #endregion
            }
        }
        /// <summary>
        /// _WebVisitData Table進行刪除資料動作。
        /// </summary>
        /// <param name="deleteIds">傳入要刪除資料的主鍵值，此適用該Table只有單一主鍵欄位。</param>
        /// <param name="accountId">傳入Login使用者Id值</param>
        /// <returns>回傳RunDeleteEnd class，請參閱RunDeleteEnd說明。</returns>
        public override RunDeleteEnd DeleteMaster(Int32[] ids, int accountId)
        {
            //此功能主要搭配Grid介面刪除功能製作
            #region Variable declare area
            RunDeleteEnd r = new RunDeleteEnd(); //宣告刪除Result回物件
            #endregion
            try
            {
                #region Main working
                Connection.BeginTransaction();
                //1、要刪除的資料先選出來
                TablePack<_WebVisitData> dataWork = new TablePack<_WebVisitData>(Connection) { LoginUserID = accountId }; //宣告泛型物件並連接Connection
                dataWork.SelectFields(x => x.id); //只Select 主Key欄位
                dataWork.WhereFields(x => x.id, ids); //代入陣列Id值

                m__WebVisitData[] md_Origin = dataWork.DataByAdapter<m__WebVisitData>(); //取得Key值的Data

                //2、進行全部刪除
                dataWork.DeleteAll(); //先刪除DataTable
                dataWork.UpdateDataAdapter(); //在更新至DataBase Server
                Connection.EndCommit();
                r.Result = true;
                dataWork.Dispose(); //釋放資料
                md_Origin = null;
                return r;
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System;//系統執行失敗
                r.Message = PackErrMessage(ex); //回傳失敗訊息
                return r;
                #endregion
            }
        }
        /// <summary>
        /// _WebVisitData Table進行動態多條件查詢資料動作。
        /// </summary>
        /// <param name="qr">>傳入q__WebVisitData class，class需先行建立(new)，其class各項屬性值需指定完成再行傳入</param>
        /// <param name="accountId">傳入Login使用者Id值</param>
        /// <returns>回傳RunQueryPackage<m__WebVisitData>m__WebVisitData</m__WebVisitData> class，請參閱RunQueryPackage說明。</returns>
        public override RunQueryPackage<m__WebVisitData> SearchMaster(q__WebVisitData qr, int accountId)
        {
            #region 變數宣告
            RunQueryPackage<m__WebVisitData> r = new RunQueryPackage<m__WebVisitData>();
            #endregion
            try
            {
                #region Select Data 區段 By 條件
                #region 設定輸出至Grid欄位 以下方式請注意 1、只適合單一Table 2、主要用於Grid顯示，如此方式不適合，可自行組SQL字串再夜由至ExecuteData執行
                TablePack<_WebVisitData> dataWork = new TablePack<_WebVisitData>(Connection) { LoginUserID = accountId };
                //dataWork.SelectFields(x => new { x.id, x., x.NewsKind, x.SetDate, x.IsOpen });
                #endregion

                #region 設定Where條件
                if (qr.s_title != null)
                    dataWork.WhereFields(x => x.ip, qr.s_title);
                #endregion

                #region 設定排序
                if (qr.sidx == null)
                {
                    //預設排序
                    dataWork.OrderByFields(x => x.id, OrderByType.DESC);
                }
                else
                {
                    dataWork.OrderByFields(x => x.id, OrderByType.ASC);
                }
                #endregion

                #region 輸出物件陣列
                r.SearchData = dataWork.DataByAdapter<m__WebVisitData>();
                r.Result = true;
                return r;
                #endregion
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System;//系統執行失敗
                r.Message = PackErrMessage(ex); //回傳失敗訊息
                return r;
                #endregion
            }
        }
        /// <summary>
        /// _WebVisitData Table進行主鍵值查詢資料動作。
        /// </summary>
        /// <param name="id">傳入主鍵Value</param>
        /// <param name="accountId">傳入Login使用者Id值</param>
        /// <returns>回傳RunOneDataEnd<m__WebVisitData>m__WebVisitData</m__WebVisitData> class，請參閱RunOneDataEnd說明。</returns>
        public override RunOneDataEnd<m__WebVisitData> GetDataMaster(int id, int accountId)
        {
            #region 變數宣告
            RunOneDataEnd<m__WebVisitData> r = new RunOneDataEnd<m__WebVisitData>();

            #endregion
            try
            {
                #region Main working
                TablePack<_WebVisitData> dataWork = new TablePack<_WebVisitData>(Connection) { LoginUserID = accountId };
                dataWork.TableModule.KeyFieldModules[dataWork.TableModule.id.N].V = id; //設定KeyValue
                m__WebVisitData md = dataWork.GetDataByKey<m__WebVisitData>(); //取得Key該筆資料

                if (md == null) //如無資料
                    throw new LogicRoll("Log_Err_MustHaveData"); //此區一定有資料傳出，如無資料應檢查前端id值是否有誤

                r.SearchData = md;
                r.Result = true;
                dataWork.Dispose(); //釋放資料
                return r;
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System;//系統執行失敗
                r.Message = PackErrMessage(ex); //回傳失敗訊息
                return r;
                #endregion
            }
        }
        public override RunOneDataEnd<m__WebVisitData> GetDataMaster(int[] id, int accountId)
        {
            throw new NotImplementedException();
        }
    }
    #endregion
    #region _WebCount
    /// <summary>
    /// 查詢表單模組
    /// </summary>
    public class q__WebCount : QueryBase
    {
        public Int32 s_Cnt { set; get; }
    }
    /// <summary>
    /// 系統資料結構描述模組    /// </summary>

    public class m__WebCount : ModuleBase
    {
        public Int32 Cnt { get; set; }
    }

    /// <summary>
    /// The _WebVisitData system database communicate module.   /// </summary>
    public class a__WebCount : LogicBase
    {
        public RunUpdateEnd UpdateMaster(int accountId)
        {
            #region Variable declare area
            RunUpdateEnd r = new RunUpdateEnd();
            #endregion
            try
            {
                #region Main Working
                Connection.MustRunTrans = true;
                Connection.BeginTransaction();
                TablePack<_WebCount> dataWork = new TablePack<_WebCount>(Connection) { LoginUserID = accountId };
                m__WebCount md_Origin = dataWork.DataByAdapter<m__WebCount>().FirstOrDefault();
                if (md_Origin == null) //如有資料
                    throw new LogicRoll("Log_Err_MustHaveData"); //此區一定有資料傳出，如無資料應檢查前端id值是否有誤

                dataWork.EditFirstRow(); //編輯第一筆資料，正常只會有一筆資料。
                #region 指派值

                dataWork.SetDataRowValue(x => x.Cnt, md_Origin.Cnt + 1);
                //dataWork.UpdateFieldsInfo(UpdateFieldsInfoType.Update); //指定進行更新時 需同時更新系統欄位 _UpdateUserID，_UpdateDateTime
                #endregion
                md_Origin = null;
                dataWork.UpdateDataAdapter(); //進行變更至Database Server

                Connection.EndCommit();

                r.Rows = dataWork.AffetCount; //取得影響筆數
                r.Result = true;
                dataWork.Dispose(); //釋放資料
                return r;
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System;//系統執行失敗
                r.Message = PackErrMessage(ex); //回傳失敗訊息
                return r;
                #endregion
            }
        }
        public RunOneDataEnd<m__WebCount> SearchMaster(int accountId)
        {
            #region 變數宣告
            RunOneDataEnd<m__WebCount> r = new RunOneDataEnd<m__WebCount>();
            #endregion
            try
            {
                #region Select Data 區段 By 條件
                #region 設定輸出至Grid欄位 以下方式請注意 1、只適合單一Table 2、主要用於Grid顯示，如此方式不適合，可自行組SQL字串再夜由至ExecuteData執行
                TablePack<_WebCount> dataWork = new TablePack<_WebCount>(Connection) { LoginUserID = accountId };
                #endregion


                #region 輸出物件陣列
                r.SearchData = dataWork.DataByAdapter<m__WebCount>().FirstOrDefault();
                r.Result = true;
                return r;
                #endregion
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System;//系統執行失敗
                r.Message = PackErrMessage(ex); //回傳失敗訊息
                return r;
                #endregion
            }
        }
    }
    #endregion
    #region _CodeHead
    /// <summary>
    /// 查詢表單模組
    /// </summary>
    public class q__CodeHead : QueryBase
    {
        public String s_name { set; get; }
        public Boolean? s_IsEdit { get; set; }
    }
    public class m__CodeHead : ModuleBase
    {
        public Int32 id { get; set; }
        public String name { get; set; }
        public Boolean IsEdit { get; set; }
        public String Memo { get; set; }
    }
    /// <summary>
    /// The _CodeHead system database communicate module.   /// </summary>
    public class a__CodeHead : LogicBase<m__CodeHead, q__CodeHead, _CodeHead>
    {
        /// <summary>
        /// _CodeHead Table進行新增資料動作。
        /// </summary>
        /// <param name="md">傳入m__CodeHead class，class需先行建立(new)，其class各項屬性值需指定完成再行傳入</param>
        /// <param name="accountId">傳入Login使用者Id值</param>
        /// <returns>回傳RunInsertEnd class，請參閱RunInsertEnd說明。</returns>
        public override RunInsertEnd InsertMaster(m__CodeHead md, int accountId)
        {
            #region Variable declare area
            RunInsertEnd r = new RunInsertEnd(); //宣告回傳物件
            #endregion
            try
            {
                #region Main working
                Connection.BeginTransaction(); //開始交易鎖定
                TablePack<_CodeHead> dataWork = new TablePack<_CodeHead>(Connection) { LoginUserID = accountId };

                dataWork.NewRow(); //開始新橧作業 產生新的一行
                #region 指派值

                dataWork.SetDataRowValue(x => x.id, md.id);
                dataWork.SetDataRowValue(x => x.IsEdit, md.IsEdit);
                dataWork.SetDataRowValue(x => x.Memo, md.Memo);
                dataWork.SetDataRowValue(x => x.name, md.name);
                //dataWork.UpdateFieldsInfo(UpdateFieldsInfoType.Insert);
                dataWork.UpdateFieldsInfo(UpdateFieldsInfoType.Lang);
                //進行更新時 需同時更新系統欄位 _InsertUserID，_InsertDateTime
                #endregion
                dataWork.AddRow(); //加載至DataTable
                dataWork.UpdateDataAdapter(); //更新 DataBase Server

                Connection.EndCommit(); //交易確認

                r.Rows = dataWork.AffetCount; //取得影響筆數
                r.InsertId = dataWork.InsertAutoFieldsID; //取得新增後自動新增欄位的值
                r.Result = true; //回傳本次執行結果為成功
                dataWork.Dispose(); //釋放資料

                return r;
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        /// <summary>
        /// _CodeHead Table進行更新資料動作。
        /// </summary>
        /// <param name="md">傳入m__CodeHead class，class需先行建立(new)，其class各項屬性值需指定完成再行傳入</param>
        /// <param name="accountId">傳入Login使用者Id值</param>
        /// <returns>回傳RunUpdateEnd class，請參閱RunUpdateEnd說明。</returns>
        public override RunUpdateEnd UpdateMaster(m__CodeHead md, int accountId)
        {
            #region Variable declare area
            RunUpdateEnd r = new RunUpdateEnd();
            #endregion
            try
            {
                #region Main Working
                Connection.BeginTransaction();
                TablePack<_CodeHead> dataWork = new TablePack<_CodeHead>(Connection) { LoginUserID = accountId };

                dataWork.TableModule.KeyFieldModules[dataWork.TableModule.id.N].V = md.id; //取得ID欄位的值
                m__CodeHead md_Origin = dataWork.GetDataByKey<m__CodeHead>(); //取得Key值的Data

                if (md_Origin == null) //如有資料
                    throw new LogicRoll("Log_Err_MustHaveData"); //此區一定有資料傳出，如無資料應檢查前端id值是否有誤

                dataWork.EditFirstRow(); //編輯第一筆資料，正常只會有一筆資料。
                #region 指派值
                dataWork.SetDataRowValue(x => x.IsEdit, md.IsEdit);
                dataWork.SetDataRowValue(x => x.Memo, md.Memo);
                dataWork.SetDataRowValue(x => x.name, md.name);
                //dataWork.UpdateFieldsInfo(UpdateFieldsInfoType.Update); //指定進行更新時 需同時更新系統欄位 _UpdateUserID，_UpdateDateTime
                #endregion
                md_Origin = null;
                dataWork.UpdateDataAdapter(); //進行變更至Database Server

                Connection.EndCommit();

                r.Rows = dataWork.AffetCount; //取得影響筆數
                r.Result = true;
                dataWork.Dispose(); //釋放資料
                return r;
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        /// <summary>
        /// _CodeHead Table進行刪除資料動作。
        /// </summary>
        /// <param name="deleteIds">傳入要刪除資料的主鍵值，此適用該Table只有單一主鍵欄位。</param>
        /// <param name="accountId">傳入Login使用者Id值</param>
        /// <returns>回傳RunDeleteEnd class，請參閱RunDeleteEnd說明。</returns>
        public override RunDeleteEnd DeleteMaster(Int32[] ids, int accountId)
        {
            //此功能主要搭配Grid介面刪除功能製作
            #region Variable declare area
            RunDeleteEnd r = new RunDeleteEnd(); //宣告刪除Result回物件
            #endregion
            try
            {
                #region Main working
                Connection.BeginTransaction();
                //1、要刪除的資料先選出來
                TablePack<_CodeHead> dataWork = new TablePack<_CodeHead>(Connection) { LoginUserID = accountId }; //宣告泛型物件並連接Connection
                dataWork.SelectFields(x => x.id); //只Select 主Key欄位
                dataWork.WhereFields(x => x.id, ids); //代入陣列Id值

                m__CodeHead[] md_Origin = dataWork.DataByAdapter<m__CodeHead>(); //取得Key值的Data

                //2、進行全部刪除
                dataWork.DeleteAll(); //先刪除DataTable
                dataWork.UpdateDataAdapter(); //在更新至DataBase Server
                Connection.EndCommit();
                r.Result = true;
                dataWork.Dispose(); //釋放資料
                md_Origin = null;
                return r;
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        /// <summary>
        /// _CodeHead Table進行動態多條件查詢資料動作。
        /// </summary>
        /// <param name="qr">>傳入q__CodeHead class，class需先行建立(new)，其class各項屬性值需指定完成再行傳入</param>
        /// <param name="accountId">傳入Login使用者Id值</param>
        /// <returns>回傳RunQueryPackage<m__CodeHead>m__CodeHead</m__CodeHead> class，請參閱RunQueryPackage說明。</returns>
        public override RunQueryPackage<m__CodeHead> SearchMaster(q__CodeHead qr, int accountId)
        {
            #region 變數宣告
            RunQueryPackage<m__CodeHead> r = new RunQueryPackage<m__CodeHead>();
            #endregion
            try
            {
                #region Select Data 區段 By 條件
                #region 設定輸出至Grid欄位 以下方式請注意 1、只適合單一Table 2、主要用於Grid顯示，如此方式不適合，可自行組SQL字串再夜由至ExecuteData執行
                TablePack<_CodeHead> dataWork = new TablePack<_CodeHead>(Connection) { LoginUserID = accountId };
                //dataWork.SelectFields(x => new { x.id, x.CodeGroup, x.Memo, x.IsEdit });
                #endregion

                #region 設定Where條件
                //if (qr.s_CodeGroup != null)
                //dataWork.WhereFields(x => x.CodeGroup, qr.s_CodeGroup, WhereCompareType.Like);
                if (qr.s_IsEdit != null)
                    dataWork.WhereFields(x => x.IsEdit, qr.s_IsEdit);
                #endregion

                #region 設定排序
                dataWork.OrderByFields(x => x.id, OrderByType.ASC);
                #endregion

                #region 輸出物件陣列
                r.SearchData = dataWork.DataByAdapter<m__CodeHead>();
                r.Result = true;
                return r;
                #endregion
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        /// <summary>
        /// _CodeHead Table進行主鍵值查詢資料動作。
        /// </summary>
        /// <param name="id">傳入主鍵Value</param>
        /// <param name="accountId">傳入Login使用者Id值</param>
        /// <returns>回傳RunOneDataEnd<m__CodeHead>m__CodeHead</m__CodeHead> class，請參閱RunOneDataEnd說明。</returns>
        public override RunOneDataEnd<m__CodeHead> GetDataMaster(int id, int accountId)
        {
            #region 變數宣告
            RunOneDataEnd<m__CodeHead> r = new RunOneDataEnd<m__CodeHead>();

            #endregion
            try
            {
                #region Main working
                TablePack<_CodeHead> dataWork = new TablePack<_CodeHead>(Connection) { LoginUserID = accountId };
                dataWork.TableModule.KeyFieldModules[dataWork.TableModule.id.N].V = id; //設定KeyValue
                m__CodeHead md = dataWork.GetDataByKey<m__CodeHead>(); //取得Key該筆資料

                if (md == null) //如無資料
                    throw new LogicRoll("Log_Err_MustHaveData"); //此區一定有資料傳出，如無資料應檢查前端id值是否有誤

                r.SearchData = md;
                r.Result = true;
                dataWork.Dispose(); //釋放資料
                return r;
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        public override RunOneDataEnd<m__CodeHead> GetDataMaster(int[] id, int accountId)
        {
            throw new NotImplementedException();
        }
    }
    #endregion
    #region _CodeSheet
    /// <summary>
    /// 查詢表單模組
    /// </summary>
    public class q__CodeSheet : QueryBase
    {
        public String s_CodeHeadId { set; get; }
    }

    /// <summary>
    /// 系統資料結構描述模組    /// </summary>
    public class m__CodeSheet : ModuleBase
    {
        public Int32 id { get; set; }
        public Int32 CodeHeadId { get; set; }
        public String Code { get; set; }
        public String Value { get; set; }
        public Int32 Sort { get; set; }
        public Boolean IsUse { get; set; }
        public Boolean IsEdit { get; set; }
        public String Memo { get; set; }
    }

    /// <summary>
    /// The _CodeSheet system database communicate module.   /// </summary>
    public class a__CodeSheet : LogicBase<m__CodeSheet, q__CodeSheet, _CodeSheet>
    {
        /// <summary>
        /// _CodeSheet Table進行新增資料動作。
        /// </summary>
        /// <param name="md">傳入m__CodeSheet class，class需先行建立(new)，其class各項屬性值需指定完成再行傳入</param>
        /// <param name="accountId">傳入Login使用者Id值</param>
        /// <returns>回傳RunInsertEnd class，請參閱RunInsertEnd說明。</returns>
        public override RunInsertEnd InsertMaster(m__CodeSheet md, int accountId)
        {
            #region Variable declare area
            RunInsertEnd r = new RunInsertEnd(); //宣告回傳物件
            #endregion
            try
            {
                #region Main working
                Connection.BeginTransaction(); //開始交易鎖定
                TablePack<_CodeSheet> dataWork = new TablePack<_CodeSheet>(Connection) { LoginUserID = accountId };

                dataWork.NewRow(); //開始新橧作業 產生新的一行
                #region 指派值
                dataWork.SetDataRowValue(x => x.id, md.id);
                dataWork.SetDataRowValue(x => x.CodeHeadId, md.CodeHeadId);
                dataWork.SetDataRowValue(x => x.Code, md.Code);
                dataWork.SetDataRowValue(x => x.Value, md.Value);
                dataWork.SetDataRowValue(x => x.Sort, md.Sort);
                dataWork.SetDataRowValue(x => x.IsUse, md.IsUse);
                dataWork.SetDataRowValue(x => x.IsEdit, md.IsEdit);
                dataWork.SetDataRowValue(x => x.Memo, md.Memo);

                //dataWork.UpdateFieldsInfo(UpdateFieldsInfoType.Insert);
                dataWork.UpdateFieldsInfo(UpdateFieldsInfoType.Lang);
                //進行更新時 需同時更新系統欄位 _InsertUserID，_InsertDateTime
                #endregion
                dataWork.AddRow(); //加載至DataTable
                dataWork.UpdateDataAdapter(); //更新 DataBase Server

                Connection.EndCommit(); //交易確認

                r.Rows = dataWork.AffetCount; //取得影響筆數
                r.InsertId = dataWork.InsertAutoFieldsID; //取得新增後自動新增欄位的值
                r.Result = true; //回傳本次執行結果為成功
                dataWork.Dispose(); //釋放資料

                return r;
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼

                Log.Write(this.logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);

                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System;//系統執行失敗
                r.Message = PackErrMessage(ex); //回傳失敗訊息
                return r;
                #endregion
            }
        }
        /// <summary>
        /// _CodeSheet Table進行更新資料動作。
        /// </summary>
        /// <param name="md">傳入m__CodeSheet class，class需先行建立(new)，其class各項屬性值需指定完成再行傳入</param>
        /// <param name="accountId">傳入Login使用者Id值</param>
        /// <returns>回傳RunUpdateEnd class，請參閱RunUpdateEnd說明。</returns>
        public override RunUpdateEnd UpdateMaster(m__CodeSheet md, int accountId)
        {
            #region Variable declare area
            RunUpdateEnd r = new RunUpdateEnd();
            #endregion
            try
            {
                #region Main Working
                Connection.BeginTransaction();
                TablePack<_CodeSheet> dataWork = new TablePack<_CodeSheet>(Connection) { LoginUserID = accountId };
                dataWork.TableModule.KeyFieldModules[dataWork.TableModule.Code.N].V = md.Code; //取得ID欄位的值
                dataWork.TableModule.KeyFieldModules[dataWork.TableModule.CodeHeadId.N].V = md.CodeHeadId; //取得ID欄位的值
                dataWork.TableModule.KeyFieldModules[dataWork.TableModule._語系.N].V = System.Globalization.CultureInfo.CurrentCulture.Name; //取得ID欄位的值

                m__CodeSheet md_Origin = dataWork.GetDataByKey<m__CodeSheet>(); //取得Key值的Data

                if (md_Origin == null) //如有資料
                    throw new LogicRoll("Log_Err_MustHaveData"); //此區一定有資料傳出，如無資料應檢查前端id值是否有誤

                dataWork.EditFirstRow(); //編輯第一筆資料，正常只會有一筆資料。
                #region 指派值

                dataWork.SetDataRowValue(x => x.Code, md.Code);
                dataWork.SetDataRowValue(x => x.Value, md.Value);
                dataWork.SetDataRowValue(x => x.Sort, md.Sort);
                dataWork.SetDataRowValue(x => x.IsUse, md.IsUse);
                dataWork.SetDataRowValue(x => x.IsEdit, md.IsEdit);
                dataWork.SetDataRowValue(x => x.Memo, md.Memo);

                //dataWork.UpdateFieldsInfo(UpdateFieldsInfoType.Update); //指定進行更新時 需同時更新系統欄位 _UpdateUserID，_UpdateDateTime
                #endregion
                md_Origin = null;
                dataWork.UpdateDataAdapter(); //進行變更至Database Server

                Connection.EndCommit();

                r.Rows = dataWork.AffetCount; //取得影響筆數
                r.Result = true;
                dataWork.Dispose(); //釋放資料
                return r;
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System;//系統執行失敗
                r.Message = PackErrMessage(ex); //回傳失敗訊息
                return r;
                #endregion
            }
        }
        /// <summary>
        /// _CodeSheet Table進行刪除資料動作。
        /// </summary>
        /// <param name="deleteIds">傳入要刪除資料的主鍵值，此適用該Table只有單一主鍵欄位。</param>
        /// <param name="accountId">傳入Login使用者Id值</param>
        /// <returns>回傳RunDeleteEnd class，請參閱RunDeleteEnd說明。</returns>
        public override RunDeleteEnd DeleteMaster(Int32[] ids, int accountId)
        {
            //此功能主要搭配Grid介面刪除功能製作
            #region Variable declare area
            RunDeleteEnd r = new RunDeleteEnd(); //宣告刪除Result回物件
            #endregion
            try
            {
                #region Main working
                Connection.BeginTransaction();
                //1、要刪除的資料先選出來
                TablePack<_CodeSheet> dataWork = new TablePack<_CodeSheet>(Connection) { LoginUserID = accountId }; //宣告泛型物件並連接Connection
                dataWork.SelectFields(x => new { x.id, x._語系, x.CodeHeadId, x.Code }); //只Select 主Key欄位
                dataWork.WhereFields(x => x.id, ids); //代入陣列Id值
                m__CodeSheet[] md_Origin = dataWork.DataByAdapter<m__CodeSheet>(); //取得Key值的Data

                //2、進行全部刪除
                dataWork.DeleteAll(); //先刪除DataTable
                dataWork.UpdateDataAdapter(); //在更新至DataBase Server
                Connection.EndCommit();
                r.Result = true;
                dataWork.Dispose(); //釋放資料
                md_Origin = null;
                return r;
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System;//系統執行失敗
                r.Message = PackErrMessage(ex); //回傳失敗訊息
                return r;
                #endregion
            }
        }
        /// <summary>
        /// _CodeSheet Table進行動態多條件查詢資料動作。
        /// </summary>
        /// <param name="qr">>傳入q__CodeSheet class，class需先行建立(new)，其class各項屬性值需指定完成再行傳入</param>
        /// <param name="accountId">傳入Login使用者Id值</param>
        /// <returns>回傳RunQueryPackage<m__CodeSheet>m__CodeSheet</m__CodeSheet> class，請參閱RunQueryPackage說明。</returns>
        public override RunQueryPackage<m__CodeSheet> SearchMaster(q__CodeSheet qr, int accountId)
        {
            #region 變數宣告
            RunQueryPackage<m__CodeSheet> r = new RunQueryPackage<m__CodeSheet>();
            #endregion
            try
            {
                #region Select Data 區段 By 條件
                #region 設定輸出至Grid欄位 以下方式請注意 1、只適合單一Table 2、主要用於Grid顯示，如此方式不適合，可自行組SQL字串再夜由至ExecuteData執行
                TablePack<_CodeSheet> dataWork = new TablePack<_CodeSheet>(Connection) { LoginUserID = accountId };
                dataWork.SelectFields(x => new { x.id, x.Code, x.CodeHeadId, x.Value, x.Sort, x.IsUse });
                #endregion

                #region 設定Where條件
                if (qr.s_CodeHeadId != null)
                    dataWork.WhereFields(x => x.CodeHeadId, qr.s_CodeHeadId);

                dataWork.WhereLang();
                #endregion

                #region 設定排序

                dataWork.OrderByFields(x => x.Sort);

                #endregion

                #region 輸出物件陣列
                r.SearchData = dataWork.DataByAdapter<m__CodeSheet>();
                r.Result = true;
                return r;
                #endregion
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System;//系統執行失敗
                r.Message = PackErrMessage(ex); //回傳失敗訊息
                return r;
                #endregion
            }
        }
        /// <summary>
        /// _CodeSheet Table進行主鍵值查詢資料動作。
        /// </summary>
        /// <param name="id">傳入主鍵Value</param>
        /// <param name="accountId">傳入Login使用者Id值</param>
        /// <returns>回傳RunOneDataEnd<m__CodeSheet>m__CodeSheet</m__CodeSheet> class，請參閱RunOneDataEnd說明。</returns>
        public override RunOneDataEnd<m__CodeSheet> GetDataMaster(int id, int accountId)
        {
            #region 變數宣告
            RunOneDataEnd<m__CodeSheet> r = new RunOneDataEnd<m__CodeSheet>();

            #endregion
            try
            {
                #region Main working
                TablePack<_CodeSheet> dataWork = new TablePack<_CodeSheet>(Connection) { LoginUserID = accountId };
                dataWork.TableModule.KeyFieldModules[dataWork.TableModule.Code.N].V = id; //設定KeyValue
                m__CodeSheet md = dataWork.GetDataByKey<m__CodeSheet>(); //取得Key該筆資料

                if (md == null) //如無資料
                    throw new LogicRoll("Log_Err_MustHaveData"); //此區一定有資料傳出，如無資料應檢查前端id值是否有誤

                r.SearchData = md;
                r.Result = true;
                dataWork.Dispose(); //釋放資料
                return r;
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System;//系統執行失敗
                r.Message = PackErrMessage(ex); //回傳失敗訊息
                return r;
                #endregion
            }
        }
        public override RunOneDataEnd<m__CodeSheet> GetDataMaster(int[] id, int accountId)
        {
            throw new NotImplementedException();
        }

        public RunQueryPackage<_Code> GroupCodes(BaseSheet qr, int accountId)
        {
            #region 變數宣告
            RunQueryPackage<_Code> r = new RunQueryPackage<_Code>();
            #endregion
            try
            {
                #region Select Data 區段 By 條件
                #region 設定輸出至Grid欄位 以下方式請注意 1、只適合單一Table 2、主要用於Grid顯示，如此方式不適合，可自行組SQL字串再夜由至ExecuteData執行
                TablePack<_CodeSheet> dataWork = new TablePack<_CodeSheet>(Connection) { LoginUserID = accountId };
                dataWork.SelectFields(x => new { x.Code, x.Value });
                #endregion

                #region 設定Where條件
                dataWork.WhereFields(x => x.CodeHeadId, qr.CodeGroup);
                dataWork.WhereLang();
                #endregion

                #region 設定排序
                dataWork.OrderByFields(x => x.Sort);
                #endregion

                #region 輸出物件陣列
                List<_Code> l_c = new List<_Code>();
                var ms = dataWork.DataByAdapter<m__CodeSheet>();
                foreach (var m in ms)
                    l_c.Add(new _Code() { Code = m.Code, Value = m.Value });

                r.SearchData = l_c.ToArray();
                r.Result = true;
                return r;
                #endregion
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System;//系統執行失敗
                r.Message = PackErrMessage(ex); //回傳失敗訊息
                return r;
                #endregion
            }
        }
    }
    #endregion
    #region _UserLoginLog
    /// <summary>
    /// 查詢表單模組
    /// </summary>
    public class q__UserLoginLog : QueryBase
    {
        public String s_account { get; set; }
    }
    public class m__UserLoginLog : ModuleBase
    {
        public Int32 id { get; set; }
        public String ip { get; set; }
        public String account { get; set; }
        public DateTime logintime { get; set; }
        public String browers { get; set; }
    }
    /// <summary>
    /// The _UserLoginLog system database communicate module.   
    /// </summary>
    public class a__UserLoginLog : LogicBase<m__UserLoginLog, q__UserLoginLog, _UserLoginLog>
    {
        public override RunInsertEnd InsertMaster(m__UserLoginLog md, int accountId)
        {
            #region Variable declare area
            RunInsertEnd r = new RunInsertEnd(); //宣告回傳物件
            #endregion
            try
            {
                #region Main working
                Connection.BeginTransaction(); //開始交易鎖定
                TablePack<_UserLoginLog> dataWork = new TablePack<_UserLoginLog>(Connection) { LoginUserID = this.logPlamInfo.UserId, LoginUnitID = this.logPlamInfo.UnitId };

                dataWork.NewRow(); //開始新橧作業 產生新的一行
                #region 指派值
                md.id = GetIDX();
                dataWork.SetDataRowValue(x => x.id, md.id);
                dataWork.SetDataRowValue(x => x.account, md.account);
                dataWork.SetDataRowValue(x => x.ip, md.ip);
                dataWork.SetDataRowValue(x => x.logintime, md.logintime);
                dataWork.SetDataRowValue(x => x.browers, md.browers);

                //進行更新時 需同時更新系統欄位 _InsertUserID，_InsertDateTime
                #endregion
                dataWork.AddRow(); //加載至DataTable
                dataWork.UpdateDataAdapter(); //更新 DataBase Server

                Connection.EndCommit(); //交易確認
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, "OK");
                r.Rows = dataWork.AffetCount; //取得影響筆數
                r.InsertId = dataWork.InsertAutoFieldsID; //取得新增後自動新增欄位的值
                r.Result = true; //回傳本次執行結果為成功
                dataWork.Dispose(); //釋放資料

                return r;
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System; //系統失敗
                r.Message = PackErrMessage(ex); //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        public override RunUpdateEnd UpdateMaster(m__UserLoginLog md, int accountId)
        {
            throw new NotImplementedException();
        }
        public override RunDeleteEnd DeleteMaster(int[] ids, int accountId)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// _UserLoginLog Table進行動態多條件查詢資料動作。
        /// </summary>
        /// <param name="qr">>傳入q__UserLoginLog class，class需先行建立(new)，其class各項屬性值需指定完成再行傳入</param>
        /// <param name="accountId">傳入Login使用者Id值</param>
        /// <returns>回傳RunQueryPackage<m__UserLoginLog>m__UserLoginLog</m__UserLoginLog> class，請參閱RunQueryPackage說明。</returns>
        public override RunQueryPackage<m__UserLoginLog> SearchMaster(q__UserLoginLog qr, int accountId)
        {
            #region 變數宣告
            RunQueryPackage<m__UserLoginLog> r = new RunQueryPackage<m__UserLoginLog>();
            #endregion
            try
            {
                #region Select Data 區段 By 條件
                #region 設定輸出至Grid欄位 以下方式請注意 1、只適合單一Table 2、主要用於Grid顯示，如此方式不適合，可自行組SQL字串再夜由至ExecuteData執行
                TablePack<_UserLoginLog> dataWork = new TablePack<_UserLoginLog>(Connection) { LoginUserID = accountId };
                if (qr.MaxRecord > 0) dataWork.TopLimit = qr.MaxRecord;
                dataWork.SelectFields(x => new { x.logintime });
                #endregion

                #region 設定Where條件

                if (qr.s_account != null)
                    dataWork.WhereFields(x => x.account, qr.s_account);
                #endregion

                #region 設定排序
                if (qr.sidx == "logintime")
                {
                    if (qr.sord.ToLower() == "desc")
                        dataWork.OrderByFields(x => x.logintime, OrderByType.DESC); //預設排序
                    else
                        dataWork.OrderByFields(x => x.logintime); //預設排序
                }

                #endregion

                #region 輸出物件陣列
                r.SearchData = dataWork.DataByAdapter<m__UserLoginLog>();
                r.Result = true;
                return r;
                #endregion
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        /// <summary>
        /// _UserLoginLog Table進行主鍵值查詢資料動作。
        /// </summary>
        /// <param name="id">傳入主鍵Value</param>
        /// <param name="accountId">傳入Login使用者Id值</param>
        /// <returns>回傳RunOneDataEnd<m__UserLoginLog>m__UserLoginLog</m__UserLoginLog> class，請參閱RunOneDataEnd說明。</returns>
        public override RunOneDataEnd<m__UserLoginLog> GetDataMaster(int id, int accountId)
        {
            #region 變數宣告
            RunOneDataEnd<m__UserLoginLog> r = new RunOneDataEnd<m__UserLoginLog>();

            #endregion
            try
            {
                #region Main working
                TablePack<_UserLoginLog> dataWork = new TablePack<_UserLoginLog>(Connection) { LoginUserID = accountId };
                //dataWork.TableModule.KeyFieldModules[dataWork.TableModule.id.N].V = id; //設定KeyValue
                m__UserLoginLog md = dataWork.GetDataByKey<m__UserLoginLog>(); //取得Key該筆資料

                if (md == null) //如無資料
                    throw new LogicRoll("Log_Err_MustHaveData"); //此區一定有資料傳出，如無資料應檢查前端id值是否有誤

                r.SearchData = md;
                r.Result = true;
                dataWork.Dispose(); //釋放資料
                return r;
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        public override RunOneDataEnd<m__UserLoginLog> GetDataMaster(int[] id, int accountId)
        {
            throw new NotImplementedException();
        }
    }
    #endregion
    public class m_Parm
    {
        #region Code Replay
        public Int32 DF_Can_Sell_Amt { get; set; }
        public Boolean Open { get; set; }
        public DateTime ValidDate { get; set; }

        #endregion
    }
    public class a_Parm : LogicBase
    {
        TablePack<_Parm> dataWork;
        DataTable dt;
        m_Parm md;
        public a_Parm(CommConnection cnn)
        {
            this.Connection = cnn;
            dataWork = new TablePack<_Parm>(cnn) { LoginUserID = 0 };
            dataWork.SelectFields(x => new { x.ParmName, x.ParmType, x.S, x.I, x.F, x.D, x.B });
            dt = dataWork.DataByAdapter();
            md = new m_Parm();
            foreach (DataRow dr in dt.Rows)
            {
                switch ((String)dr["ParmType"])
                {
                    case "S":
                        md.GetType().GetProperty((String)dr["ParmName"]).SetValue(md, dr["S"]);
                        break;
                    case "I":
                        md.GetType().GetProperty((String)dr["ParmName"]).SetValue(md, dr["I"]);
                        break;
                    case "F":
                        md.GetType().GetProperty((String)dr["ParmName"]).SetValue(md, dr["F"]);
                        break;
                    case "D":
                        md.GetType().GetProperty((String)dr["ParmName"]).SetValue(md, dr["D"]);
                        break;
                    case "B":
                        md.GetType().GetProperty((String)dr["ParmName"]).SetValue(md, dr["B"]);
                        break;
                }

            }
        }
        public void Update()
        {
            dataWork.UpdateDataAdapter();
        }

        public m_Parm GetParm { get { return md; } }

        #region Code Replay

        /// <summary>
        /// 
        /// </summary>
        public Int32 DF_Can_Sell_Amt
        {
            get
            {
                return dt.AsEnumerable().Single(x => x.Field<String>("ParmName") == "DF_Can_Sell_Amt").Field<Int32>("I");
            }
            set
            {
                dt.AsEnumerable().Single(x => x.Field<String>("ParmName") == "DF_Can_Sell_Amt").SetField<Int32>("I", value);
            }
        }

        /// <summary>
        /// 前台網站總開關
        /// </summary>
        public Boolean Open
        {
            get
            {
                return dt.AsEnumerable().Single(x => x.Field<String>("ParmName") == "Open").Field<Boolean>("B");
            }
            set
            {
                dt.AsEnumerable().Single(x => x.Field<String>("ParmName") == "Open").SetField<Boolean>("B", value);
            }
        }

        /// <summary>
        /// 有效日期
        /// </summary>
        public DateTime ValidDate
        {
            get
            {
                return dt.AsEnumerable().Single(x => x.Field<String>("ParmName") == "ValidDate").Field<DateTime>("D");
            }
            set
            {
                dt.AsEnumerable().Single(x => x.Field<String>("ParmName") == "ValidDate").SetField<DateTime>("D", value);
            }
        }

        #endregion
    }

    #endregion
    #region System Main Class
    #region Product_Category


    #endregion
    #region Product_Category_L1
    public class q_Product_Category_L1 : QueryBase
    {
        public String s_title { set; get; }
    }

    public class m_Product_Category
    {
        public m_Product_Category_L1[] Product_Category { get; set; }
        public int Category_L1 { get; set; }
        public int Category_L2 { get; set; }

        public m_Product_Category_Fix[] Product_Category_Fix { get; set; }
        public int Product_Category_Fix_Product { get; set; }
        public m_Product_Category_Fix Product_Category_Fix_Select { get; set; }
    }



    public class m_Product_Category_Fix
    {
        public m_Product[] Product { get; set; }
        public String Category_Name { get; set; }
        public String Category_Code { get; set; }
    }

    public class m_Product_Category_L1 : ModuleBase
    {
        public Int32 id { get; set; }
        public String category_l1_name { get; set; }
        public Int32 sort { get; set; }
        public m_Product_Category_L2[] Category_L2 { get; set; }
    }
    public class a_Product_Category_L1 : LogicBase<m_Product_Category_L1, q_Product_Category_L1, Product_Category_L1>
    {
        public override RunInsertEnd InsertMaster(m_Product_Category_L1 md, int accountId)
        {
            #region Variable declare area
            RunInsertEnd r = new RunInsertEnd(); //宣告回傳物件
            #endregion
            try
            {
                #region Main working
                Connection.BeginTransaction(); //開始交易鎖定
                TablePack<Product_Category_L1> dataWork = new TablePack<Product_Category_L1>(Connection) { LoginUserID = this.logPlamInfo.UserId, LoginUnitID = this.logPlamInfo.UnitId };

                dataWork.NewRow(); //開始新橧作業 產生新的一行
                #region 指派值

                dataWork.SetDataRowValue(x => x.id, md.id);
                dataWork.SetDataRowValue(x => x.category_l1_name, md.category_l1_name);
                dataWork.SetDataRowValue(x => x.sort, md.sort);
                dataWork.SetDataRowValue(x => x._隱藏, false);

                dataWork.UpdateFieldsInfo(UpdateFieldsInfoType.Insert); //進行更新時 需同時更新系統欄位 _新增人員，_新增日期
                dataWork.UpdateFieldsInfo(UpdateFieldsInfoType.Lang); //語系欄位設定
                //進行更新時 需同時更新系統欄位 _InsertUserID，_InsertDateTime
                #endregion
                dataWork.AddRow(); //加載至DataTable
                dataWork.UpdateDataAdapter(); //更新 DataBase Server

                Connection.EndCommit(); //交易確認

                r.Rows = dataWork.AffetCount; //取得影響筆數
                r.InsertId = dataWork.InsertAutoFieldsID; //取得新增後自動新增欄位的值
                r.Result = true; //回傳本次執行結果為成功
                dataWork.Dispose(); //釋放資料

                return r;
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System; //系統失敗
                r.Message = PackErrMessage(ex); //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        public override RunUpdateEnd UpdateMaster(m_Product_Category_L1 md, int accountId)
        {
            #region Variable declare area
            RunUpdateEnd r = new RunUpdateEnd();
            #endregion
            try
            {
                #region Main Working
                Connection.BeginTransaction();
                TablePack<Product_Category_L1> dataWork = new TablePack<Product_Category_L1>(Connection) { LoginUserID = this.logPlamInfo.UserId, LoginUnitID = this.logPlamInfo.UnitId };

                dataWork.TableModule.KeyFieldModules[dataWork.TableModule.id.N].V = md.id; //取得ID欄位的值
                m_Product_Category_L1 md_Origin = dataWork.GetDataByKey<m_Product_Category_L1>(); //取得Key值的Data

                if (md_Origin == null) //如有資料
                    throw new LogicRoll("Log_Err_MustHaveData"); //此區一定有資料傳出，如無資料應檢查前端id值是否有誤

                dataWork.EditFirstRow(); //編輯第一筆資料，正常只會有一筆資料。
                #region 指派值

                dataWork.SetDataRowValue(x => x.id, md.id);
                dataWork.SetDataRowValue(x => x.category_l1_name, md.category_l1_name);
                dataWork.SetDataRowValue(x => x.sort, md.sort);


                dataWork.UpdateFieldsInfo(UpdateFieldsInfoType.Update); //指定進行更新時 需同時更新系統欄位 _修改人員，_修改日期
                #endregion
                md_Origin = null;
                dataWork.UpdateDataAdapter(); //進行變更至Database Server

                Connection.EndCommit();

                r.Rows = dataWork.AffetCount; //取得影響筆數
                r.Result = true;
                dataWork.Dispose(); //釋放資料
                return r;
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System; //系統失敗
                r.Message = PackErrMessage(ex); //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        public override RunDeleteEnd DeleteMaster(Int32[] ids, int accountId)
        {
            //此功能主要搭配Grid介面刪除功能製作
            #region Variable declare area
            RunDeleteEnd r = new RunDeleteEnd(); //宣告刪除Result回物件
            #endregion
            try
            {
                #region Main working
                Connection.BeginTransaction();
                //1、要刪除的資料先選出來
                TablePack<Product_Category_L1> dataWork = new TablePack<Product_Category_L1>(Connection) { LoginUserID = this.logPlamInfo.UserId, LoginUnitID = this.logPlamInfo.UnitId }; //宣告泛型物件並連接Connection
                dataWork.SelectFields(x => x.id); //只Select 主Key欄位
                dataWork.WhereFields(x => x.id, ids); //代入陣列Id值

                m_Product_Category_L1[] md_Origin = dataWork.DataByAdapter<m_Product_Category_L1>(); //取得Key值的Data

                //2、進行全部刪除
                dataWork.DeleteAll(); //先刪除DataTable
                dataWork.UpdateDataAdapter(); //在更新至DataBase Server
                Connection.EndCommit();
                r.Result = true;
                dataWork.Dispose(); //釋放資料
                md_Origin = null;
                return r;
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System; //系統失敗
                r.Message = PackErrMessage(ex); //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        public override RunQueryPackage<m_Product_Category_L1> SearchMaster(q_Product_Category_L1 qr, int accountId)
        {
            #region 變數宣告
            RunQueryPackage<m_Product_Category_L1> r = new RunQueryPackage<m_Product_Category_L1>();
            #endregion
            try
            {
                #region Select Data 區段 By 條件
                #region 設定輸出至Grid欄位
                TablePack<Product_Category_L1> dataWork = new TablePack<Product_Category_L1>(Connection) { LoginUserID = this.logPlamInfo.UserId, LoginUnitID = this.logPlamInfo.UnitId };
                dataWork.SelectFields(x => new { x.id, x.category_l1_name, x.sort });

                if (qr.MaxRecord > 0) dataWork.TopLimit = qr.MaxRecord;

                #endregion

                #region 設定Where條件
                if (qr.s_title != null)
                    dataWork.WhereFields(x => x.category_l1_name, qr.s_title, WhereCompareType.Like);

                dataWork.WhereFields(x => x._隱藏, false);
                dataWork.WhereLang(); //使用語系條件
                #endregion

                #region 設定排序
                if (qr.sidx == null)
                    dataWork.OrderByFields(x => x.sort); //預設排序
                else
                    dataWork.OrderByFields(x => x.sort, OrderByType.ASC);
                #endregion

                #region 輸出物件陣列
                r.SearchData = dataWork.DataByAdapter<m_Product_Category_L1>();
                r.Result = true;
                return r;
                #endregion
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System; //系統失敗
                r.Message = PackErrMessage(ex); //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        public override RunOneDataEnd<m_Product_Category_L1> GetDataMaster(int id, int accountId)
        {
            #region 變數宣告
            RunOneDataEnd<m_Product_Category_L1> r = new RunOneDataEnd<m_Product_Category_L1>();

            #endregion
            try
            {
                #region Main working
                TablePack<Product_Category_L1> dataWork = new TablePack<Product_Category_L1>(Connection) { LoginUserID = this.logPlamInfo.UserId, LoginUnitID = this.logPlamInfo.UnitId };
                dataWork.TableModule.KeyFieldModules[dataWork.TableModule.id.N].V = id; //設定KeyValue
                m_Product_Category_L1 md = dataWork.GetDataByKey<m_Product_Category_L1>(); //取得Key該筆資料

                if (md == null) //如無資料
                    throw new LogicRoll("Log_Err_MustHaveData"); //此區一定有資料傳出，如無資料應檢查前端id值是否有誤

                r.SearchData = md;
                r.Result = true;
                dataWork.Dispose(); //釋放資料
                return r;
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System; //系統失敗
                r.Message = PackErrMessage(ex); //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        public override RunOneDataEnd<m_Product_Category_L1> GetDataMaster(int[] id, int accountId)
        {
            throw new NotImplementedException();
        }
        public Dictionary<String, String> options_category_l1(int accountId)
        {
            #region 變數宣告
            //RunQueryPackage<m_車輛廠牌檔> r = new RunQueryPackage<m_車輛廠牌檔>();
            #endregion

            #region Select Data 區段 By 條件
            #region 設定輸出至Grid欄位 以下方式請注音 1、只適合單一Table 2、主要用於Grid顯示，如此方式不適合，可自行組SQL字串再夜由至ExecuteData達行
            TablePack<Product_Category_L1> dataWork = new TablePack<Product_Category_L1>(Connection) { LoginUserID = accountId };
            dataWork.SelectFields(x => new { x.id, x.category_l1_name });
            #endregion

            #region 設定Where條件

            #endregion

            #region 設定排序
            dataWork.OrderByFields(x => x.sort);
            #endregion

            #region 輸出成DataTable
            return dataWork.DataByAdapter<m_Product_Category_L1>()
                .Select(x => new { x.id, kindname = x.category_l1_name })
                .ToDictionary(x => x.id.ToString(), x => x.kindname);

            #endregion
            #endregion
        }
        public m_Product_Category All_Product_Category()
        {

            Table1Join<Product_Category_L1> dataWork_L1 = new Table1Join<Product_Category_L1>(Connection) { };
            dataWork_L1.SelectFields(x => new { x.id, x.category_l1_name });
            dataWork_L1.WhereFields(x => x._隱藏, false);
            dataWork_L1.WhereLang();
            dataWork_L1.OrderByFields(x => x.sort);

            var r = dataWork_L1.DataByAdapter<m_Product_Category_L1>();

            foreach (var r1 in r)
            {

                Table1Join<Product_Category_L2> dataWork_L2 = new Table1Join<Product_Category_L2>(Connection) { };
                dataWork_L2.SelectFields(x => new { x.id, x.category_l2_name });
                dataWork_L2.WhereFields(x => x.product_category_l1_id, r1.id);
                dataWork_L1.WhereFields(x => x._隱藏, false);
                dataWork_L2.WhereLang();
                dataWork_L2.OrderByFields(x => x.sort);
                r1.Category_L2 = dataWork_L2.DataByAdapter<m_Product_Category_L2>();
            }
            return (new m_Product_Category { Product_Category = r });
        }
    }
    #endregion
    #region Product_Category_L2
    public class q_Product_Category_L2 : QueryBase
    {
        public int? s_product_category_l1_id { set; get; }
    }
    public class m_Product_Category_L2 : ModuleBase
    {
        ///<summary>
        ///Mapping:product_category_l2_id
        ///</summary>
        public Int32 id { get; set; }
        public Int32 product_category_l1_id { get; set; }
        public String category_l2_name { get; set; }
        public Int32 sort { get; set; }
    }
    public class a_Product_Category_L2 : LogicBase<m_Product_Category_L2, q_Product_Category_L2, Product_Category_L2>
    {
        public override RunInsertEnd InsertMaster(m_Product_Category_L2 md, int accountId)
        {
            #region Variable declare area
            RunInsertEnd r = new RunInsertEnd(); //宣告回傳物件
            #endregion
            try
            {
                #region Main working
                Connection.BeginTransaction(); //開始交易鎖定
                TablePack<Product_Category_L2> dataWork = new TablePack<Product_Category_L2>(Connection) { LoginUserID = this.logPlamInfo.UserId, LoginUnitID = this.logPlamInfo.UnitId };

                dataWork.NewRow(); //開始新橧作業 產生新的一行
                #region 指派值

                dataWork.SetDataRowValue(x => x.id, md.id);
                dataWork.SetDataRowValue(x => x.product_category_l1_id, md.product_category_l1_id);
                dataWork.SetDataRowValue(x => x.category_l2_name, md.category_l2_name);
                dataWork.SetDataRowValue(x => x.sort, md.sort);
                dataWork.SetDataRowValue(x => x._隱藏, false);

                dataWork.UpdateFieldsInfo(UpdateFieldsInfoType.Insert); //進行更新時 需同時更新系統欄位 _新增人員，_新增日期
                dataWork.UpdateFieldsInfo(UpdateFieldsInfoType.Lang); //語系欄位設定
                //進行更新時 需同時更新系統欄位 _InsertUserID，_InsertDateTime
                #endregion
                dataWork.AddRow(); //加載至DataTable
                dataWork.UpdateDataAdapter(); //更新 DataBase Server

                Connection.EndCommit(); //交易確認

                r.Rows = dataWork.AffetCount; //取得影響筆數
                r.InsertId = dataWork.InsertAutoFieldsID; //取得新增後自動新增欄位的值
                r.Result = true; //回傳本次執行結果為成功
                dataWork.Dispose(); //釋放資料

                return r;
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System; //系統失敗
                r.Message = PackErrMessage(ex); //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        public override RunUpdateEnd UpdateMaster(m_Product_Category_L2 md, int accountId)
        {
            #region Variable declare area
            RunUpdateEnd r = new RunUpdateEnd();
            #endregion
            try
            {
                #region Main Working
                Connection.BeginTransaction();
                TablePack<Product_Category_L2> dataWork = new TablePack<Product_Category_L2>(Connection) { LoginUserID = this.logPlamInfo.UserId, LoginUnitID = this.logPlamInfo.UnitId };

                dataWork.TableModule.KeyFieldModules[dataWork.TableModule.id.N].V = md.id; //取得ID欄位的值
                m_Product_Category_L2 md_Origin = dataWork.GetDataByKey<m_Product_Category_L2>(); //取得Key值的Data

                if (md_Origin == null) //如有資料
                    throw new LogicRoll("Log_Err_MustHaveData"); //此區一定有資料傳出，如無資料應檢查前端id值是否有誤

                dataWork.EditFirstRow(); //編輯第一筆資料，正常只會有一筆資料。
                #region 指派值

                dataWork.SetDataRowValue(x => x.id, md.id);
                dataWork.SetDataRowValue(x => x.product_category_l1_id, md.product_category_l1_id);
                dataWork.SetDataRowValue(x => x.category_l2_name, md.category_l2_name);
                dataWork.SetDataRowValue(x => x.sort, md.sort);


                dataWork.UpdateFieldsInfo(UpdateFieldsInfoType.Update); //指定進行更新時 需同時更新系統欄位 _修改人員，_修改日期
                #endregion
                md_Origin = null;
                dataWork.UpdateDataAdapter(); //進行變更至Database Server

                Connection.EndCommit();

                r.Rows = dataWork.AffetCount; //取得影響筆數
                r.Result = true;
                dataWork.Dispose(); //釋放資料
                return r;
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System; //系統失敗
                r.Message = PackErrMessage(ex); //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        public override RunDeleteEnd DeleteMaster(Int32[] ids, int accountId)
        {
            //此功能主要搭配Grid介面刪除功能製作
            #region Variable declare area
            RunDeleteEnd r = new RunDeleteEnd(); //宣告刪除Result回物件
            #endregion
            try
            {
                #region Main working
                Connection.BeginTransaction();
                //1、要刪除的資料先選出來
                TablePack<Product_Category_L2> dataWork = new TablePack<Product_Category_L2>(Connection) { LoginUserID = this.logPlamInfo.UserId, LoginUnitID = this.logPlamInfo.UnitId }; //宣告泛型物件並連接Connection
                dataWork.SelectFields(x => x.id); //只Select 主Key欄位
                dataWork.WhereFields(x => x.id, ids); //代入陣列Id值

                m_Product_Category_L2[] md_Origin = dataWork.DataByAdapter<m_Product_Category_L2>(); //取得Key值的Data

                //2、進行全部刪除
                dataWork.DeleteAll(); //先刪除DataTable
                dataWork.UpdateDataAdapter(); //在更新至DataBase Server
                Connection.EndCommit();
                r.Result = true;
                dataWork.Dispose(); //釋放資料
                md_Origin = null;
                return r;
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System; //系統失敗
                r.Message = PackErrMessage(ex); //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        public override RunQueryPackage<m_Product_Category_L2> SearchMaster(q_Product_Category_L2 qr, int accountId)
        {
            #region 變數宣告
            RunQueryPackage<m_Product_Category_L2> r = new RunQueryPackage<m_Product_Category_L2>();
            #endregion
            try
            {
                #region Select Data 區段 By 條件
                #region 設定輸出至Grid欄位
                TablePack<Product_Category_L2> dataWork = new TablePack<Product_Category_L2>(Connection) { LoginUserID = this.logPlamInfo.UserId, LoginUnitID = this.logPlamInfo.UnitId };
                dataWork.SelectFields(x => new { x.id, x.product_category_l1_id, x.category_l2_name, x.sort });

                if (qr.MaxRecord > 0) dataWork.TopLimit = qr.MaxRecord;

                #endregion

                #region 設定Where條件
                if (qr.s_product_category_l1_id != null)
                    dataWork.WhereFields(x => x.product_category_l1_id, qr.s_product_category_l1_id);

                dataWork.WhereFields(x => x._隱藏, false);
                dataWork.WhereLang(); //使用語系條件
                #endregion

                #region 設定排序
                if (qr.sidx == null)
                    dataWork.OrderByFields(x => x.sort); //預設排序
                else
                    dataWork.OrderByFields(x => x.id, OrderByType.ASC);
                #endregion

                #region 輸出物件陣列
                r.SearchData = dataWork.DataByAdapter<m_Product_Category_L2>();
                r.Result = true;
                return r;
                #endregion
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System; //系統失敗
                r.Message = PackErrMessage(ex); //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        public override RunOneDataEnd<m_Product_Category_L2> GetDataMaster(int id, int accountId)
        {
            #region 變數宣告
            RunOneDataEnd<m_Product_Category_L2> r = new RunOneDataEnd<m_Product_Category_L2>();

            #endregion
            try
            {
                #region Main working
                TablePack<Product_Category_L2> dataWork = new TablePack<Product_Category_L2>(Connection) { LoginUserID = this.logPlamInfo.UserId, LoginUnitID = this.logPlamInfo.UnitId };
                dataWork.TableModule.KeyFieldModules[dataWork.TableModule.id.N].V = id; //設定KeyValue
                m_Product_Category_L2 md = dataWork.GetDataByKey<m_Product_Category_L2>(); //取得Key該筆資料

                if (md == null) //如無資料
                    throw new LogicRoll("Log_Err_MustHaveData"); //此區一定有資料傳出，如無資料應檢查前端id值是否有誤

                r.SearchData = md;
                r.Result = true;
                dataWork.Dispose(); //釋放資料
                return r;
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System; //系統失敗
                r.Message = PackErrMessage(ex); //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        public override RunOneDataEnd<m_Product_Category_L2> GetDataMaster(int[] id, int accountId)
        {
            throw new NotImplementedException();
        }
    }
    #endregion
    #region Product
    public class q_Product : QueryBase
    {
        public String s_product_name { set; get; }
        public Boolean? s_is_shelf { set; get; }
        public String s_product_state { set; get; }
        public Int32 s_product_category_l1_id { get; set; }
        public Int32 s_product_category_l2_id { get; set; }
        public String s_product_category { get; set; }
    }
    public class m_Product : ModuleBase
    {
        ///<summary>
        ///Mapping:product_id
        ///</summary>
        public Int32 id { get; set; }
        ///<summary>
        ///產品名稱

        ///</summary>
        public String product_name { get; set; }
        ///<summary>
        ///產品編號

        ///</summary>
        public String product_serial { get; set; }
        ///<summary>
        ///原價

        ///</summary>
        public Decimal original_price { get; set; }
        ///<summary>
        ///特價

        ///</summary>
        public Decimal special_price { get; set; }
        ///<summary>
        ///會員價

        ///</summary>
        public Decimal member_price { get; set; }
        ///<summary>
        ///產品狀態

        ///</summary>
        public String product_state { get; set; }
        public String unit_name { get; set; }
        public String currency { get; set; }
        ///<summary>
        ///是否上架

        ///</summary>
        public Boolean is_shelf { get; set; }
        public Int32 sort { get; set; }
        public Int32 can_sell_amt { get; set; }
        ///<summary>
        ///產品介紹

        ///</summary>
        public String introduction { get; set; }
        ///<summary>
        ///產品規格

        ///</summary>
        public String specifications { get; set; }
        public Int32 product_category_l1_id { get; set; }
        public String category_l1_name { get; set; }
        public Int32 product_category_l2_id { get; set; }
        public String category_l2_name { get; set; }
        public String product_category { get; set; }
        ///<summary>
        ///產品樹狀分類用

        ///</summary>
        public Int32 product_tree_id { get; set; }
        public Decimal cost_price { get; set; }
    }
    public class a_Product : LogicBase<m_Product, q_Product, Product>
    {
        public override RunInsertEnd InsertMaster(m_Product md, int accountId)
        {
            #region Variable declare area
            RunInsertEnd r = new RunInsertEnd(); //宣告回傳物件
            #endregion
            try
            {
                #region Main working
                Connection.BeginTransaction(); //開始交易鎖定
                TablePack<Product> dataWork = new TablePack<Product>(Connection) { LoginUserID = this.logPlamInfo.UserId, LoginUnitID = this.logPlamInfo.UnitId };

                dataWork.NewRow(); //開始新橧作業 產生新的一行
                #region 指派值

                dataWork.SetDataRowValue(x => x.id, md.id);
                dataWork.SetDataRowValue(x => x.product_name, md.product_name);
                dataWork.SetDataRowValue(x => x.product_serial, md.product_serial);
                dataWork.SetDataRowValue(x => x.original_price, md.original_price);
                dataWork.SetDataRowValue(x => x.cost_price, md.cost_price);
                dataWork.SetDataRowValue(x => x.special_price, md.special_price);
                dataWork.SetDataRowValue(x => x.member_price, md.member_price);
                dataWork.SetDataRowValue(x => x.product_state, md.product_state);
                dataWork.SetDataRowValue(x => x.unit_name, md.unit_name);
                dataWork.SetDataRowValue(x => x.currency, md.currency);
                dataWork.SetDataRowValue(x => x.is_shelf, md.is_shelf);
                dataWork.SetDataRowValue(x => x.sort, md.sort);
                dataWork.SetDataRowValue(x => x.can_sell_amt, md.can_sell_amt);
                dataWork.SetDataRowValue(x => x.introduction, md.introduction);
                dataWork.SetDataRowValue(x => x.specifications, md.specifications);
                dataWork.SetDataRowValue(x => x.product_category_l1_id, md.product_category_l1_id);
                dataWork.SetDataRowValue(x => x.product_category_l2_id, md.product_category_l2_id);
                dataWork.SetDataRowValue(x => x.product_category, md.product_category);
                dataWork.SetDataRowValue(x => x.product_tree_id, md.product_tree_id);

                dataWork.SetDataRowValue(x => x._隱藏, false);

                dataWork.UpdateFieldsInfo(UpdateFieldsInfoType.Insert); //進行更新時 需同時更新系統欄位 _新增人員，_新增日期
                dataWork.UpdateFieldsInfo(UpdateFieldsInfoType.Lang); //語系欄位設定
                //進行更新時 需同時更新系統欄位 _InsertUserID，_InsertDateTime
                #endregion
                dataWork.AddRow(); //加載至DataTable
                dataWork.UpdateDataAdapter(); //更新 DataBase Server

                Connection.EndCommit(); //交易確認

                r.Rows = dataWork.AffetCount; //取得影響筆數
                r.InsertId = dataWork.InsertAutoFieldsID; //取得新增後自動新增欄位的值
                r.Result = true; //回傳本次執行結果為成功
                dataWork.Dispose(); //釋放資料

                return r;
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System; //系統失敗
                r.Message = PackErrMessage(ex); //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        public override RunUpdateEnd UpdateMaster(m_Product md, int accountId)
        {
            #region Variable declare area
            RunUpdateEnd r = new RunUpdateEnd();
            #endregion
            try
            {
                #region Main Working
                Connection.BeginTransaction();
                TablePack<Product> dataWork = new TablePack<Product>(Connection) { LoginUserID = this.logPlamInfo.UserId, LoginUnitID = this.logPlamInfo.UnitId };

                dataWork.TableModule.KeyFieldModules[dataWork.TableModule.id.N].V = md.id; //取得ID欄位的值
                m_Product md_Origin = dataWork.GetDataByKey<m_Product>(); //取得Key值的Data

                if (md_Origin == null) //如有資料
                    throw new LogicRoll("Log_Err_MustHaveData"); //此區一定有資料傳出，如無資料應檢查前端id值是否有誤

                dataWork.EditFirstRow(); //編輯第一筆資料，正常只會有一筆資料。
                #region 指派值

                dataWork.SetDataRowValue(x => x.id, md.id);
                dataWork.SetDataRowValue(x => x.product_name, md.product_name);
                //dataWork.SetDataRowValue(x => x.product_serial, md.product_serial);
                //dataWork.SetDataRowValue(x => x.original_price, md.original_price);
                //dataWork.SetDataRowValue(x => x.cost_price, md.cost_price);
                //dataWork.SetDataRowValue(x => x.special_price, md.special_price);
                //dataWork.SetDataRowValue(x => x.member_price, md.member_price);
                //dataWork.SetDataRowValue(x => x.product_state, md.product_state);
                //dataWork.SetDataRowValue(x => x.unit_name, md.unit_name);
                //dataWork.SetDataRowValue(x => x.currency, md.currency);
                //dataWork.SetDataRowValue(x => x.is_shelf, md.is_shelf);
                dataWork.SetDataRowValue(x => x.sort, md.sort);
                //dataWork.SetDataRowValue(x => x.can_sell_amt, md.can_sell_amt);
                dataWork.SetDataRowValue(x => x.introduction, md.introduction);
                dataWork.SetDataRowValue(x => x.specifications, md.specifications);
                //dataWork.SetDataRowValue(x => x.product_category_l1_id, md.product_category_l1_id);
                //dataWork.SetDataRowValue(x => x.product_category_l2_id, md.product_category_l2_id);
                //dataWork.SetDataRowValue(x => x.product_tree_id, md.product_tree_id);
                dataWork.SetDataRowValue(x => x.product_category, md.product_category);

                dataWork.UpdateFieldsInfo(UpdateFieldsInfoType.Update); //指定進行更新時 需同時更新系統欄位 _修改人員，_修改日期
                #endregion
                md_Origin = null;
                dataWork.UpdateDataAdapter(); //進行變更至Database Server

                Connection.EndCommit();

                r.Rows = dataWork.AffetCount; //取得影響筆數
                r.Result = true;
                dataWork.Dispose(); //釋放資料
                return r;
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System; //系統失敗
                r.Message = PackErrMessage(ex); //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        public override RunDeleteEnd DeleteMaster(Int32[] ids, int accountId)
        {
            //此功能主要搭配Grid介面刪除功能製作
            #region Variable declare area
            RunDeleteEnd r = new RunDeleteEnd(); //宣告刪除Result回物件
            #endregion
            try
            {
                #region Main working
                Connection.BeginTransaction();
                //1、要刪除的資料先選出來
                TablePack<Product> dataWork = new TablePack<Product>(Connection) { LoginUserID = this.logPlamInfo.UserId, LoginUnitID = this.logPlamInfo.UnitId }; //宣告泛型物件並連接Connection
                dataWork.SelectFields(x => x.id); //只Select 主Key欄位
                dataWork.WhereFields(x => x.id, ids); //代入陣列Id值

                m_Product[] md_Origin = dataWork.DataByAdapter<m_Product>(); //取得Key值的Data

                //2、進行全部刪除
                dataWork.DeleteAll(); //先刪除DataTable
                dataWork.UpdateDataAdapter(); //在更新至DataBase Server
                Connection.EndCommit();
                r.Result = true;
                dataWork.Dispose(); //釋放資料
                md_Origin = null;
                return r;
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System; //系統失敗
                r.Message = PackErrMessage(ex); //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        public override RunQueryPackage<m_Product> SearchMaster(q_Product qr, int accountId)
        {
            #region 變數宣告
            RunQueryPackage<m_Product> r = new RunQueryPackage<m_Product>();
            #endregion
            try
            {
                #region Select Data 區段 By 條件
                #region 設定輸出至Grid欄位
                //TablePack<Product> dataWork = new TablePack<Product>(Connection) { LoginUserID = this.logPlamInfo.UserId, LoginUnitID = this.logPlamInfo.UnitId };
                Table3Join<Product, Product_Category_L1, Product_Category_L2> dataWork = new Table3Join<Product, Product_Category_L1, Product_Category_L2>(Connection) { };

                dataWork.SelectFields((x, y, z) => new { x.id, x.product_name, x.product_serial, x.member_price, x.original_price, x.special_price, x.currency, y.category_l1_name, z.category_l2_name, x.can_sell_amt, x.is_shelf,x.product_category });
                dataWork.JoinField_1_2(x => x.product_category_l1_id, y => y.id, JoinType.Inner);
                dataWork.JoinField_1_3(x => x.product_category_l2_id, z => z.id, JoinType.Inner);
                if (qr.MaxRecord > 0) dataWork.TopLimit = qr.MaxRecord;

                #endregion

                #region 設定Where條件
                if (qr.s_product_name != null)
                    dataWork.WhereFields((x, y, z) => x.product_name, qr.s_product_name, WhereCompareType.Like);

                if (qr.s_is_shelf != null)
                    dataWork.WhereFields((x, y, z) => x.is_shelf, qr.s_is_shelf);

                if (qr.s_product_state != null)
                    dataWork.WhereFields((x, y, z) => x.product_state, qr.s_product_state);

                if (qr.s_product_category_l1_id > 0)
                    dataWork.WhereFields((x, y, z) => x.product_category_l1_id, qr.s_product_category_l1_id);

                if (qr.s_product_category_l2_id > 0)
                    dataWork.WhereFields((x, y, z) => x.product_category_l2_id, qr.s_product_category_l2_id);

                if (qr.s_product_category != null)
                    dataWork.WhereFields((x, y, z) => x.product_category, qr.s_product_category);

                dataWork.WhereLang(); //使用語系條件
                #endregion

                #region 設定排序
                if (qr.sidx == null)
                    dataWork.OrderByFields((x, y, z) => x.id, OrderByType.DESC); //預設排序
                else if (qr.sidx == "sort")
                    dataWork.OrderByFields((x, y, z) => x.sort, OrderByType.DESC);
                #endregion

                #region 輸出物件陣列
                r.SearchData = dataWork.DataByAdapter<m_Product>();
                r.Result = true;
                return r;
                #endregion
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System; //系統失敗
                r.Message = PackErrMessage(ex); //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        public RunQueryPackage<m_Product> SearchMaster2(q_Product qr, int accountId)
        {
            #region 變數宣告
            RunQueryPackage<m_Product> r = new RunQueryPackage<m_Product>();
            #endregion
            try
            {
                #region Select Data 區段 By 條件
                #region 設定輸出至Grid欄位
                //TablePack<Product> dataWork = new TablePack<Product>(Connection) { LoginUserID = this.logPlamInfo.UserId, LoginUnitID = this.logPlamInfo.UnitId };
                Table3Join<Product, Product_Category_L1, Product_Category_L2> dataWork = new Table3Join<Product, Product_Category_L1, Product_Category_L2>(Connection) { };

                dataWork.SelectFields((x, y, z) => new { x.id, x.product_name, x.product_category,x.introduction,x.specifications });
                dataWork.JoinField_1_2(x => x.product_category_l1_id, y => y.id, JoinType.Inner);
                dataWork.JoinField_1_3(x => x.product_category_l2_id, z => z.id, JoinType.Inner);
                if (qr.MaxRecord > 0) dataWork.TopLimit = qr.MaxRecord;

                #endregion

                #region 設定Where條件
                if (qr.s_product_name != null)
                    dataWork.WhereFields((x, y, z) => x.product_name, qr.s_product_name, WhereCompareType.Like);

                if (qr.s_is_shelf != null)
                    dataWork.WhereFields((x, y, z) => x.is_shelf, qr.s_is_shelf);

                if (qr.s_product_state != null)
                    dataWork.WhereFields((x, y, z) => x.product_state, qr.s_product_state);

                if (qr.s_product_category_l1_id > 0)
                    dataWork.WhereFields((x, y, z) => x.product_category_l1_id, qr.s_product_category_l1_id);

                if (qr.s_product_category_l2_id > 0)
                    dataWork.WhereFields((x, y, z) => x.product_category_l2_id, qr.s_product_category_l2_id);

                if (qr.s_product_category != null)
                    dataWork.WhereFields((x, y, z) => x.product_category, qr.s_product_category);

                dataWork.WhereLang(); //使用語系條件
                #endregion

                #region 設定排序
                dataWork.OrderByFields((x, y, z) => x.sort, OrderByType.DESC);
                #endregion

                #region 輸出物件陣列
                r.SearchData = dataWork.DataByAdapter<m_Product>();
                r.Result = true;
                return r;
                #endregion
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System; //系統失敗
                r.Message = PackErrMessage(ex); //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        public override RunOneDataEnd<m_Product> GetDataMaster(int id, int accountId)
        {
            #region 變數宣告
            RunOneDataEnd<m_Product> r = new RunOneDataEnd<m_Product>();

            #endregion
            try
            {
                #region Main working
                TablePack<Product> dataWork = new TablePack<Product>(Connection) { LoginUserID = this.logPlamInfo.UserId, LoginUnitID = this.logPlamInfo.UnitId };
                dataWork.TableModule.KeyFieldModules[dataWork.TableModule.id.N].V = id; //設定KeyValue
                m_Product md = dataWork.GetDataByKey<m_Product>(); //取得Key該筆資料

                if (md == null) //如無資料
                    throw new LogicRoll("Log_Err_MustHaveData"); //此區一定有資料傳出，如無資料應檢查前端id值是否有誤

                r.SearchData = md;
                r.Result = true;
                dataWork.Dispose(); //釋放資料
                return r;
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System; //系統失敗
                r.Message = PackErrMessage(ex); //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        public override RunOneDataEnd<m_Product> GetDataMaster(int[] id, int accountId)
        {
            throw new NotImplementedException();
        }
    }
    #endregion
    #region Orders
    public class q_Orders : QueryBase
    {
        public String s_order_serial { set; get; }
        public String s_order_state { set; get; }
        public Int32 s_member_id { set; get; }
    }
    public class m_Orders : ModuleBase
    {
        ///<summary>
        ///Mapping:orders_id
        ///</summary>
        public Int32 id { get; set; }
        ///<summary>
        ///訂單編號
        ///</summary>
        public String order_serial { get; set; }
        ///<summary>
        ///訂單狀態
        ///</summary>
        public String order_state { get; set; }
        ///<summary>
        ///交易日期
        ///</summary>
        public DateTime transation_date { get; set; }
        ///<summary>
        ///運費
        ///</summary>
        public Decimal shipping_fee { get; set; }
        ///<summary>
        ///訂單金額
        ///</summary>
        public Decimal order_money { get; set; }
        ///<summary>
        ///總計金額
        ///</summary>
        public Decimal total_money { get; set; }
        public String order_name { get; set; }
        public Boolean order_gender { get; set; }
        public String order_zip { get; set; }
        public String order_address { get; set; }
        public String order_email { get; set; }
        public String order_tel { get; set; }
        ///<summary>
        ///訂單備註
        ///</summary>
        public String order_memo { get; set; }
        public String receive_name { get; set; }
        public Boolean receive_gender { get; set; }
        public String receive_zip { get; set; }
        public String receive_address { get; set; }
        public String receive_email { get; set; }
        public String receive_tel { get; set; }
        public DateTime? pay_date { get; set; }
        ///<summary>
        ///付款方式
        ///</summary>
        public String pay_style { get; set; }
        ///<summary>
        ///付款金額
        ///</summary>
        public Decimal pay_money { get; set; }
        ///<summary>
        ///付款狀態
        ///</summary>
        public String pay_state { get; set; }
        ///<summary>
        ///是否退貨
        ///</summary>
        public Boolean is_reject { get; set; }
        ///<summary>
        ///退貨日期
        ///</summary>
        public DateTime? reject_date { get; set; }
        ///<summary>
        ///退貨原因
        ///</summary>
        public String reject_reason { get; set; }
        ///<summary>
        ///統一編號
        ///</summary>
        public String vat_number { get; set; }
        ///<summary>
        ///會員序號
        ///</summary>
        public Int32 member_id { get; set; }

        public m_Orders_Detail[] order_detail { get; set; }


    }
    public class a_Orders : LogicBase<m_Orders, q_Orders, Orders>
    {
        public override RunInsertEnd InsertMaster(m_Orders md, int accountId)
        {
            #region Variable declare area
            RunInsertEnd r = new RunInsertEnd(); //宣告回傳物件
            #endregion
            try
            {
                #region Main working
                Connection.BeginTransaction(); //開始交易鎖定
                TablePack<Orders> dataWork = new TablePack<Orders>(Connection) { LoginUserID = this.logPlamInfo.UserId, LoginUnitID = this.logPlamInfo.UnitId };

                dataWork.NewRow(); //開始新橧作業 產生新的一行
                #region 指派值

                dataWork.SetDataRowValue(x => x.id, md.id);
                dataWork.SetDataRowValue(x => x.order_serial, md.order_serial);
                dataWork.SetDataRowValue(x => x.order_state, md.order_state);
                dataWork.SetDataRowValue(x => x.transation_date, md.transation_date);
                dataWork.SetDataRowValue(x => x.shipping_fee, md.shipping_fee);
                dataWork.SetDataRowValue(x => x.order_money, md.order_money);
                dataWork.SetDataRowValue(x => x.total_money, md.total_money);
                dataWork.SetDataRowValue(x => x.order_name, md.order_name);
                dataWork.SetDataRowValue(x => x.order_gender, md.order_gender);
                dataWork.SetDataRowValue(x => x.order_zip, md.order_zip);
                dataWork.SetDataRowValue(x => x.order_address, md.order_address);
                dataWork.SetDataRowValue(x => x.order_email, md.order_email);
                dataWork.SetDataRowValue(x => x.order_tel, md.order_tel);
                dataWork.SetDataRowValue(x => x.order_memo, md.order_memo);
                dataWork.SetDataRowValue(x => x.receive_name, md.receive_name);
                dataWork.SetDataRowValue(x => x.receive_gender, md.receive_gender);
                dataWork.SetDataRowValue(x => x.receive_zip, md.receive_zip);
                dataWork.SetDataRowValue(x => x.receive_address, md.receive_address);
                dataWork.SetDataRowValue(x => x.receive_email, md.receive_email);
                dataWork.SetDataRowValue(x => x.receive_tel, md.receive_tel);
                dataWork.SetDataRowValue(x => x.pay_date, md.pay_date);
                dataWork.SetDataRowValue(x => x.pay_style, md.pay_style);
                dataWork.SetDataRowValue(x => x.pay_money, md.pay_money);
                dataWork.SetDataRowValue(x => x.pay_state, md.pay_state);
                dataWork.SetDataRowValue(x => x.is_reject, md.is_reject);
                dataWork.SetDataRowValue(x => x.reject_date, md.reject_date);
                dataWork.SetDataRowValue(x => x.reject_reason, md.reject_reason);
                dataWork.SetDataRowValue(x => x.vat_number, md.vat_number);
                dataWork.SetDataRowValue(x => x.member_id, md.member_id);


                dataWork.UpdateFieldsInfo(UpdateFieldsInfoType.Insert); //進行更新時 需同時更新系統欄位 _新增人員，_新增日期
                dataWork.UpdateFieldsInfo(UpdateFieldsInfoType.Lang); //語系欄位設定
                //進行更新時 需同時更新系統欄位 _InsertUserID，_InsertDateTime
                #endregion
                dataWork.AddRow(); //加載至DataTable
                dataWork.UpdateDataAdapter(); //更新 DataBase Server

                Connection.EndCommit(); //交易確認

                r.Rows = dataWork.AffetCount; //取得影響筆數
                r.InsertId = dataWork.InsertAutoFieldsID; //取得新增後自動新增欄位的值
                r.Result = true; //回傳本次執行結果為成功
                dataWork.Dispose(); //釋放資料

                return r;
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System; //系統失敗
                r.Message = PackErrMessage(ex); //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        public override RunUpdateEnd UpdateMaster(m_Orders md, int accountId)
        {
            #region Variable declare area
            RunUpdateEnd r = new RunUpdateEnd();
            #endregion
            try
            {
                #region Main Working
                Connection.BeginTransaction();
                TablePack<Orders> dataWork = new TablePack<Orders>(Connection) { LoginUserID = this.logPlamInfo.UserId, LoginUnitID = this.logPlamInfo.UnitId };

                dataWork.TableModule.KeyFieldModules[dataWork.TableModule.id.N].V = md.id; //取得ID欄位的值
                m_Orders md_Origin = dataWork.GetDataByKey<m_Orders>(); //取得Key值的Data

                if (md_Origin == null) //如有資料
                    throw new LogicRoll("Log_Err_MustHaveData"); //此區一定有資料傳出，如無資料應檢查前端id值是否有誤

                dataWork.EditFirstRow(); //編輯第一筆資料，正常只會有一筆資料。
                #region 指派值

                dataWork.SetDataRowValue(x => x.id, md.id);
                //dataWork.SetDataRowValue(x => x.order_serial, md.order_serial);
                dataWork.SetDataRowValue(x => x.order_state, md.order_state);
                //dataWork.SetDataRowValue(x => x.transation_date, md.transation_date);
                dataWork.SetDataRowValue(x => x.shipping_fee, md.shipping_fee);
                //dataWork.SetDataRowValue(x => x.order_money, md.order_money);
                //dataWork.SetDataRowValue(x => x.total_money, md.total_money);

                //dataWork.SetDataRowValue(x => x.order_name, md.order_name);
                //dataWork.SetDataRowValue(x => x.order_gender, md.order_gender);
                //dataWork.SetDataRowValue(x => x.order_zip, md.order_zip);
                //dataWork.SetDataRowValue(x => x.order_address, md.order_address);
                //dataWork.SetDataRowValue(x => x.order_email, md.order_email);
                //dataWork.SetDataRowValue(x => x.order_tel, md.order_tel);
                dataWork.SetDataRowValue(x => x.order_memo, md.order_memo);
                dataWork.SetDataRowValue(x => x.receive_name, md.receive_name);
                dataWork.SetDataRowValue(x => x.receive_gender, md.receive_gender);
                dataWork.SetDataRowValue(x => x.receive_zip, md.receive_zip);
                dataWork.SetDataRowValue(x => x.receive_address, md.receive_address);
                dataWork.SetDataRowValue(x => x.receive_email, md.receive_email);
                dataWork.SetDataRowValue(x => x.receive_tel, md.receive_tel);
                //dataWork.SetDataRowValue(x => x.pay_date, md.pay_date);
                //dataWork.SetDataRowValue(x => x.pay_style, md.pay_style);
                //dataWork.SetDataRowValue(x => x.pay_money, md.pay_money);
                //dataWork.SetDataRowValue(x => x.pay_state, md.pay_state);
                //dataWork.SetDataRowValue(x => x.is_reject, md.is_reject);
                //dataWork.SetDataRowValue(x => x.reject_date, md.reject_date);
                //dataWork.SetDataRowValue(x => x.reject_reason, md.reject_reason);
                //dataWork.SetDataRowValue(x => x.vat_number, md.vat_number);
                //dataWork.SetDataRowValue(x => x.member_id, md.member_id);


                dataWork.UpdateFieldsInfo(UpdateFieldsInfoType.Update); //指定進行更新時 需同時更新系統欄位 _修改人員，_修改日期
                #endregion
                md_Origin = null;
                dataWork.UpdateDataAdapter(); //進行變更至Database Server
                CountTotal(md.id);

                Connection.EndCommit();

                r.Rows = dataWork.AffetCount; //取得影響筆數
                r.Result = true;
                dataWork.Dispose(); //釋放資料
                return r;
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System; //系統失敗
                r.Message = PackErrMessage(ex); //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        public override RunDeleteEnd DeleteMaster(Int32[] ids, int accountId)
        {
            //此功能主要搭配Grid介面刪除功能製作
            #region Variable declare area
            RunDeleteEnd r = new RunDeleteEnd(); //宣告刪除Result回物件
            #endregion
            try
            {
                #region Main working
                Connection.BeginTransaction();
                //1、要刪除的資料先選出來
                TablePack<Orders> dataWork = new TablePack<Orders>(Connection) { LoginUserID = this.logPlamInfo.UserId, LoginUnitID = this.logPlamInfo.UnitId }; //宣告泛型物件並連接Connection
                dataWork.SelectFields(x => x.id); //只Select 主Key欄位
                dataWork.WhereFields(x => x.id, ids); //代入陣列Id值

                m_Orders[] md_Origin = dataWork.DataByAdapter<m_Orders>(); //取得Key值的Data

                //2、進行全部刪除
                dataWork.DeleteAll(); //先刪除DataTable
                dataWork.UpdateDataAdapter(); //在更新至DataBase Server
                Connection.EndCommit();
                r.Result = true;
                dataWork.Dispose(); //釋放資料
                md_Origin = null;
                return r;
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System; //系統失敗
                r.Message = PackErrMessage(ex); //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        public override RunQueryPackage<m_Orders> SearchMaster(q_Orders qr, int accountId)
        {
            #region 變數宣告
            RunQueryPackage<m_Orders> r = new RunQueryPackage<m_Orders>();
            #endregion
            try
            {
                #region Select Data 區段 By 條件
                #region 設定輸出至Grid欄位
                TablePack<Orders> dataWork = new TablePack<Orders>(Connection) { LoginUserID = this.logPlamInfo.UserId, LoginUnitID = this.logPlamInfo.UnitId };
                dataWork.SelectFields(x => new { x.id, x.order_serial, x.receive_name, x.receive_tel, x.transation_date, x.order_state });

                if (qr.MaxRecord > 0) dataWork.TopLimit = qr.MaxRecord;

                #endregion

                #region 設定Where條件
                if (qr.s_order_serial != null)
                    dataWork.WhereFields(x => x.order_serial, qr.s_order_serial, WhereCompareType.LikeRight);

                if (qr.s_order_state != null)
                    dataWork.WhereFields(x => x.order_state, qr.s_order_state);

                //dataWork.WhereLang(); //使用語系條件
                #endregion

                #region 設定排序
                if (qr.sidx == null)
                    dataWork.OrderByFields(x => x.transation_date, OrderByType.DESC); //預設排序
                else
                    dataWork.OrderByFields(x => x.id, OrderByType.ASC);
                #endregion

                #region 輸出物件陣列
                r.SearchData = dataWork.DataByAdapter<m_Orders>();
                r.Result = true;
                return r;
                #endregion
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System; //系統失敗
                r.Message = PackErrMessage(ex); //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        public RunQueryPackage<m_Orders> SearchMaster2(q_Orders qr, int accountId)
        {
            #region 變數宣告
            RunQueryPackage<m_Orders> r = new RunQueryPackage<m_Orders>();
            #endregion
            try
            {
                #region Select Data 區段 By 條件
                #region 設定輸出至Grid欄位
                TablePack<Orders> dataWork = new TablePack<Orders>(Connection) { LoginUserID = this.logPlamInfo.UserId, LoginUnitID = this.logPlamInfo.UnitId };
                dataWork.SelectFields(x => new { x.id, x.order_serial, x.transation_date, x.order_state, x.total_money, x.receive_name, x.receive_tel, x.receive_address });

                if (qr.MaxRecord > 0) dataWork.TopLimit = qr.MaxRecord;

                #endregion

                #region 設定Where條件
                dataWork.WhereFields(x => x.member_id, qr.s_member_id);
                dataWork.OrderByFields(x => x.transation_date, OrderByType.DESC); //預設排序
                #endregion

                #region 輸出物件陣列
                r.SearchData = dataWork.DataByAdapter<m_Orders>();
                r.Result = true;
                return r;
                #endregion
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System; //系統失敗
                r.Message = PackErrMessage(ex); //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        public override RunOneDataEnd<m_Orders> GetDataMaster(int id, int accountId)
        {
            #region 變數宣告
            RunOneDataEnd<m_Orders> r = new RunOneDataEnd<m_Orders>();

            #endregion
            try
            {
                #region Main working
                TablePack<Orders> dataWork = new TablePack<Orders>(Connection) { LoginUserID = this.logPlamInfo.UserId, LoginUnitID = this.logPlamInfo.UnitId };
                dataWork.TableModule.KeyFieldModules[dataWork.TableModule.id.N].V = id; //設定KeyValue
                m_Orders md = dataWork.GetDataByKey<m_Orders>(); //取得Key該筆資料

                if (md == null) //如無資料
                    throw new LogicRoll("Log_Err_MustHaveData"); //此區一定有資料傳出，如無資料應檢查前端id值是否有誤

                r.SearchData = md;
                r.Result = true;
                dataWork.Dispose(); //釋放資料
                return r;
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System; //系統失敗
                r.Message = PackErrMessage(ex); //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        public override RunOneDataEnd<m_Orders> GetDataMaster(int[] id, int accountId)
        {
            throw new NotImplementedException();
        }
        public RunInsertEnd InsertCross(m_Orders Orders, m_Orders_Detail[] Orders_Details, int accountId)
        {
            #region Variable declare area
            RunInsertEnd r = new RunInsertEnd(); //宣告回傳物件
            #endregion
            try
            {
                #region Main working
                Connection.Tran(); //開始交易鎖定
                RunInsertEnd r1 = InsertMaster(Orders, accountId);

                if (!r1.Result)
                {
                    if (r1.ErrType == BusinessErrType.Logic)
                        throw new LogicRoll(r1.Message);

                    if (r1.ErrType == BusinessErrType.System)
                        throw new Exception(r1.Message);
                }

                r.InsertId = r1.InsertId;

                a_Orders_Detail ac_Orders_Detail = new a_Orders_Detail() { Connection = this.Connection, logPlamInfo = logPlamInfo };
                foreach (m_Orders_Detail Detail in Orders_Details)
                {
                    RunInsertEnd r2 = ac_Orders_Detail.InsertMaster(Detail, accountId);
                    if (!r2.Result)
                    {
                        if (r2.ErrType == BusinessErrType.Logic)
                            throw new LogicRoll(r2.Message);

                        if (r2.ErrType == BusinessErrType.System)
                            throw new Exception(r2.Message);
                    }
                }

                Connection.Commit();
                r.Result = true;
                return r;
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Roll(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Roll(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System; //系統失敗
                r.Message = PackErrMessage(ex); //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        public String GetOrdersSN()
        {

            String tpl = "SN{0}{1:00}{2:00}-{3:00}{4:00}";
            snObject sn = GetSNInfo(SNType.Orders);
            return String.Format(tpl, sn.y.ToString().Right(2), sn.m, sn.d, sn.sn_max, (new Random()).Next(99));
        }
        public snObject GetSNInfo(SNType snType)
        {
            snObject sn = new snObject();

            String Sql = "Select y,m,d,sn_max From _SN Where sn_type=@sn_type";
            Connection.AddParm("sn_type", snType.ToString());
            DataTable dt = Connection.ExecuteData(Sql);
            DataRow dr = dt.Rows[0];
            Connection.ClearParm();

            if ((int)dr["y"] == DateTime.Now.Year && (int)dr["m"] == DateTime.Now.Month && (int)dr["d"] == DateTime.Now.Day)
            {
                Sql = "Update _SN Set sn_max=sn_max + 1 Where sn_type=@sn_type";
                Connection.AddParm("sn_type", "Orders");
                Connection.Open();
                Connection.ExecuteNonQuery(Sql);
                Connection.Close();

                sn.y = (int)dr["y"];
                sn.m = (int)dr["m"];
                sn.d = (int)dr["d"];
                sn.sn_max = (int)dr["sn_max"] + 1;
            }
            else
            {
                Sql = "Update _SN Set y=@Y , m=@M , d=@D , sn_max=1 Where sn_type=@sn_type";
                Connection.AddParm("Y", DateTime.Now.Year);
                Connection.AddParm("M", DateTime.Now.Month);
                Connection.AddParm("D", DateTime.Now.Day);
                Connection.AddParm("sn_type", "Orders");
                Connection.Open();
                Connection.ExecuteNonQuery(Sql);
                Connection.Close();
                sn.y = DateTime.Now.Year;
                sn.m = DateTime.Now.Month;
                sn.d = DateTime.Now.Day;
                sn.sn_max = 1;
            }
            return sn;
        }
        public void CountTotal(Int32 orders_id)
        {
            TablePack<Orders_Detail> dataWork = new TablePack<Orders_Detail>(Connection) { LoginUserID = this.logPlamInfo.UserId, LoginUnitID = this.logPlamInfo.UnitId };
            dataWork.SelectFields(x => new { x.ids, x.amt, x.unit_price, x.subtotal });
            dataWork.WhereFields(x => x.orders_id, orders_id);
            m_Orders_Detail[] mds = dataWork.DataByAdapter<m_Orders_Detail>();

            TablePack<Orders> dataMaster = new TablePack<Orders>(Connection) { LoginUserID = this.logPlamInfo.UserId, LoginUnitID = this.logPlamInfo.UnitId };
            dataMaster.TableModule.KeyFieldModules[dataMaster.TableModule.id.N].V = orders_id; //設定KeyValue
            m_Orders md = dataMaster.GetDataByKey<m_Orders>();
            dataMaster.EditFirstRow();
            dataMaster.SetDataRowValue(x => x.order_money, mds.Sum(x => x.subtotal));
            dataMaster.SetDataRowValue(x => x.total_money, mds.Sum(x => x.subtotal) + md.shipping_fee);
            dataMaster.UpdateDataAdapter();
        }
    }
    #endregion
    #region Orders_Detail
    public class q_Orders_Detail : QueryBase
    {
        public Int32? s_orders_id { set; get; }
        public String s_order_serial { set; get; }
    }
    public class m_Orders_Detail : ModuleBase
    {
        ///<summary>
        ///Mapping:orders_detail_id
        ///</summary>
        public Int32 ids { get; set; }
        public String order_serial { get; set; }
        public Int32 orders_id { get; set; }
        public Int32 product_id { get; set; }
        public String product_name { get; set; }
        public String product_serial { get; set; }
        public Int16 item_no { get; set; }
        public Decimal amt { get; set; }
        ///<summary>
        ///單價

        ///</summary>
        public Decimal unit_price { get; set; }
        ///<summary>
        ///計價單位

        ///</summary>
        public String unit_name { get; set; }
        ///<summary>
        ///計價幣別

        ///</summary>
        public String currency { get; set; }
        ///<summary>
        ///小計

        ///</summary>
        public Decimal subtotal { get; set; }
    }
    public class a_Orders_Detail : LogicBase<m_Orders_Detail, q_Orders_Detail, Orders_Detail>
    {
        public override RunInsertEnd InsertMaster(m_Orders_Detail md, int accountId)
        {
            #region Variable declare area
            RunInsertEnd r = new RunInsertEnd(); //宣告回傳物件
            #endregion
            try
            {
                #region Main working
                Connection.BeginTransaction(); //開始交易鎖定
                TablePack<Orders_Detail> dataWork = new TablePack<Orders_Detail>(Connection) { LoginUserID = this.logPlamInfo.UserId, LoginUnitID = this.logPlamInfo.UnitId };

                dataWork.NewRow(); //開始新橧作業 產生新的一行
                #region 指派值

                dataWork.SetDataRowValue(x => x.ids, md.ids);
                dataWork.SetDataRowValue(x => x.order_serial, md.order_serial);
                dataWork.SetDataRowValue(x => x.orders_id, md.orders_id);
                dataWork.SetDataRowValue(x => x.product_id, md.product_id);
                dataWork.SetDataRowValue(x => x.product_name, md.product_name);
                dataWork.SetDataRowValue(x => x.item_no, md.item_no);
                dataWork.SetDataRowValue(x => x.amt, md.amt);
                dataWork.SetDataRowValue(x => x.unit_price, md.unit_price);
                dataWork.SetDataRowValue(x => x.unit_name, md.unit_name);
                dataWork.SetDataRowValue(x => x.currency, md.currency);
                dataWork.SetDataRowValue(x => x.subtotal, md.subtotal);
                dataWork.SetDataRowValue(x => x.product_serial, md.product_serial);

                dataWork.UpdateFieldsInfo(UpdateFieldsInfoType.Insert); //進行更新時 需同時更新系統欄位 _新增人員，_新增日期
                dataWork.UpdateFieldsInfo(UpdateFieldsInfoType.Lang); //語系欄位設定
                //進行更新時 需同時更新系統欄位 _InsertUserID，_InsertDateTime
                #endregion
                dataWork.AddRow(); //加載至DataTable
                dataWork.UpdateDataAdapter(); //更新 DataBase Server

                Connection.EndCommit(); //交易確認

                r.Rows = dataWork.AffetCount; //取得影響筆數
                r.InsertId = dataWork.InsertAutoFieldsID; //取得新增後自動新增欄位的值
                r.Result = true; //回傳本次執行結果為成功
                dataWork.Dispose(); //釋放資料

                return r;
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System; //系統失敗
                r.Message = PackErrMessage(ex); //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        public override RunUpdateEnd UpdateMaster(m_Orders_Detail md, int accountId)
        {
            #region Variable declare area
            RunUpdateEnd r = new RunUpdateEnd();
            #endregion
            try
            {
                #region Main Working
                Connection.BeginTransaction();
                TablePack<Orders_Detail> dataWork = new TablePack<Orders_Detail>(Connection) { LoginUserID = this.logPlamInfo.UserId, LoginUnitID = this.logPlamInfo.UnitId };

                dataWork.TableModule.KeyFieldModules[dataWork.TableModule.ids.N].V = md.ids; //取得ID欄位的值
                m_Orders_Detail md_Origin = dataWork.GetDataByKey<m_Orders_Detail>(); //取得Key值的Data

                if (md_Origin == null) //如有資料
                    throw new LogicRoll("Log_Err_MustHaveData"); //此區一定有資料傳出，如無資料應檢查前端id值是否有誤

                dataWork.EditFirstRow(); //編輯第一筆資料，正常只會有一筆資料。
                #region 指派值

                //dataWork.SetDataRowValue(x => x.id, md.id);
                //dataWork.SetDataRowValue(x => x.order_serial, md.order_serial);
                //dataWork.SetDataRowValue(x => x.orders_id, md.orders_id);
                //dataWork.SetDataRowValue(x => x.product_id, md.product_id);
                //dataWork.SetDataRowValue(x => x.product_name, md.product_name);
                //dataWork.SetDataRowValue(x => x.item_no, md.item_no);
                dataWork.SetDataRowValue(x => x.amt, md.amt);
                //dataWork.SetDataRowValue(x => x.unit_price, md.unit_price);
                //dataWork.SetDataRowValue(x => x.unit_name, md.unit_name);
                //dataWork.SetDataRowValue(x => x.currency, md.currency);
                dataWork.SetDataRowValue(x => x.subtotal, md.amt * md.unit_price);

                dataWork.UpdateFieldsInfo(UpdateFieldsInfoType.Update); //指定進行更新時 需同時更新系統欄位 _修改人員，_修改日期
                #endregion
                md_Origin = null;
                dataWork.UpdateDataAdapter(); //進行變更至Database Server
                Connection.EndCommit();

                r.Rows = dataWork.AffetCount; //取得影響筆數
                r.Result = true;
                dataWork.Dispose(); //釋放資料
                return r;
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System; //系統失敗
                r.Message = PackErrMessage(ex); //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        public override RunDeleteEnd DeleteMaster(Int32[] ids, int accountId)
        {
            //此功能主要搭配Grid介面刪除功能製作
            #region Variable declare area
            RunDeleteEnd r = new RunDeleteEnd(); //宣告刪除Result回物件
            #endregion
            try
            {
                #region Main working
                Connection.BeginTransaction();
                //1、要刪除的資料先選出來
                TablePack<Orders_Detail> dataWork = new TablePack<Orders_Detail>(Connection) { LoginUserID = this.logPlamInfo.UserId, LoginUnitID = this.logPlamInfo.UnitId }; //宣告泛型物件並連接Connection
                dataWork.SelectFields(x => x.ids); //只Select 主Key欄位
                dataWork.WhereFields(x => x.ids, ids); //代入陣列Id值

                m_Orders_Detail[] md_Origin = dataWork.DataByAdapter<m_Orders_Detail>(); //取得Key值的Data
                Int32 order_id = md_Origin[0].orders_id;

                //2、進行全部刪除
                dataWork.DeleteAll(); //先刪除DataTable
                dataWork.UpdateDataAdapter(); //在更新至DataBase Server
                Connection.EndCommit();
                r.Result = true;
                dataWork.Dispose(); //釋放資料
                md_Origin = null;
                return r;
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System; //系統失敗
                r.Message = PackErrMessage(ex); //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        public override RunQueryPackage<m_Orders_Detail> SearchMaster(q_Orders_Detail qr, int accountId)
        {
            #region 變數宣告
            RunQueryPackage<m_Orders_Detail> r = new RunQueryPackage<m_Orders_Detail>();
            #endregion
            try
            {
                #region Select Data 區段 By 條件
                #region 設定輸出至Grid欄位
                TablePack<Orders_Detail> dataWork = new TablePack<Orders_Detail>(Connection) { LoginUserID = this.logPlamInfo.UserId, LoginUnitID = this.logPlamInfo.UnitId };
                dataWork.SelectFields(x => new { x.ids, x.item_no, x.orders_id, x.product_serial, x.product_id, x.product_name, x.amt, x.unit_price, x.currency, x.unit_name, x.subtotal });

                if (qr.MaxRecord > 0) dataWork.TopLimit = qr.MaxRecord;

                #endregion

                #region 設定Where條件
                if (qr.s_order_serial != null)
                    dataWork.WhereFields(x => x.order_serial, qr.s_order_serial, WhereCompareType.Like);

                if (qr.s_orders_id != null)
                    dataWork.WhereFields(x => x.orders_id, qr.s_orders_id);

                dataWork.WhereLang(); //使用語系條件
                #endregion

                #region 設定排序
                if (qr.sidx == null)
                    dataWork.OrderByFields(x => x.item_no); //預設排序
                else
                    dataWork.OrderByFields(x => x.ids);
                #endregion

                #region 輸出物件陣列
                r.SearchData = dataWork.DataByAdapter<m_Orders_Detail>();
                r.Result = true;
                return r;
                #endregion
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System; //系統失敗
                r.Message = PackErrMessage(ex); //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        public RunQueryPackage<m_Orders_Detail> SearchMaster2(q_Orders_Detail qr, int accountId)
        {
            #region 變數宣告
            RunQueryPackage<m_Orders_Detail> r = new RunQueryPackage<m_Orders_Detail>();
            #endregion
            try
            {
                #region Select Data 區段 By 條件
                #region 設定輸出至Grid欄位
                TablePack<Orders_Detail> dataWork = new TablePack<Orders_Detail>(Connection) { LoginUserID = this.logPlamInfo.UserId, LoginUnitID = this.logPlamInfo.UnitId };
                dataWork.SelectFields(x => new { x.ids, x.item_no, x.orders_id, x.product_serial, x.product_id, x.product_name, x.amt, x.unit_price, x.currency, x.unit_name, x.subtotal });

                if (qr.MaxRecord > 0) dataWork.TopLimit = qr.MaxRecord;

                #endregion

                #region 設定Where條件
                dataWork.WhereFields(x => x.orders_id, qr.s_orders_id);
                dataWork.OrderByFields(x => x.item_no); //預設排序
                #endregion

                #region 輸出物件陣列
                r.SearchData = dataWork.DataByAdapter<m_Orders_Detail>();
                r.Result = true;
                return r;
                #endregion
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System; //系統失敗
                r.Message = PackErrMessage(ex); //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        public override RunOneDataEnd<m_Orders_Detail> GetDataMaster(int id, int accountId)
        {
            #region 變數宣告
            RunOneDataEnd<m_Orders_Detail> r = new RunOneDataEnd<m_Orders_Detail>();

            #endregion
            try
            {
                #region Main working
                TablePack<Orders_Detail> dataWork = new TablePack<Orders_Detail>(Connection) { LoginUserID = this.logPlamInfo.UserId, LoginUnitID = this.logPlamInfo.UnitId };
                dataWork.TableModule.KeyFieldModules[dataWork.TableModule.ids.N].V = id; //設定KeyValue
                m_Orders_Detail md = dataWork.GetDataByKey<m_Orders_Detail>(); //取得Key該筆資料

                if (md == null) //如無資料
                    throw new LogicRoll("Log_Err_MustHaveData"); //此區一定有資料傳出，如無資料應檢查前端id值是否有誤

                r.SearchData = md;
                r.Result = true;
                dataWork.Dispose(); //釋放資料
                return r;
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System; //系統失敗
                r.Message = PackErrMessage(ex); //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        public override RunOneDataEnd<m_Orders_Detail> GetDataMaster(int[] id, int accountId)
        {
            throw new NotImplementedException();
        }
    }
    #endregion
    #region Member
    public class q_Member : QueryBase
    {
        public String s_member_name { set; get; }
        public String s_email { set; get; }
        public String s_tel { set; get; }
        public String s_password { set; get; }

        public Object valid_code { set; get; }
    }
    public class m_Member : ModuleBase
    {
        ///<summary>
        ///Mapping:member_id
        ///</summary>
        public Int32 id { get; set; }
        public String member_name { get; set; }
        public Boolean gender { get; set; }
        ///<summary>
        ///會員電子郵件

        ///</summary>
        public String email { get; set; }
        ///<summary>
        ///密碼

        ///</summary>
        public String password { get; set; }
        public String tel { get; set; }
        public String mobile { get; set; }
        public String zip { get; set; }
        public String address { get; set; }
        public DateTime? birthday { get; set; }
        public String state { get; set; }
        public Object valid_code { get; set; }
        public String new_email { get; set; }
        public String confirm_password { get; set; }
        public Boolean isChangeEmail { get; set; }
    }
    public class a_Member : LogicBase<m_Member, q_Member, Member>
    {
        public override RunInsertEnd InsertMaster(m_Member md, int accountId)
        {
            #region Variable declare area
            RunInsertEnd r = new RunInsertEnd(); //宣告回傳物件
            #endregion
            try
            {
                #region Main working
                Connection.BeginTransaction(); //開始交易鎖定
                TablePack<Member> dataWork = new TablePack<Member>(Connection) { LoginUserID = this.logPlamInfo.UserId, LoginUnitID = this.logPlamInfo.UnitId };

                dataWork.NewRow(); //開始新橧作業 產生新的一行
                #region 指派值

                dataWork.SetDataRowValue(x => x.id, md.id);
                dataWork.SetDataRowValue(x => x.member_name, md.member_name);
                dataWork.SetDataRowValue(x => x.gender, md.gender);
                dataWork.SetDataRowValue(x => x.email, md.email);
                dataWork.SetDataRowValue(x => x.password, md.password);
                dataWork.SetDataRowValue(x => x.tel, md.tel);
                dataWork.SetDataRowValue(x => x.mobile, md.mobile);
                dataWork.SetDataRowValue(x => x.zip, md.zip);
                dataWork.SetDataRowValue(x => x.address, md.address);
                dataWork.SetDataRowValue(x => x.birthday, md.birthday);
                dataWork.SetDataRowValue(x => x.state, md.state);
                dataWork.SetDataRowValue(x => x.valid_code, md.valid_code);

                dataWork.UpdateFieldsInfo(UpdateFieldsInfoType.Insert); //進行更新時 需同時更新系統欄位 _新增人員，_新增日期
                dataWork.UpdateFieldsInfo(UpdateFieldsInfoType.Lang); //語系欄位設定
                //進行更新時 需同時更新系統欄位 _InsertUserID，_InsertDateTime
                #endregion
                dataWork.AddRow(); //加載至DataTable
                dataWork.UpdateDataAdapter(); //更新 DataBase Server

                Connection.EndCommit(); //交易確認

                r.Rows = dataWork.AffetCount; //取得影響筆數
                r.InsertId = md.id; //取得新增後自動新增欄位的值
                r.Result = true; //回傳本次執行結果為成功
                dataWork.Dispose(); //釋放資料

                return r;
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System; //系統失敗
                r.Message = PackErrMessage(ex); //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        public override RunUpdateEnd UpdateMaster(m_Member md, int accountId)
        {
            #region Variable declare area
            RunUpdateEnd r = new RunUpdateEnd();
            #endregion
            try
            {
                #region Main Working
                Connection.BeginTransaction();
                TablePack<Member> dataWork = new TablePack<Member>(Connection) { LoginUserID = this.logPlamInfo.UserId, LoginUnitID = this.logPlamInfo.UnitId };

                dataWork.TableModule.KeyFieldModules[dataWork.TableModule.id.N].V = md.id; //取得ID欄位的值
                m_Member md_Origin = dataWork.GetDataByKey<m_Member>(); //取得Key值的Data

                if (md_Origin == null) //如有資料
                    throw new LogicRoll("Log_Err_MustHaveData"); //此區一定有資料傳出，如無資料應檢查前端id值是否有誤

                dataWork.EditFirstRow(); //編輯第一筆資料，正常只會有一筆資料。
                #region 指派值

                dataWork.SetDataRowValue(x => x.id, md.id);
                dataWork.SetDataRowValue(x => x.member_name, md.member_name);
                dataWork.SetDataRowValue(x => x.gender, md.gender);
                //dataWork.SetDataRowValue(x => x.email, md.email);
                //dataWork.SetDataRowValue(x => x.password, md.password);
                dataWork.SetDataRowValue(x => x.tel, md.tel);
                dataWork.SetDataRowValue(x => x.mobile, md.mobile);
                dataWork.SetDataRowValue(x => x.zip, md.zip);
                dataWork.SetDataRowValue(x => x.address, md.address);
                dataWork.SetDataRowValue(x => x.birthday, md.birthday);
                dataWork.SetDataRowValue(x => x.state, md.state);


                dataWork.UpdateFieldsInfo(UpdateFieldsInfoType.Update); //指定進行更新時 需同時更新系統欄位 _修改人員，_修改日期
                #endregion
                md_Origin = null;
                dataWork.UpdateDataAdapter(); //進行變更至Database Server

                Connection.EndCommit();

                r.Rows = dataWork.AffetCount; //取得影響筆數
                r.Result = true;
                dataWork.Dispose(); //釋放資料
                return r;
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System; //系統失敗
                r.Message = PackErrMessage(ex); //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        public RunUpdateEnd UpdateMaster_Web(m_Member md, int accountId)
        {
            #region Variable declare area
            RunUpdateEnd r = new RunUpdateEnd();
            #endregion
            try
            {
                #region Main Working
                Connection.BeginTransaction();
                TablePack<Member> dataWork = new TablePack<Member>(Connection) { LoginUserID = this.logPlamInfo.UserId, LoginUnitID = this.logPlamInfo.UnitId };

                dataWork.TableModule.KeyFieldModules[dataWork.TableModule.id.N].V = md.id; //取得ID欄位的值
                m_Member md_Origin = dataWork.GetDataByKey<m_Member>(); //取得Key值的Data

                if (md_Origin == null) //如有資料
                    throw new LogicRoll("Log_Err_MustHaveData"); //此區一定有資料傳出，如無資料應檢查前端id值是否有誤

                dataWork.EditFirstRow(); //編輯第一筆資料，正常只會有一筆資料。
                #region 指派值

                dataWork.SetDataRowValue(x => x.member_name, md.member_name);
                dataWork.SetDataRowValue(x => x.gender, md.gender);
                dataWork.SetDataRowValue(x => x.tel, md.tel);
                dataWork.SetDataRowValue(x => x.zip, md.zip);
                dataWork.SetDataRowValue(x => x.address, md.address);
                dataWork.SetDataRowValue(x => x.birthday, md.birthday);

                if (md.isChangeEmail)
                {
                    if (md.confirm_password.Equals(md_Origin.password))
                    {
                        dataWork.SetDataRowValue(x => x.email, md.new_email);
                    }
                    else
                    {
                        throw new LogicRoll("Err_PasswordNotCorrect");
                    }
                }


                dataWork.UpdateFieldsInfo(UpdateFieldsInfoType.Update); //指定進行更新時 需同時更新系統欄位 _修改人員，_修改日期
                #endregion
                md_Origin = null;
                dataWork.UpdateDataAdapter(); //進行變更至Database Server

                Connection.EndCommit();

                r.Rows = dataWork.AffetCount; //取得影響筆數
                r.Result = true;
                dataWork.Dispose(); //釋放資料
                return r;
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System; //系統失敗
                r.Message = PackErrMessage(ex); //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        public RunUpdateEnd UpdateMaster_Address(int id, String zip, String address, int accountId)
        {
            #region Variable declare area
            RunUpdateEnd r = new RunUpdateEnd();
            #endregion
            try
            {
                #region Main Working
                Connection.BeginTransaction();
                TablePack<Member> dataWork = new TablePack<Member>(Connection) { LoginUserID = this.logPlamInfo.UserId, LoginUnitID = this.logPlamInfo.UnitId };

                dataWork.TableModule.KeyFieldModules[dataWork.TableModule.id.N].V = id; //取得ID欄位的值
                m_Member md_Origin = dataWork.GetDataByKey<m_Member>(); //取得Key值的Data

                if (md_Origin == null) //如有資料
                    throw new LogicRoll("Log_Err_MustHaveData"); //此區一定有資料傳出，如無資料應檢查前端id值是否有誤

                dataWork.EditFirstRow(); //編輯第一筆資料，正常只會有一筆資料。
                #region 指派值

                dataWork.SetDataRowValue(x => x.zip, zip);
                dataWork.SetDataRowValue(x => x.address, address);

                dataWork.UpdateFieldsInfo(UpdateFieldsInfoType.Update); //指定進行更新時 需同時更新系統欄位 _修改人員，_修改日期
                #endregion
                md_Origin = null;
                dataWork.UpdateDataAdapter(); //進行變更至Database Server

                Connection.EndCommit();

                r.Rows = dataWork.AffetCount; //取得影響筆數
                r.Result = true;
                dataWork.Dispose(); //釋放資料
                return r;
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System; //系統失敗
                r.Message = PackErrMessage(ex); //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        public RunUpdateEnd UpdateMaster_Email(int id, String email, int accountId)
        {
            #region Variable declare area
            RunUpdateEnd r = new RunUpdateEnd();
            #endregion
            try
            {
                #region Main Working
                Connection.BeginTransaction();
                TablePack<Member> dataWork = new TablePack<Member>(Connection) { LoginUserID = this.logPlamInfo.UserId, LoginUnitID = this.logPlamInfo.UnitId };

                dataWork.TableModule.KeyFieldModules[dataWork.TableModule.id.N].V = id; //取得ID欄位的值
                m_Member md_Origin = dataWork.GetDataByKey<m_Member>(); //取得Key值的Data

                if (md_Origin == null) //如有資料
                    throw new LogicRoll("Log_Err_MustHaveData"); //此區一定有資料傳出，如無資料應檢查前端id值是否有誤

                dataWork.EditFirstRow(); //編輯第一筆資料，正常只會有一筆資料。
                #region 指派值
                dataWork.SetDataRowValue(x => x.email, email);

                dataWork.UpdateFieldsInfo(UpdateFieldsInfoType.Update); //指定進行更新時 需同時更新系統欄位 _修改人員，_修改日期
                #endregion
                md_Origin = null;
                dataWork.UpdateDataAdapter(); //進行變更至Database Server

                Connection.EndCommit();

                r.Rows = dataWork.AffetCount; //取得影響筆數
                r.Result = true;
                dataWork.Dispose(); //釋放資料
                return r;
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System; //系統失敗
                r.Message = PackErrMessage(ex); //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        public RunUpdateEnd UpdateMaster_Password(changePassword pwd, int accountId)
        {
            RunUpdateEnd r = new RunUpdateEnd();
            Member TObj = new Member();
            Connection.BeginTransaction();

            try
            {
                TablePack<Member> dataWork = new TablePack<Member>(Connection) { TableModule = TObj };

                dataWork.SelectFields(x => new { x.id, x.password });
                dataWork.WhereFields(x => x.id, pwd.id);

                m_Member md = dataWork.DataByAdapter<m_Member>().FirstOrDefault();

                String GetNowPassword = md.password;

                if (GetNowPassword != pwd.o)
                    throw new LogicRoll("Log_Err_Password");

                if (GetNowPassword == pwd.n)
                    throw new LogicRoll("Log_Err_NewPasswordSame");

                if (pwd.o != pwd.s)
                    throw new LogicRoll("Log_Err_NewPasswordNotSure");

                dataWork.EditFirstRow();
                dataWork.SetDataRowValue(x => x.password, pwd.n);
                dataWork.UpdateDataAdapter();

                Connection.EndCommit();
                r.Result = true;
                return r;
            }
            catch (LogicRoll ex)
            {
                Connection.Rollback();

                r.Result = false;
                r.ErrType = BusinessErrType.Logic;
                r.Message = ex.Message;
                return r;
            }
            catch (Exception ex)
            {
                Connection.Rollback();
                r.Result = false;
                r.ErrType = BusinessErrType.System;
                r.Message = PackErrMessage(ex);
                return r;
            }
        }
        public override RunDeleteEnd DeleteMaster(Int32[] ids, int accountId)
        {
            //此功能主要搭配Grid介面刪除功能製作
            #region Variable declare area
            RunDeleteEnd r = new RunDeleteEnd(); //宣告刪除Result回物件
            #endregion
            try
            {
                #region Main working
                Connection.BeginTransaction();
                //1、要刪除的資料先選出來
                TablePack<Member> dataWork = new TablePack<Member>(Connection) { LoginUserID = this.logPlamInfo.UserId, LoginUnitID = this.logPlamInfo.UnitId }; //宣告泛型物件並連接Connection
                dataWork.SelectFields(x => x.id); //只Select 主Key欄位
                dataWork.WhereFields(x => x.id, ids); //代入陣列Id值

                m_Member[] md_Origin = dataWork.DataByAdapter<m_Member>(); //取得Key值的Data

                //2、進行全部刪除
                dataWork.DeleteAll(); //先刪除DataTable
                dataWork.UpdateDataAdapter(); //在更新至DataBase Server
                Connection.EndCommit();
                r.Result = true;
                dataWork.Dispose(); //釋放資料
                md_Origin = null;
                return r;
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System; //系統失敗
                r.Message = PackErrMessage(ex); //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        public override RunQueryPackage<m_Member> SearchMaster(q_Member qr, int accountId)
        {
            #region 變數宣告
            RunQueryPackage<m_Member> r = new RunQueryPackage<m_Member>();
            #endregion
            try
            {
                #region Select Data 區段 By 條件
                #region 設定輸出至Grid欄位
                TablePack<Member> dataWork = new TablePack<Member>(Connection) { LoginUserID = this.logPlamInfo.UserId, LoginUnitID = this.logPlamInfo.UnitId };
                dataWork.SelectFields(x => new { x.id, x.member_name, x.email, x.state });

                if (qr.MaxRecord > 0) dataWork.TopLimit = qr.MaxRecord;

                #endregion

                #region 設定Where條件
                if (qr.s_member_name != null)
                    dataWork.WhereFields(x => x.member_name, qr.s_member_name, WhereCompareType.Like);

                if (qr.s_email != null)
                    dataWork.WhereFields(x => x.email, qr.s_email);

                if (qr.s_tel != null)
                    dataWork.WhereFields(x => x.tel, qr.s_tel, WhereCompareType.LikeRight);

                if (qr.s_password != null)
                    dataWork.WhereFields(x => x.password, qr.s_password);

                dataWork.WhereLang(false); //使用語系條件
                #endregion

                #region 設定排序
                if (qr.sidx == null)
                    dataWork.OrderByFields(x => x.id, OrderByType.DESC); //預設排序
                else
                    dataWork.OrderByFields(x => x.id, OrderByType.ASC);
                #endregion

                #region 輸出物件陣列
                r.SearchData = dataWork.DataByAdapter<m_Member>();
                r.Result = true;
                return r;
                #endregion
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System; //系統失敗
                r.Message = PackErrMessage(ex); //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        public RunEnd CheckMember_ValidCode(String validcode, int accountId)
        {
            #region 變數宣告
            RunEnd r = new RunEnd();
            #endregion
            try
            {
                TablePack<Member> dataWork = new TablePack<Member>(Connection) { LoginUserID = this.logPlamInfo.UserId, LoginUnitID = this.logPlamInfo.UnitId };
                dataWork.SelectFields(x => new { x.id, x.state });
                dataWork.TopLimit = 1;
                dataWork.WhereFields(x => x.valid_code, validcode);
                var d = dataWork.DataByAdapter<m_Member>();

                if (d.Count() == 1)
                {
                    if (d.FirstOrDefault().state == CodeSheet.MemberState.New.Code)
                    {
                        dataWork.EditFirstRow();
                        dataWork.SetDataRowValue(x => x.state, CodeSheet.MemberState.EmailPass.Code);
                        //dataWork.UpdateFieldsInfo(UpdateFieldsInfoType.Update);
                        dataWork.UpdateDataAdapter();
                        r.Result = true;
                    }
                    else
                    {
                        throw new LogicRoll("Err_MemberValidState");
                    }
                }
                else
                {
                    throw new LogicRoll("Err_MembernNoValidCode");
                }
                r.Result = true;
                return r;
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System; //系統失敗
                r.Message = PackErrMessage(ex); //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        public override RunOneDataEnd<m_Member> GetDataMaster(int id, int accountId)
        {
            #region 變數宣告
            RunOneDataEnd<m_Member> r = new RunOneDataEnd<m_Member>();

            #endregion
            try
            {
                #region Main working
                TablePack<Member> dataWork = new TablePack<Member>(Connection) { LoginUserID = this.logPlamInfo.UserId, LoginUnitID = this.logPlamInfo.UnitId };
                dataWork.TableModule.KeyFieldModules[dataWork.TableModule.id.N].V = id; //設定KeyValue
                m_Member md = dataWork.GetDataByKey<m_Member>(); //取得Key該筆資料

                if (md == null) //如無資料
                    throw new LogicRoll("Log_Err_MustHaveData"); //此區一定有資料傳出，如無資料應檢查前端id值是否有誤

                r.SearchData = md;
                r.Result = true;
                dataWork.Dispose(); //釋放資料
                return r;
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System; //系統失敗
                r.Message = PackErrMessage(ex); //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        public override RunOneDataEnd<m_Member> GetDataMaster(int[] id, int accountId)
        {
            throw new NotImplementedException();
        }
        public RunOneDataEnd<m_Member> LoginMember(String email, String password)
        {
            #region 變數宣告
            RunOneDataEnd<m_Member> r = new RunOneDataEnd<m_Member>();
            #endregion

            try
            {
                if (email == null) { email = ""; }
                if (password == null) { password = ""; }

                var r1 = SearchMaster(new q_Member() { s_email = email, s_password = password }, 0);

                if (r1.Result)
                {
                    if (r1.SearchData.Count() == 1)
                    {
                        r.SearchData = GetDataMaster(r1.SearchData.FirstOrDefault().id, 0).SearchData;
                        r.Result = true;
                    }
                    else
                    {
                        throw new LogicRoll("Err_LoginUnCorrect");
                    }
                }
                else
                {
                    throw new LogicRoll(r1.Message);
                }

                return r;
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System; //系統失敗
                r.Message = PackErrMessage(ex); //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }

        }
        public RunUpdateEnd ResetPassword(int id, int accountId)
        {
            #region Variable declare area
            RunUpdateEnd r = new RunUpdateEnd();
            #endregion
            try
            {
                #region Main Working
                Connection.BeginTransaction();
                TablePack<Member> dataWork = new TablePack<Member>(Connection) { LoginUserID = this.logPlamInfo.UserId, LoginUnitID = this.logPlamInfo.UnitId };

                dataWork.TableModule.KeyFieldModules[dataWork.TableModule.id.N].V = id; //取得ID欄位的值
                m_Member md_Origin = dataWork.GetDataByKey<m_Member>(); //取得Key值的Data

                if (md_Origin == null) //如有資料
                    throw new LogicRoll("Log_Err_MustHaveData"); //此區一定有資料傳出，如無資料應檢查前端id值是否有誤

                dataWork.EditFirstRow(); //編輯第一筆資料，正常只會有一筆資料。
                #region 指派值

                String NewPassword = (new Random()).Next(1000, 9999).ToString();
                dataWork.SetDataRowValue(x => x.password, NewPassword);
                dataWork.UpdateFieldsInfo(UpdateFieldsInfoType.Update); //指定進行更新時 需同時更新系統欄位 _修改人員，_修改日期
                #endregion
                md_Origin = null;
                dataWork.UpdateDataAdapter(); //進行變更至Database Server

                Connection.EndCommit();

                r.Rows = dataWork.AffetCount; //取得影響筆數
                r.Result = true;
                dataWork.Dispose(); //釋放資料
                return r;
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System; //系統失敗
                r.Message = PackErrMessage(ex); //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
    }
    #endregion
    #region News
    public class q_News : QueryBase
    {
        public String s_title { set; get; }
        public Boolean? s_is_open { set; get; }
        public Int32? s_news_category_id { set; get; }

    }
    public class m_News : ModuleBase
    {
        public Int32 id { get; set; }
        public String title { get; set; }
        public DateTime set_date { get; set; }
        public Int32 news_category_id { get; set; }
        public String category_name { get; set; }
        public Boolean is_open { get; set; }
        public String context { get; set; }
    }
    public class a_News : LogicBase<m_News, q_News, News>
    {
        public override RunInsertEnd InsertMaster(m_News md, int accountId)
        {
            #region Variable declare area
            RunInsertEnd r = new RunInsertEnd(); //宣告回傳物件
            #endregion
            try
            {
                #region Main working
                Connection.BeginTransaction(); //開始交易鎖定
                TablePack<News> dataWork = new TablePack<News>(Connection) { LoginUserID = this.logPlamInfo.UserId, LoginUnitID = this.logPlamInfo.UnitId };

                dataWork.NewRow(); //開始新橧作業 產生新的一行
                #region 指派值

                dataWork.SetDataRowValue(x => x.id, md.id);
                dataWork.SetDataRowValue(x => x.title, md.title);
                dataWork.SetDataRowValue(x => x.set_date, md.set_date);
                dataWork.SetDataRowValue(x => x.news_category_id, 0);
                dataWork.SetDataRowValue(x => x.is_open, md.is_open);
                dataWork.SetDataRowValue(x => x.context, md.context);
                dataWork.SetDataRowValue(x => x._隱藏, false);

                dataWork.UpdateFieldsInfo(UpdateFieldsInfoType.Insert); //進行更新時 需同時更新系統欄位 _新增人員，_新增日期
                dataWork.UpdateFieldsInfo(UpdateFieldsInfoType.Lang); //語系欄位設定
                //進行更新時 需同時更新系統欄位 _InsertUserID，_InsertDateTime
                #endregion
                dataWork.AddRow(); //加載至DataTable
                dataWork.UpdateDataAdapter(); //更新 DataBase Server

                Connection.EndCommit(); //交易確認

                r.Rows = dataWork.AffetCount; //取得影響筆數
                r.InsertId = dataWork.InsertAutoFieldsID; //取得新增後自動新增欄位的值
                r.Result = true; //回傳本次執行結果為成功
                dataWork.Dispose(); //釋放資料

                return r;
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System; //系統失敗
                r.Message = PackErrMessage(ex); //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        public override RunUpdateEnd UpdateMaster(m_News md, int accountId)
        {
            #region Variable declare area
            RunUpdateEnd r = new RunUpdateEnd();
            #endregion
            try
            {
                #region Main Working
                Connection.BeginTransaction();
                TablePack<News> dataWork = new TablePack<News>(Connection) { LoginUserID = this.logPlamInfo.UserId, LoginUnitID = this.logPlamInfo.UnitId };

                dataWork.TableModule.KeyFieldModules[dataWork.TableModule.id.N].V = md.id; //取得ID欄位的值
                m_News md_Origin = dataWork.GetDataByKey<m_News>(); //取得Key值的Data

                if (md_Origin == null) //如有資料
                    throw new LogicRoll("Log_Err_MustHaveData"); //此區一定有資料傳出，如無資料應檢查前端id值是否有誤

                dataWork.EditFirstRow(); //編輯第一筆資料，正常只會有一筆資料。
                #region 指派值

                dataWork.SetDataRowValue(x => x.id, md.id);
                dataWork.SetDataRowValue(x => x.title, md.title);
                dataWork.SetDataRowValue(x => x.set_date, md.set_date);
                dataWork.SetDataRowValue(x => x.news_category_id, 0);
                dataWork.SetDataRowValue(x => x.is_open, md.is_open);
                dataWork.SetDataRowValue(x => x.context, md.context);


                dataWork.UpdateFieldsInfo(UpdateFieldsInfoType.Update); //指定進行更新時 需同時更新系統欄位 _修改人員，_修改日期
                #endregion
                md_Origin = null;
                dataWork.UpdateDataAdapter(); //進行變更至Database Server

                Connection.EndCommit();

                r.Rows = dataWork.AffetCount; //取得影響筆數
                r.Result = true;
                dataWork.Dispose(); //釋放資料
                return r;
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System; //系統失敗
                r.Message = PackErrMessage(ex); //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        public override RunDeleteEnd DeleteMaster(Int32[] ids, int accountId)
        {
            //此功能主要搭配Grid介面刪除功能製作
            #region Variable declare area
            RunDeleteEnd r = new RunDeleteEnd(); //宣告刪除Result回物件
            #endregion
            try
            {
                #region Main working
                Connection.BeginTransaction();
                //1、要刪除的資料先選出來
                TablePack<News> dataWork = new TablePack<News>(Connection) { LoginUserID = this.logPlamInfo.UserId, LoginUnitID = this.logPlamInfo.UnitId }; //宣告泛型物件並連接Connection
                dataWork.SelectFields(x => x.id); //只Select 主Key欄位
                dataWork.WhereFields(x => x.id, ids); //代入陣列Id值

                m_News[] md_Origin = dataWork.DataByAdapter<m_News>(); //取得Key值的Data

                //2、進行全部刪除
                dataWork.DeleteAll(); //先刪除DataTable
                dataWork.UpdateDataAdapter(); //在更新至DataBase Server
                Connection.EndCommit();
                r.Result = true;
                dataWork.Dispose(); //釋放資料
                md_Origin = null;
                return r;
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System; //系統失敗
                r.Message = PackErrMessage(ex); //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        public override RunQueryPackage<m_News> SearchMaster(q_News qr, int accountId)
        {
            #region 變數宣告
            RunQueryPackage<m_News> r = new RunQueryPackage<m_News>();
            #endregion
            try
            {
                #region Select Data 區段 By 條件
                #region 設定輸出至Grid欄位
                Table2Join<News, News_Category> dataWork = new Table2Join<News, News_Category>(Connection);
                dataWork.SelectFields((x, y) => new { news_id = x.id, x.title, x.set_date, y.category_name, x.is_open });
                dataWork.JoinField(x => x.news_category_id, y => y.news_category_id, JoinType.Inner);

                dataWork.TopLimit = qr.MaxRecord;

                #endregion

                #region 設定Where條件
                if (qr.s_title != null)
                    dataWork.WhereFields((x, y) => x.title, qr.s_title, WhereCompareType.Like);

                if (qr.s_is_open != null)
                    dataWork.WhereFields((x, y) => x.is_open, qr.s_is_open);

                if (qr.s_news_category_id != null)
                    dataWork.WhereFields((x, y) => x.news_category_id, qr.s_news_category_id);

                dataWork.WhereLang();
                #endregion

                #region 設定排序
                if (qr.sidx == null)
                {
                    dataWork.OrderByFields((x, y) => x.set_date, OrderByType.DESC);
                }
                else
                {
                    dataWork.OrderByFields((x, y) => x.set_date, OrderByType.DESC);
                }
                #endregion

                #region 輸出物件陣列
                r.SearchData = dataWork.DataByAdapter<m_News>();
                r.Result = true;
                return r;
                #endregion
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System; //系統失敗
                r.Message = PackErrMessage(ex); //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        public override RunOneDataEnd<m_News> GetDataMaster(int id, int accountId)
        {
            #region 變數宣告
            RunOneDataEnd<m_News> r = new RunOneDataEnd<m_News>();

            #endregion
            try
            {
                #region Main working
                TablePack<News> dataWork = new TablePack<News>(Connection) { LoginUserID = this.logPlamInfo.UserId, LoginUnitID = this.logPlamInfo.UnitId };
                dataWork.TableModule.KeyFieldModules[dataWork.TableModule.id.N].V = id; //設定KeyValue
                m_News md = dataWork.GetDataByKey<m_News>(); //取得Key該筆資料

                if (md == null) //如無資料
                    throw new LogicRoll("Log_Err_MustHaveData"); //此區一定有資料傳出，如無資料應檢查前端id值是否有誤

                r.SearchData = md;
                r.Result = true;
                dataWork.Dispose(); //釋放資料
                return r;
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System; //系統失敗
                r.Message = PackErrMessage(ex); //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        public override RunOneDataEnd<m_News> GetDataMaster(int[] id, int accountId)
        {
            throw new NotImplementedException();
        }
    }
    #endregion
    #region News_Category
    public class q_News_Category : QueryBase
    {
    }
    public class m_News_Category : ModuleBase
    {
        public Int32 id { get; set; }
        public String category_name { get; set; }
        public Boolean is_open { get; set; }
        public Int32 sort { get; set; }
    }
    public class a_News_Category : LogicBase<m_News_Category, q_News_Category, News_Category>
    {

        public override RunInsertEnd InsertMaster(m_News_Category md, int accountId)
        {
            #region Variable declare area
            RunInsertEnd r = new RunInsertEnd(); //宣告回傳物件
            #endregion
            try
            {
                #region Main working
                Connection.BeginTransaction(); //開始交易鎖定
                TablePack<News_Category> dataWork = new TablePack<News_Category>(Connection) { LoginUserID = this.logPlamInfo.UserId, LoginUnitID = this.logPlamInfo.UnitId };

                dataWork.NewRow(); //開始新橧作業 產生新的一行
                #region 指派值

                dataWork.SetDataRowValue(x => x.news_category_id, md.id);
                dataWork.SetDataRowValue(x => x.category_name, md.category_name);
                dataWork.SetDataRowValue(x => x.is_open, md.is_open);
                dataWork.SetDataRowValue(x => x.sort, md.sort);

                dataWork.UpdateFieldsInfo(UpdateFieldsInfoType.Insert); //進行更新時 需同時更新系統欄位 _新增人員，_新增日期
                dataWork.UpdateFieldsInfo(UpdateFieldsInfoType.Lang); //語系欄位設定
                //進行更新時 需同時更新系統欄位 _InsertUserID，_InsertDateTime
                #endregion
                dataWork.AddRow(); //加載至DataTable
                dataWork.UpdateDataAdapter(); //更新 DataBase Server

                Connection.EndCommit(); //交易確認

                r.Rows = dataWork.AffetCount; //取得影響筆數
                r.InsertId = dataWork.InsertAutoFieldsID; //取得新增後自動新增欄位的值
                r.Result = true; //回傳本次執行結果為成功
                dataWork.Dispose(); //釋放資料

                return r;
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System; //系統失敗
                r.Message = PackErrMessage(ex); //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        public override RunUpdateEnd UpdateMaster(m_News_Category md, int accountId)
        {
            #region Variable declare area
            RunUpdateEnd r = new RunUpdateEnd();
            #endregion
            try
            {
                #region Main Working
                Connection.BeginTransaction();
                TablePack<News_Category> dataWork = new TablePack<News_Category>(Connection) { LoginUserID = this.logPlamInfo.UserId, LoginUnitID = this.logPlamInfo.UnitId };

                dataWork.TableModule.KeyFieldModules[dataWork.TableModule.news_category_id.N].V = md.id; //取得ID欄位的值
                m_News_Category md_Origin = dataWork.GetDataByKey<m_News_Category>(); //取得Key值的Data

                if (md_Origin == null) //如有資料
                    throw new LogicRoll("Log_Err_MustHaveData"); //此區一定有資料傳出，如無資料應檢查前端id值是否有誤

                dataWork.EditFirstRow(); //編輯第一筆資料，正常只會有一筆資料。
                #region 指派值

                dataWork.SetDataRowValue(x => x.news_category_id, md.id);
                dataWork.SetDataRowValue(x => x.category_name, md.category_name);
                dataWork.SetDataRowValue(x => x.is_open, md.is_open);
                dataWork.SetDataRowValue(x => x.sort, md.sort);
                dataWork.UpdateFieldsInfo(UpdateFieldsInfoType.Update); //指定進行更新時 需同時更新系統欄位 _修改人員，_修改日期
                #endregion
                md_Origin = null;
                dataWork.UpdateDataAdapter(); //進行變更至Database Server

                Connection.EndCommit();

                r.Rows = dataWork.AffetCount; //取得影響筆數
                r.Result = true;
                dataWork.Dispose(); //釋放資料
                return r;
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System; //系統失敗
                r.Message = PackErrMessage(ex); //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        public override RunDeleteEnd DeleteMaster(Int32[] ids, int accountId)
        {
            //此功能主要搭配Grid介面刪除功能製作
            #region Variable declare area
            RunDeleteEnd r = new RunDeleteEnd(); //宣告刪除Result回物件
            #endregion
            try
            {
                #region Main working
                Connection.BeginTransaction();
                //1、要刪除的資料先選出來
                TablePack<News_Category> dataWork = new TablePack<News_Category>(Connection) { LoginUserID = this.logPlamInfo.UserId, LoginUnitID = this.logPlamInfo.UnitId }; //宣告泛型物件並連接Connection
                dataWork.SelectFields(x => x.news_category_id); //只Select 主Key欄位
                dataWork.WhereFields(x => x.news_category_id, ids); //代入陣列Id值

                m_News_Category[] md_Origin = dataWork.DataByAdapter<m_News_Category>(); //取得Key值的Data

                //2、進行全部刪除
                dataWork.DeleteAll(); //先刪除DataTable
                dataWork.UpdateDataAdapter(); //在更新至DataBase Server
                Connection.EndCommit();
                r.Result = true;
                dataWork.Dispose(); //釋放資料
                md_Origin = null;
                return r;
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System; //系統失敗
                r.Message = PackErrMessage(ex); //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }

        public override RunQueryPackage<m_News_Category> SearchMaster(q_News_Category qr, int accountId)
        {
            #region 變數宣告
            RunQueryPackage<m_News_Category> r = new RunQueryPackage<m_News_Category>();
            #endregion
            try
            {
                #region Select Data 區段 By 條件
                #region 設定輸出至Grid欄位
                TablePack<News_Category> dataWork = new TablePack<News_Category>(Connection) { LoginUserID = this.logPlamInfo.UserId, LoginUnitID = this.logPlamInfo.UnitId };
                dataWork.SelectFields(x => new { id = x.news_category_id, name = x.category_name, x.is_open, x.sort });

                if (qr.MaxRecord > 0) dataWork.TopLimit = qr.MaxRecord;

                #endregion

                #region 設定Where條件
                //                if (qr.s_title != null)
                //                    dataWork.WhereFields(x => x.Title, qr.s_title, WhereCompareType.Like);

                //dataWork.WhereLang(); //使用語系條件
                #endregion

                #region 設定排序
                if (qr.sidx == null)
                    dataWork.OrderByFields(x => x.sort, OrderByType.DESC); //預設排序
                else
                    dataWork.OrderByFields(x => x.news_category_id);
                #endregion

                #region 輸出物件陣列
                r.SearchData = dataWork.DataByAdapter<m_News_Category>();
                r.Result = true;
                return r;
                #endregion
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System; //系統失敗
                r.Message = PackErrMessage(ex); //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }

        public override RunOneDataEnd<m_News_Category> GetDataMaster(int id, int accountId)
        {
            #region 變數宣告
            RunOneDataEnd<m_News_Category> r = new RunOneDataEnd<m_News_Category>();

            #endregion
            try
            {
                #region Main working
                TablePack<News_Category> dataWork = new TablePack<News_Category>(Connection) { LoginUserID = this.logPlamInfo.UserId, LoginUnitID = this.logPlamInfo.UnitId };
                dataWork.TableModule.KeyFieldModules[dataWork.TableModule.news_category_id.N].V = id; //設定KeyValue
                m_News_Category md = dataWork.GetDataByKey<m_News_Category>(); //取得Key該筆資料

                if (md == null) //如無資料
                    throw new LogicRoll("Log_Err_MustHaveData"); //此區一定有資料傳出，如無資料應檢查前端id值是否有誤

                r.SearchData = md;
                r.Result = true;
                dataWork.Dispose(); //釋放資料
                return r;
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System; //系統失敗
                r.Message = PackErrMessage(ex); //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        public override RunOneDataEnd<m_News_Category> GetDataMaster(int[] id, int accountId)
        {
            throw new NotImplementedException();
        }
    }
    #endregion
    #region Page_Context
    public class q_Page_Context : QueryBase
    {
        public String s_title { set; get; }
    }
    public class m_Page_Context : ModuleBase
    {
        public Int32 id { get; set; }
        public String page_name { get; set; }
        public Boolean is_open { get; set; }
        public Int32 sort { get; set; }
        public String page_html { get; set; }
    }
    public class a_Page_Context : LogicBase<m_Page_Context, q_Page_Context, Page_Context>
    {
        public override RunInsertEnd InsertMaster(m_Page_Context md, int accountId)
        {
            #region Variable declare area
            RunInsertEnd r = new RunInsertEnd(); //宣告回傳物件
            #endregion
            try
            {
                #region Main working
                Connection.BeginTransaction(); //開始交易鎖定
                TablePack<Page_Context> dataWork = new TablePack<Page_Context>(Connection) { LoginUserID = this.logPlamInfo.UserId, LoginUnitID = this.logPlamInfo.UnitId };

                dataWork.NewRow(); //開始新橧作業 產生新的一行
                #region 指派值

                dataWork.SetDataRowValue(x => x.id, md.id);
                dataWork.SetDataRowValue(x => x.page_name, md.page_name);
                dataWork.SetDataRowValue(x => x.is_open, md.is_open);
                dataWork.SetDataRowValue(x => x.sort, md.sort);
                dataWork.SetDataRowValue(x => x.page_html, md.page_html);


                dataWork.UpdateFieldsInfo(UpdateFieldsInfoType.Insert); //進行更新時 需同時更新系統欄位 _新增人員，_新增日期
                dataWork.UpdateFieldsInfo(UpdateFieldsInfoType.Lang); //語系欄位設定
                //進行更新時 需同時更新系統欄位 _InsertUserID，_InsertDateTime
                #endregion
                dataWork.AddRow(); //加載至DataTable
                dataWork.UpdateDataAdapter(); //更新 DataBase Server

                Connection.EndCommit(); //交易確認

                r.Rows = dataWork.AffetCount; //取得影響筆數
                r.InsertId = dataWork.InsertAutoFieldsID; //取得新增後自動新增欄位的值
                r.Result = true; //回傳本次執行結果為成功
                dataWork.Dispose(); //釋放資料

                return r;
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System; //系統失敗
                r.Message = PackErrMessage(ex); //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        public override RunUpdateEnd UpdateMaster(m_Page_Context md, int accountId)
        {
            #region Variable declare area
            RunUpdateEnd r = new RunUpdateEnd();
            #endregion
            try
            {
                #region Main Working
                Connection.BeginTransaction();
                TablePack<Page_Context> dataWork = new TablePack<Page_Context>(Connection) { LoginUserID = this.logPlamInfo.UserId, LoginUnitID = this.logPlamInfo.UnitId };

                dataWork.TableModule.KeyFieldModules[dataWork.TableModule.id.N].V = md.id; //取得ID欄位的值
                m_Page_Context md_Origin = dataWork.GetDataByKey<m_Page_Context>(); //取得Key值的Data

                if (md_Origin == null) //如有資料
                    throw new LogicRoll("Log_Err_MustHaveData"); //此區一定有資料傳出，如無資料應檢查前端id值是否有誤

                dataWork.EditFirstRow(); //編輯第一筆資料，正常只會有一筆資料。
                #region 指派值

                dataWork.SetDataRowValue(x => x.page_name, md.page_name);
                dataWork.SetDataRowValue(x => x.is_open, md.is_open);
                //dataWork.SetDataRowValue(x => x.sort, md.sort);
                dataWork.SetDataRowValue(x => x.page_html, md.page_html);


                dataWork.UpdateFieldsInfo(UpdateFieldsInfoType.Update); //指定進行更新時 需同時更新系統欄位 _修改人員，_修改日期
                #endregion
                md_Origin = null;
                dataWork.UpdateDataAdapter(); //進行變更至Database Server

                Connection.EndCommit();

                r.Rows = dataWork.AffetCount; //取得影響筆數
                r.Result = true;
                dataWork.Dispose(); //釋放資料
                return r;
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System; //系統失敗
                r.Message = PackErrMessage(ex); //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        public override RunDeleteEnd DeleteMaster(Int32[] ids, int accountId)
        {
            throw new NotImplementedException();
        }
        public override RunQueryPackage<m_Page_Context> SearchMaster(q_Page_Context qr, int accountId)
        {
            #region 變數宣告
            RunQueryPackage<m_Page_Context> r = new RunQueryPackage<m_Page_Context>();
            #endregion
            try
            {
                #region Select Data 區段 By 條件
                #region 設定輸出至Grid欄位
                TablePack<Page_Context> dataWork = new TablePack<Page_Context>(Connection) { LoginUserID = this.logPlamInfo.UserId, LoginUnitID = this.logPlamInfo.UnitId };
                dataWork.SelectFields(x => new { x.id, x.page_name, x.is_open, x.sort });

                if (qr.MaxRecord > 0) dataWork.TopLimit = qr.MaxRecord;

                #endregion

                #region 設定Where條件
                if (qr.s_title != null)
                    dataWork.WhereFields(x => x.page_name, qr.s_title, WhereCompareType.Like);

                //dataWork.WhereLang(); //使用語系條件
                #endregion

                #region 設定排序
                if (qr.sidx == null)
                    dataWork.OrderByFields(x => x.id, OrderByType.DESC); //預設排序
                else
                    dataWork.OrderByFields(x => x.id, OrderByType.ASC);
                #endregion

                #region 輸出物件陣列
                r.SearchData = dataWork.DataByAdapter<m_Page_Context>();
                r.Result = true;
                return r;
                #endregion
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System; //系統失敗
                r.Message = PackErrMessage(ex); //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        public override RunOneDataEnd<m_Page_Context> GetDataMaster(int id, int accountId)
        {
            #region 變數宣告
            RunOneDataEnd<m_Page_Context> r = new RunOneDataEnd<m_Page_Context>();

            #endregion
            try
            {
                #region Main working
                TablePack<Page_Context> dataWork = new TablePack<Page_Context>(Connection) { LoginUserID = this.logPlamInfo.UserId, LoginUnitID = this.logPlamInfo.UnitId };
                dataWork.TableModule.KeyFieldModules[dataWork.TableModule.id.N].V = id; //設定KeyValue
                m_Page_Context md = dataWork.GetDataByKey<m_Page_Context>(); //取得Key該筆資料

                if (md == null) //如無資料
                    throw new LogicRoll("Log_Err_MustHaveData"); //此區一定有資料傳出，如無資料應檢查前端id值是否有誤

                r.SearchData = md;
                r.Result = true;
                dataWork.Dispose(); //釋放資料
                return r;
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System; //系統失敗
                r.Message = PackErrMessage(ex); //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        public override RunOneDataEnd<m_Page_Context> GetDataMaster(int[] id, int accountId)
        {
            throw new NotImplementedException();
        }
    }
    #endregion
    #region faq
    public class q_faq : QueryBase
    {
        public String s_title { set; get; }
        public Boolean? s_is_open { set; get; }
        public Int32? s_faq_category_id { set; get; }
    }
    public class m_faq : ModuleBase
    {
        public Int32 id { get; set; }
        public String title { get; set; }
        public DateTime set_date { get; set; }
        public String context { get; set; }
        public Boolean is_open { get; set; }
        public Int32 faq_category_id { get; set; }
        public String category_name { get; set; }
        public Int32 sort { get; set; }
    }
    public class a_faq : LogicBase<m_faq, q_faq, FAQ>
    {
        public override RunInsertEnd InsertMaster(m_faq md, int accountId)
        {
            #region Variable declare area
            RunInsertEnd r = new RunInsertEnd(); //宣告回傳物件
            #endregion
            try
            {
                #region Main working
                Connection.BeginTransaction(); //開始交易鎖定
                TablePack<FAQ> dataWork = new TablePack<FAQ>(Connection) { LoginUserID = this.logPlamInfo.UserId, LoginUnitID = this.logPlamInfo.UnitId };

                dataWork.NewRow(); //開始新橧作業 產生新的一行
                #region 指派值

                dataWork.SetDataRowValue(x => x.id, md.id);
                dataWork.SetDataRowValue(x => x.title, md.title);
                dataWork.SetDataRowValue(x => x.set_date, DateTime.Now);
                dataWork.SetDataRowValue(x => x.context, md.context);
                dataWork.SetDataRowValue(x => x.is_open, md.is_open);
                dataWork.SetDataRowValue(x => x.faq_category_id, 0);
                dataWork.SetDataRowValue(x => x.sort, md.sort);
                dataWork.SetDataRowValue(x => x._隱藏, false);
                dataWork.UpdateFieldsInfo(UpdateFieldsInfoType.Insert); //進行更新時 需同時更新系統欄位 _新增人員，_新增日期
                dataWork.UpdateFieldsInfo(UpdateFieldsInfoType.Lang); //語系欄位設定
                //進行更新時 需同時更新系統欄位 _InsertUserID，_InsertDateTime
                #endregion
                dataWork.AddRow(); //加載至DataTable
                dataWork.UpdateDataAdapter(); //更新 DataBase Server

                Connection.EndCommit(); //交易確認

                r.Rows = dataWork.AffetCount; //取得影響筆數
                r.InsertId = dataWork.InsertAutoFieldsID; //取得新增後自動新增欄位的值
                r.Result = true; //回傳本次執行結果為成功
                dataWork.Dispose(); //釋放資料

                return r;
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System; //系統失敗
                r.Message = PackErrMessage(ex); //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        public override RunUpdateEnd UpdateMaster(m_faq md, int accountId)
        {
            #region Variable declare area
            RunUpdateEnd r = new RunUpdateEnd();
            #endregion
            try
            {
                #region Main Working
                Connection.BeginTransaction();
                TablePack<FAQ> dataWork = new TablePack<FAQ>(Connection) { LoginUserID = this.logPlamInfo.UserId, LoginUnitID = this.logPlamInfo.UnitId };

                dataWork.TableModule.KeyFieldModules[dataWork.TableModule.id.N].V = md.id; //取得ID欄位的值
                m_faq md_Origin = dataWork.GetDataByKey<m_faq>(); //取得Key值的Data

                if (md_Origin == null) //如有資料
                    throw new LogicRoll("Log_Err_MustHaveData"); //此區一定有資料傳出，如無資料應檢查前端id值是否有誤

                dataWork.EditFirstRow(); //編輯第一筆資料，正常只會有一筆資料。
                #region 指派值

                dataWork.SetDataRowValue(x => x.id, md.id);
                dataWork.SetDataRowValue(x => x.title, md.title);
                //dataWork.SetDataRowValue(x => x.set_date, DateTime.Now);
                dataWork.SetDataRowValue(x => x.context, md.context);
                dataWork.SetDataRowValue(x => x.is_open, md.is_open);
                //dataWork.SetDataRowValue(x => x.faq_category_id, md.faq_category_id);
                dataWork.SetDataRowValue(x => x.sort, md.sort);

                dataWork.UpdateFieldsInfo(UpdateFieldsInfoType.Update); //指定進行更新時 需同時更新系統欄位 _修改人員，_修改日期
                #endregion
                md_Origin = null;
                dataWork.UpdateDataAdapter(); //進行變更至Database Server

                Connection.EndCommit();

                r.Rows = dataWork.AffetCount; //取得影響筆數
                r.Result = true;
                dataWork.Dispose(); //釋放資料
                return r;
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System; //系統失敗
                r.Message = PackErrMessage(ex); //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        public override RunDeleteEnd DeleteMaster(Int32[] ids, int accountId)
        {
            //此功能主要搭配Grid介面刪除功能製作
            #region Variable declare area
            RunDeleteEnd r = new RunDeleteEnd(); //宣告刪除Result回物件
            #endregion
            try
            {
                #region Main working
                Connection.BeginTransaction();
                //1、要刪除的資料先選出來
                TablePack<FAQ> dataWork = new TablePack<FAQ>(Connection) { LoginUserID = this.logPlamInfo.UserId, LoginUnitID = this.logPlamInfo.UnitId }; //宣告泛型物件並連接Connection
                dataWork.SelectFields(x => x.id); //只Select 主Key欄位
                dataWork.WhereFields(x => x.id, ids); //代入陣列Id值

                m_faq[] md_Origin = dataWork.DataByAdapter<m_faq>(); //取得Key值的Data

                //2、進行全部刪除
                dataWork.DeleteAll(); //先刪除DataTable
                dataWork.UpdateDataAdapter(); //在更新至DataBase Server
                Connection.EndCommit();
                r.Result = true;
                dataWork.Dispose(); //釋放資料
                md_Origin = null;
                return r;
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System; //系統失敗
                r.Message = PackErrMessage(ex); //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        public override RunQueryPackage<m_faq> SearchMaster(q_faq qr, int accountId)
        {
            #region 變數宣告
            RunQueryPackage<m_faq> r = new RunQueryPackage<m_faq>();
            #endregion
            try
            {
                #region Select Data 區段 By 條件
                #region 設定輸出至Grid欄位
                TablePack<FAQ> dataWork = new TablePack<FAQ>(Connection) { LoginUserID = this.logPlamInfo.UserId, LoginUnitID = this.logPlamInfo.UnitId };
                dataWork.SelectFields(x => new { x.id, x.title, x.set_date, isopen = x.is_open });
                #endregion

                #region 設定Where條件
                if (qr.s_title != null)
                    dataWork.WhereFields(x => x.title, qr.s_title, WhereCompareType.Like);

                if (qr.s_is_open != null)
                    dataWork.WhereFields(x => x.is_open, qr.s_is_open);

                if (qr.s_faq_category_id != null)
                    dataWork.WhereFields(x => x.faq_category_id, qr.s_faq_category_id);

                dataWork.WhereLang(); //使用語系條件
                #endregion

                #region 設定排序
                if (qr.sidx == null)
                {
                    dataWork.OrderByFields(x => x.set_date, OrderByType.DESC); //預設排序
                    dataWork.OrderByFields(x => x.id, OrderByType.DESC); //預設排序
                }
                else
                    dataWork.OrderByFields(x => x.id, OrderByType.ASC);
                #endregion

                #region 輸出物件陣列
                r.SearchData = dataWork.DataByAdapter<m_faq>();
                r.Result = true;
                return r;
                #endregion
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System; //系統失敗
                r.Message = PackErrMessage(ex); //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        public RunQueryPackage<m_faq> SearchMaster2(q_faq qr, int accountId)
        {
            #region 變數宣告
            RunQueryPackage<m_faq> r = new RunQueryPackage<m_faq>();
            #endregion
            try
            {
                #region Select Data 區段 By 條件
                #region 設定輸出至Grid欄位
                Table2Join<FAQ, FAQ_Category> dataWork = new Table2Join<FAQ, FAQ_Category>(Connection);
                dataWork.SelectFields((x, y) => new { faq_id = x.id, x.title, x.sort, y.category_name, isopen = x.is_open });
                dataWork.JoinField(x => x.faq_category_id, y => y.faq_category_id, JoinType.Inner);
                #endregion

                #region 設定Where條件
                if (qr.s_title != null)
                    dataWork.WhereFields((x, y) => x.is_open, qr.s_title, WhereCompareType.Like);

                if (qr.s_is_open != null)
                    dataWork.WhereFields((x, y) => x.is_open, qr.s_is_open);

                if (qr.s_faq_category_id != null)
                    dataWork.WhereFields((x, y) => x.faq_category_id, qr.s_is_open);

                dataWork.WhereLang();
                #endregion

                #region 設定排序
                if (qr.sidx == "sort")
                {
                    dataWork.OrderByFields((x, y) => x.sort, OrderByType.DESC);
                }
                else
                {
                    dataWork.OrderByFields((x, y) => x.id, OrderByType.DESC);
                }
                #endregion

                #region 輸出物件陣列
                r.SearchData = dataWork.DataByAdapter<m_faq>();
                r.Result = true;
                return r;
                #endregion
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System; //系統失敗
                r.Message = PackErrMessage(ex); //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        public RunQueryPackage<m_faq> SearchMaster3(q_faq qr, int accountId)
        {
            #region 變數宣告
            RunQueryPackage<m_faq> r = new RunQueryPackage<m_faq>();
            #endregion
            try
            {
                #region Select Data 區段 By 條件
                #region 設定輸出至Grid欄位
                Table2Join<FAQ, FAQ_Category> dataWork = new Table2Join<FAQ, FAQ_Category>(Connection);
                dataWork.SelectFields((x, y) => new { faq_id = x.id, x.title, x.context });
                dataWork.JoinField(x => x.faq_category_id, y => y.faq_category_id, JoinType.Inner);
                #endregion

                #region 設定Where條件
                dataWork.WhereFields((x, y) => x.is_open, qr.s_is_open);
                dataWork.WhereLang();
                #endregion

                #region 設定排序

                dataWork.OrderByFields((x, y) => x.sort, OrderByType.DESC);

                #endregion

                #region 輸出物件陣列
                r.SearchData = dataWork.DataByAdapter<m_faq>();
                r.Result = true;
                return r;
                #endregion
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System; //系統失敗
                r.Message = PackErrMessage(ex); //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        public override RunOneDataEnd<m_faq> GetDataMaster(int id, int accountId)
        {
            #region 變數宣告
            RunOneDataEnd<m_faq> r = new RunOneDataEnd<m_faq>();
            #endregion
            try
            {
                #region Main working
                TablePack<FAQ> dataWork = new TablePack<FAQ>(Connection) { LoginUserID = this.logPlamInfo.UserId, LoginUnitID = this.logPlamInfo.UnitId };
                dataWork.TableModule.KeyFieldModules[dataWork.TableModule.id.N].V = id; //設定KeyValue
                m_faq md = dataWork.GetDataByKey<m_faq>(); //取得Key該筆資料

                if (md == null) //如無資料
                    throw new LogicRoll("Log_Err_MustHaveData"); //此區一定有資料傳出，如無資料應檢查前端id值是否有誤

                r.SearchData = md;
                r.Result = true;
                dataWork.Dispose(); //釋放資料
                return r;
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System; //系統失敗
                r.Message = PackErrMessage(ex); //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        public override RunOneDataEnd<m_faq> GetDataMaster(int[] id, int accountId)
        {
            throw new NotImplementedException();
        }

    }
    #endregion
    #region faq_Category
    public class q_faq_Category : QueryBase
    {
    }
    public class m_faq_Category : ModuleBase
    {
        public Int32 faq_category_id { get; set; }
        public String category_name { get; set; }
        public Boolean is_open { get; set; }
        public Int32 sort { get; set; }
    }
    public class a_faq_Category : LogicBase<m_faq_Category, q_faq_Category, FAQ_Category>
    {

        public override RunInsertEnd InsertMaster(m_faq_Category md, int accountId)
        {
            #region Variable declare area
            RunInsertEnd r = new RunInsertEnd(); //宣告回傳物件
            #endregion
            try
            {
                #region Main working
                Connection.BeginTransaction(); //開始交易鎖定
                TablePack<FAQ_Category> dataWork = new TablePack<FAQ_Category>(Connection) { LoginUserID = this.logPlamInfo.UserId, LoginUnitID = this.logPlamInfo.UnitId };

                dataWork.NewRow(); //開始新橧作業 產生新的一行
                #region 指派值

                dataWork.SetDataRowValue(x => x.faq_category_id, md.faq_category_id);
                dataWork.SetDataRowValue(x => x.category_name, md.category_name);
                dataWork.SetDataRowValue(x => x.is_open, md.is_open);
                dataWork.SetDataRowValue(x => x.sort, md.sort);

                dataWork.UpdateFieldsInfo(UpdateFieldsInfoType.Insert); //進行更新時 需同時更新系統欄位 _新增人員，_新增日期
                dataWork.UpdateFieldsInfo(UpdateFieldsInfoType.Lang); //語系欄位設定
                //進行更新時 需同時更新系統欄位 _InsertUserID，_InsertDateTime
                #endregion
                dataWork.AddRow(); //加載至DataTable
                dataWork.UpdateDataAdapter(); //更新 DataBase Server

                Connection.EndCommit(); //交易確認

                r.Rows = dataWork.AffetCount; //取得影響筆數
                r.InsertId = dataWork.InsertAutoFieldsID; //取得新增後自動新增欄位的值
                r.Result = true; //回傳本次執行結果為成功
                dataWork.Dispose(); //釋放資料

                return r;
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System; //系統失敗
                r.Message = PackErrMessage(ex); //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        public override RunUpdateEnd UpdateMaster(m_faq_Category md, int accountId)
        {
            #region Variable declare area
            RunUpdateEnd r = new RunUpdateEnd();
            #endregion
            try
            {
                #region Main Working
                Connection.BeginTransaction();
                TablePack<FAQ_Category> dataWork = new TablePack<FAQ_Category>(Connection) { LoginUserID = this.logPlamInfo.UserId, LoginUnitID = this.logPlamInfo.UnitId };

                dataWork.TableModule.KeyFieldModules[dataWork.TableModule.faq_category_id.N].V = md.faq_category_id; //取得ID欄位的值
                m_faq_Category md_Origin = dataWork.GetDataByKey<m_faq_Category>(); //取得Key值的Data

                if (md_Origin == null) //如有資料
                    throw new LogicRoll("Log_Err_MustHaveData"); //此區一定有資料傳出，如無資料應檢查前端id值是否有誤

                dataWork.EditFirstRow(); //編輯第一筆資料，正常只會有一筆資料。
                #region 指派值

                dataWork.SetDataRowValue(x => x.faq_category_id, md.faq_category_id);
                dataWork.SetDataRowValue(x => x.category_name, md.category_name);
                dataWork.SetDataRowValue(x => x.is_open, md.is_open);
                dataWork.SetDataRowValue(x => x.sort, md.sort);
                dataWork.UpdateFieldsInfo(UpdateFieldsInfoType.Update); //指定進行更新時 需同時更新系統欄位 _修改人員，_修改日期
                #endregion
                md_Origin = null;
                dataWork.UpdateDataAdapter(); //進行變更至Database Server

                Connection.EndCommit();

                r.Rows = dataWork.AffetCount; //取得影響筆數
                r.Result = true;
                dataWork.Dispose(); //釋放資料
                return r;
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System; //系統失敗
                r.Message = PackErrMessage(ex); //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        public override RunDeleteEnd DeleteMaster(Int32[] ids, int accountId)
        {
            //此功能主要搭配Grid介面刪除功能製作
            #region Variable declare area
            RunDeleteEnd r = new RunDeleteEnd(); //宣告刪除Result回物件
            #endregion
            try
            {
                #region Main working
                Connection.BeginTransaction();
                //1、要刪除的資料先選出來
                TablePack<FAQ_Category> dataWork = new TablePack<FAQ_Category>(Connection) { LoginUserID = this.logPlamInfo.UserId, LoginUnitID = this.logPlamInfo.UnitId }; //宣告泛型物件並連接Connection
                dataWork.SelectFields(x => x.faq_category_id); //只Select 主Key欄位
                dataWork.WhereFields(x => x.faq_category_id, ids); //代入陣列Id值

                m_faq_Category[] md_Origin = dataWork.DataByAdapter<m_faq_Category>(); //取得Key值的Data

                //2、進行全部刪除
                dataWork.DeleteAll(); //先刪除DataTable
                dataWork.UpdateDataAdapter(); //在更新至DataBase Server
                Connection.EndCommit();
                r.Result = true;
                dataWork.Dispose(); //釋放資料
                md_Origin = null;
                return r;
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System; //系統失敗
                r.Message = PackErrMessage(ex); //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }

        public override RunQueryPackage<m_faq_Category> SearchMaster(q_faq_Category qr, int accountId)
        {
            #region 變數宣告
            RunQueryPackage<m_faq_Category> r = new RunQueryPackage<m_faq_Category>();
            #endregion
            try
            {
                #region Select Data 區段 By 條件
                #region 設定輸出至Grid欄位
                TablePack<FAQ_Category> dataWork = new TablePack<FAQ_Category>(Connection) { LoginUserID = this.logPlamInfo.UserId, LoginUnitID = this.logPlamInfo.UnitId };
                dataWork.SelectFields(x => new { x.faq_category_id, name = x.category_name, x.is_open, x.sort });

                if (qr.MaxRecord > 0) dataWork.TopLimit = qr.MaxRecord;

                #endregion

                #region 設定Where條件
                //                if (qr.s_title != null)
                //                    dataWork.WhereFields(x => x.Title, qr.s_title, WhereCompareType.Like);

                //dataWork.WhereLang(); //使用語系條件
                #endregion

                #region 設定排序
                if (qr.sidx == null)
                    dataWork.OrderByFields(x => x.sort, OrderByType.DESC); //預設排序
                else
                    dataWork.OrderByFields(x => x.faq_category_id);
                #endregion

                #region 輸出物件陣列
                r.SearchData = dataWork.DataByAdapter<m_faq_Category>();
                r.Result = true;
                return r;
                #endregion
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System; //系統失敗
                r.Message = PackErrMessage(ex); //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }

        public override RunOneDataEnd<m_faq_Category> GetDataMaster(int id, int accountId)
        {
            #region 變數宣告
            RunOneDataEnd<m_faq_Category> r = new RunOneDataEnd<m_faq_Category>();

            #endregion
            try
            {
                #region Main working
                TablePack<FAQ_Category> dataWork = new TablePack<FAQ_Category>(Connection) { LoginUserID = this.logPlamInfo.UserId, LoginUnitID = this.logPlamInfo.UnitId };
                dataWork.TableModule.KeyFieldModules[dataWork.TableModule.faq_category_id.N].V = id; //設定KeyValue
                m_faq_Category md = dataWork.GetDataByKey<m_faq_Category>(); //取得Key該筆資料

                if (md == null) //如無資料
                    throw new LogicRoll("Log_Err_MustHaveData"); //此區一定有資料傳出，如無資料應檢查前端id值是否有誤

                r.SearchData = md;
                r.Result = true;
                dataWork.Dispose(); //釋放資料
                return r;
                #endregion
            }
            catch (LogicRoll ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.Logic; //企業羅輯失敗
                r.Message = ex.Message; //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
            catch (Exception ex)
            {
                #region Error handle
                Connection.Rollback(); //取消並回復交易
                r.Result = false; //回傳本次執行失敗
                r.ErrType = BusinessErrType.System; //系統失敗
                r.Message = PackErrMessage(ex); //回傳失敗代碼
                Log.Write(logPlamInfo, this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return r;
                #endregion
            }
        }
        public override RunOneDataEnd<m_faq_Category> GetDataMaster(int[] id, int accountId)
        {
            throw new NotImplementedException();
        }
    }
    #endregion
    #endregion
    public class ItemsManage : LogicBase
    {
        public Dictionary<String, String> i_CurrencyData(int accountId)
        {
            #region Main working
            Product TObj = new Product();// 取得Table物
            TablePack<_Currency> dataWork = new TablePack<_Currency>(Connection) { LoginUserID = accountId };
            dataWork.SelectFields(x => new { x.code, x.name_currency });
            dataWork.WhereFields(x => x.is_use, true);
            dataWork.OrderByFields(x => x.code);
            return dataWork.DataByAdapter().dicMakeKeyValue(0, 1);
            #endregion
        }
        public Dictionary<String, String> i_News_Category(int accountId)
        {
            #region Main working
            News_Category TObj = new News_Category();// 取得Table物
            TablePack<News_Category> dataWork = new TablePack<News_Category>(Connection) { LoginUserID = accountId };
            dataWork.SelectFields(x => new { x.news_category_id, name = x.category_name });
            dataWork.WhereFields(x => x.is_open, true);
            dataWork.OrderByFields(x => x.sort);
            return dataWork.DataByAdapter().dicMakeKeyValue(0, 1);
            #endregion
        }
        public Dictionary<String, String> i_FAQ_Category(int accountId)
        {
            #region Main working
            FAQ_Category TObj = new FAQ_Category();// 取得Table物
            TablePack<FAQ_Category> dataWork = new TablePack<FAQ_Category>(Connection) { LoginUserID = accountId };
            dataWork.SelectFields(x => new { x.faq_category_id, name = x.category_name });
            dataWork.WhereFields(x => x.is_open, true);
            dataWork.WhereFields(x => x.faq_category_id, 0, WhereCompareType.UnEquel);
            dataWork.OrderByFields(x => x.sort);
            return dataWork.DataByAdapter().dicMakeKeyValue(0, 1);
            #endregion
        }

    }
    [Serializable]
    public class Shop_Master
    {
        public String name { get; set; }
        public String tel { get; set; }
        public String email { get; set; }
        public String zip { get; set; }
        public String address { get; set; }
        public Boolean gender { get; set; }
        public Decimal total { get; set; }
        public String currency { get; set; }
        public String currency_name { get; set; }
        public List<Shop_Detail> Items { get; set; }
    }
    [Serializable]
    public class Shop_Detail
    {
        public String guid { get; set; }
        public int product_id { get; set; }
        public String product_serial { get; set; }
        public String product_name { get; set; }
        public Int32 amt { get; set; }
        public decimal unit_price { get; set; }
        public String unit_name { get; set; }
        public decimal sub_count { get; set; }
        public String currency { get; set; }
        public String currency_name { get; set; }
        public int maxamt { get; set; }

        public String imgsrc { get; set; }
    }
    #region Data Handle Extension
    public static class BusinessLoginExtension
    {
        public static String BooleanValue(this Boolean s, BooleanSheetBase b)
        {
            if (s) { return b.TrueValue; } else { return b.FalseValue; }
        }
        public static String CodeValue(this String s, List<_Code> b)
        {
            var result = b.Where(x => x.Code == s);
            if (result.Count() > 0)
            {
                return result.FirstOrDefault().Value;
            }
            else
            {
                return "";
            }
        }
    }
    #endregion

    public class changePassword
    {
        public Int32 id { get; set; }
        public String o { get; set; }
        public String n { get; set; }
        public String s { get; set; }
    }
}
