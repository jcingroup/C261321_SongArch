using System;
using System.Collections.Generic;
using System.Reflection;
using System.Data;
using System.Linq;

using ProcCore.DatabaseCore;
using ProcCore.DatabaseCore.SQLContextHelp;
using ProcCore.DatabaseCore.TableFieldModule;

namespace ProcCore.Business.Logic.TablesDescription
{
    #region DataBase Module

    #region Base Module Description
    public class _AddressCity : TableMap<_AddressCity>
    {
        public _AddressCity()
        {
            N = "_AddressCity"; GetTabObj = this;
            this.city = new FieldModule() { M = "city", N = "city", T = SQLValueType.String, B = this.N };
            this.sort = new FieldModule() { M = "sort", N = "sort", T = SQLValueType.Int, B = this.N };

            KeyFieldModules = new Dictionary<String, FieldModule>() { { this.city.N, this.city } };
        }
        public FieldModule city { get; set; }
        public FieldModule sort { get; set; }
    }
    public class _AddressCounty : TableMap<_AddressCounty>
    {
        public _AddressCounty()
        {
            N = "_AddressCounty"; GetTabObj = this;
            this.city = new FieldModule() { M = "city", N = "city", T = SQLValueType.String, B = this.N };
            this.county = new FieldModule() { M = "county", N = "county", T = SQLValueType.String, B = this.N };
            this.zip = new FieldModule() { M = "zip", N = "zip", T = SQLValueType.String, B = this.N };
            this.sort = new FieldModule() { M = "sort", N = "sort", T = SQLValueType.Int, B = this.N };
            this.code = new FieldModule() { M = "code", N = "code", T = SQLValueType.String, B = this.N };

            KeyFieldModules = new Dictionary<String, FieldModule>() { { this.city.N, this.city }, { this.county.N, this.county } };
        }
        public FieldModule city { get; set; }
        public FieldModule county { get; set; }
        public FieldModule zip { get; set; }
        public FieldModule sort { get; set; }
        public FieldModule code { get; set; }
    }
    public class _Adr_zh_TW : TableMap<_Adr_zh_TW>
    {
        public _Adr_zh_TW()
        {
            N = "_Adr_zh_TW"; GetTabObj = this;
            this.data = new FieldModule() { M = "data", N = "data", T = SQLValueType.String, B = this.N };
            this.zip = new FieldModule() { M = "zip", N = "zip", T = SQLValueType.String, B = this.N };

            KeyFieldModules = new Dictionary<String, FieldModule>() { { this.data.N, this.data } };
        }
        public FieldModule data { get; set; }
        public FieldModule zip { get; set; }
    }
    public class _BooleanSheet : TableMap<_BooleanSheet>
    {
        public _BooleanSheet()
        {
            N = "_BooleanSheet"; GetTabObj = this;
            this.Boolean = new FieldModule() { M = "Boolean", N = "Boolean", T = SQLValueType.Boolean, B = this.N };
            this.sex = new FieldModule() { M = "sex", N = "sex", T = SQLValueType.String, B = this.N };
            this.yn = new FieldModule() { M = "yn", N = "yn", T = SQLValueType.String, B = this.N };
            this.ynv = new FieldModule() { M = "ynv", N = "ynv", T = SQLValueType.String, B = this.N };
            this.ynvx = new FieldModule() { M = "ynvx", N = "ynvx", T = SQLValueType.String, B = this.N };

            KeyFieldModules = new Dictionary<String, FieldModule>() { { this.Boolean.N, this.Boolean } };
        }
        public FieldModule Boolean { get; set; }
        public FieldModule sex { get; set; }
        public FieldModule yn { get; set; }
        public FieldModule ynv { get; set; }
        public FieldModule ynvx { get; set; }
    }
    public class _CodeHead : TableMap<_CodeHead>
    {
        public _CodeHead()
        {
            N = "_CodeHead"; GetTabObj = this;
            this.id = new FieldModule() { M = "id", N = "id", T = SQLValueType.Int, B = this.N };
            this.name = new FieldModule() { M = "name", N = "name", T = SQLValueType.String, B = this.N };
            this.IsEdit = new FieldModule() { M = "IsEdit", N = "IsEdit", T = SQLValueType.Boolean, B = this.N };
            this.Memo = new FieldModule() { M = "Memo", N = "Memo", T = SQLValueType.String, B = this.N };
            this._語系 = new FieldModule() { M = "_語系", N = "_語系", T = SQLValueType.String, B = this.N };

            KeyFieldModules = new Dictionary<String, FieldModule>() { { this.id.N, this.id } };
        }
        public FieldModule id { get; set; }
        public FieldModule name { get; set; }
        public FieldModule IsEdit { get; set; }
        public FieldModule Memo { get; set; }
        public FieldModule _語系 { get; set; }
    }
    public class _CodeSheet : TableMap<_CodeSheet>
    {
        public _CodeSheet()
        {
            N = "_CodeSheet"; GetTabObj = this;
            this.id = new FieldModule() { M = "id", N = "id", T = SQLValueType.Int, B = this.N };
            this.CodeHeadId = new FieldModule() { M = "CodeHeadId", N = "CodeHeadId", T = SQLValueType.Int, B = this.N };
            this.Code = new FieldModule() { M = "Code", N = "Code", T = SQLValueType.String, B = this.N };
            this.Value = new FieldModule() { M = "Value", N = "Value", T = SQLValueType.String, B = this.N };
            this.Sort = new FieldModule() { M = "Sort", N = "Sort", T = SQLValueType.Int, B = this.N };
            this.IsUse = new FieldModule() { M = "IsUse", N = "IsUse", T = SQLValueType.Boolean, B = this.N };
            this.IsEdit = new FieldModule() { M = "IsEdit", N = "IsEdit", T = SQLValueType.Boolean, B = this.N };
            this.Memo = new FieldModule() { M = "Memo", N = "Memo", T = SQLValueType.String, B = this.N };
            this._語系 = new FieldModule() { M = "_語系", N = "_語系", T = SQLValueType.String, B = this.N };

            KeyFieldModules = new Dictionary<String, FieldModule>() { { this.CodeHeadId.N, this.CodeHeadId }, { this.Code.N, this.Code }, { this._語系.N, this._語系 } };
        }
        public FieldModule id { get; set; }
        public FieldModule CodeHeadId { get; set; }
        public FieldModule Code { get; set; }
        public FieldModule Value { get; set; }
        public FieldModule Sort { get; set; }
        public FieldModule IsUse { get; set; }
        public FieldModule IsEdit { get; set; }
        public FieldModule Memo { get; set; }
        public FieldModule _語系 { get; set; }
    }
    public class _Currency : TableMap<_Currency>
    {
        public _Currency()
        {
            N = "_Currency"; GetTabObj = this;
            this.id = new FieldModule() { M = "id", N = "id", T = SQLValueType.Int, B = this.N };
            this.name_currency = new FieldModule() { M = "name_currency", N = "name_currency", T = SQLValueType.String, B = this.N };
            this.english_currency = new FieldModule() { M = "english_currency", N = "english_currency", T = SQLValueType.String, B = this.N };
            this.sign = new FieldModule() { M = "sign", N = "sign", T = SQLValueType.String, B = this.N };
            this.code = new FieldModule() { M = "code", N = "code", T = SQLValueType.String, B = this.N };
            this.is_use = new FieldModule() { M = "is_use", N = "is_use", T = SQLValueType.Boolean, B = this.N };
            KeyFieldModules = new Dictionary<String, FieldModule>() { { this.id.N, this.id } };
        }
        public FieldModule id { get; set; }
        public FieldModule name_currency { get; set; }
        public FieldModule english_currency { get; set; }
        public FieldModule sign { get; set; }
        public FieldModule code { get; set; }
        public FieldModule is_use { get; set; }
    }
    public class _IDX : TableMap<_IDX>
    {
        public _IDX()
        {
            N = "_IDX"; GetTabObj = this;
            this.IDX = new FieldModule() { M = "IDX", N = "IDX", T = SQLValueType.Int, B = this.N };

            KeyFieldModules = new Dictionary<String, FieldModule>() { { this.IDX.N, this.IDX } };
        }
        public FieldModule IDX { get; set; }
    }
    public class _Lang : TableMap<_Lang>
    {
        public _Lang()
        {
            N = "_Lang"; GetTabObj = this;
            this.lang = new FieldModule() { M = "lang", N = "lang", T = SQLValueType.String, B = this.N };
            this.area = new FieldModule() { M = "area", N = "area", T = SQLValueType.String, B = this.N };
            this.memo = new FieldModule() { M = "memo", N = "memo", T = SQLValueType.String, B = this.N };
            this.isuse = new FieldModule() { M = "isuse", N = "isuse", T = SQLValueType.Boolean, B = this.N };
            this.sort = new FieldModule() { M = "sort", N = "sort", T = SQLValueType.Int, B = this.N };

            KeyFieldModules = new Dictionary<String, FieldModule>() { { this.lang.N, this.lang } };
        }
        public FieldModule lang { get; set; }
        public FieldModule area { get; set; }
        public FieldModule memo { get; set; }
        public FieldModule isuse { get; set; }
        public FieldModule sort { get; set; }
    }
    public class _Parm : TableMap<_Parm>
    {
        public _Parm()
        {
            N = "_Parm"; GetTabObj = this;
            this.ParmName = new FieldModule() { M = "ParmName", N = "ParmName", T = SQLValueType.String, B = this.N };
            this.ParmType = new FieldModule() { M = "ParmType", N = "ParmType", T = SQLValueType.String, B = this.N };
            this.S = new FieldModule() { M = "S", N = "S", T = SQLValueType.String, B = this.N };
            this.I = new FieldModule() { M = "I", N = "I", T = SQLValueType.Int, B = this.N };
            this.F = new FieldModule() { M = "F", N = "F", T = SQLValueType.Int, B = this.N };
            this.D = new FieldModule() { M = "D", N = "D", T = SQLValueType.DateTime, B = this.N };
            this.B = new FieldModule() { M = "B", N = "B", T = SQLValueType.Boolean, B = this.N };

            KeyFieldModules = new Dictionary<String, FieldModule>() { { this.ParmName.N, this.ParmName } };
        }
        public FieldModule ParmName { get; set; }
        public FieldModule ParmType { get; set; }
        public FieldModule S { get; set; }
        public FieldModule I { get; set; }
        public FieldModule F { get; set; }
        public FieldModule D { get; set; }
        public FieldModule B { get; set; }
    }
    public class _PowerName : TableMap<_PowerName>
    {
        public _PowerName()
        {
            N = "_PowerName"; GetTabObj = this;
            this.id = new FieldModule() { M = "id", N = "id", T = SQLValueType.Int, B = this.N };
            this.name = new FieldModule() { M = "name", N = "name", T = SQLValueType.String, B = this.N };
            this.memo = new FieldModule() { M = "memo", N = "memo", T = SQLValueType.String, B = this.N };

            KeyFieldModules = new Dictionary<String, FieldModule>() { { this.id.N, this.id } };
        }
        public FieldModule id { get; set; }
        public FieldModule name { get; set; }
        public FieldModule memo { get; set; }
    }
    public class _PowerUnit : TableMap<_PowerUnit>
    {
        public _PowerUnit()
        {
            N = "_PowerUnit"; GetTabObj = this;
            this.ProgID = new FieldModule() { M = "ProgID", N = "ProgID", T = SQLValueType.Int, B = this.N };
            this.UnitID = new FieldModule() { M = "UnitID", N = "UnitID", T = SQLValueType.Int, B = this.N };
            this.PowerID = new FieldModule() { M = "PowerID", N = "PowerID", T = SQLValueType.Int, B = this.N };
            this.AccessUnit = new FieldModule() { M = "AccessUnit", N = "AccessUnit", T = SQLValueType.Int, B = this.N };

            KeyFieldModules = new Dictionary<String, FieldModule>() { { this.ProgID.N, this.ProgID }, { this.UnitID.N, this.UnitID }, { this.PowerID.N, this.PowerID } };
        }
        public FieldModule ProgID { get; set; }
        public FieldModule UnitID { get; set; }
        public FieldModule PowerID { get; set; }
        public FieldModule AccessUnit { get; set; }
    }
    public class _PowerUsers : TableMap<_PowerUsers>
    {
        public _PowerUsers()
        {
            N = "_PowerUsers"; GetTabObj = this;
            this.ProgID = new FieldModule() { M = "ProgID", N = "ProgID", T = SQLValueType.Int, B = this.N };
            this.UserID = new FieldModule() { M = "UserID", N = "UserID", T = SQLValueType.Int, B = this.N };
            this.PowerID = new FieldModule() { M = "PowerID", N = "PowerID", T = SQLValueType.Int, B = this.N };
            this.UnitID = new FieldModule() { M = "UnitID", N = "UnitID", T = SQLValueType.Int, B = this.N };

            KeyFieldModules = new Dictionary<String, FieldModule>() { { this.ProgID.N, this.ProgID }, { this.UserID.N, this.UserID }, { this.PowerID.N, this.PowerID } };
        }
        public FieldModule ProgID { get; set; }
        public FieldModule UserID { get; set; }
        public FieldModule PowerID { get; set; }
        public FieldModule UnitID { get; set; }
    }
    public class _UserLoginLog : TableMap<_UserLoginLog>
    {
        public _UserLoginLog()
        {
            N = "_UserLoginLog"; GetTabObj = this;
            this.id = new FieldModule() { M = "id", N = "id", T = SQLValueType.Int, B = this.N };
            this.ip = new FieldModule() { M = "ip", N = "ip", T = SQLValueType.String, B = this.N };
            this.account = new FieldModule() { M = "account", N = "account", T = SQLValueType.String, B = this.N };
            this.logintime = new FieldModule() { M = "logintime", N = "logintime", T = SQLValueType.DateTime, B = this.N };
            this.browers = new FieldModule() { M = "browers", N = "browers", T = SQLValueType.String, B = this.N };

            KeyFieldModules = new Dictionary<String, FieldModule>() { { this.id.N, this.id } };
        }
        public FieldModule id { get; set; }
        public FieldModule ip { get; set; }
        public FieldModule account { get; set; }
        public FieldModule logintime { get; set; }
        public FieldModule browers { get; set; }
    }
    public class _WebCount : TableMap<_WebCount>
    {
        public _WebCount()
        {
            N = "_WebCount"; GetTabObj = this;
            this.Cnt = new FieldModule() { M = "Cnt", N = "Cnt", T = SQLValueType.Int, B = this.N };

            KeyFieldModules = new Dictionary<String, FieldModule>() { { this.Cnt.N, this.Cnt } };
        }
        public FieldModule Cnt { get; set; }
    }
    public class _WebVisitData : TableMap<_WebVisitData>
    {
        public _WebVisitData()
        {
            N = "_WebVisitData"; GetTabObj = this;
            this.id = new FieldModule() { M = "id", N = "id", T = SQLValueType.Int, B = this.N };
            this.ip = new FieldModule() { M = "ip", N = "ip", T = SQLValueType.String, B = this.N };
            this.setdate = new FieldModule() { M = "setdate", N = "setdate", T = SQLValueType.DateTime, B = this.N };
            this.browser = new FieldModule() { M = "browser", N = "browser", T = SQLValueType.String, B = this.N };
            this.source = new FieldModule() { M = "source", N = "source", T = SQLValueType.String, B = this.N };
            this.page = new FieldModule() { M = "page", N = "page", T = SQLValueType.String, B = this.N };

            KeyFieldModules = new Dictionary<String, FieldModule>() { { this.id.N, this.id } };
        }
        public FieldModule id { get; set; }
        public FieldModule ip { get; set; }
        public FieldModule setdate { get; set; }
        public FieldModule browser { get; set; }
        public FieldModule source { get; set; }
        public FieldModule page { get; set; }
    }
    public class ProgData : TableMap<ProgData>
    {
        public ProgData()
        {
            N = "ProgData"; GetTabObj = this;
            this.id = new FieldModule() { M = "id", N = "id", T = SQLValueType.Int, B = this.N };
            this.area = new FieldModule() { M = "area", N = "area", T = SQLValueType.String, B = this.N };
            this.controller = new FieldModule() { M = "controller", N = "controller", T = SQLValueType.String, B = this.N };
            this.action = new FieldModule() { M = "action", N = "action", T = SQLValueType.String, B = this.N };
            this.path = new FieldModule() { M = "path", N = "path", T = SQLValueType.String, B = this.N };
            this.page = new FieldModule() { M = "page", N = "page", T = SQLValueType.String, B = this.N };
            this.prog_name = new FieldModule() { M = "prog_name", N = "prog_name", T = SQLValueType.String, B = this.N };
            this.sort = new FieldModule() { M = "sort", N = "sort", T = SQLValueType.String, B = this.N };
            this.isfolder = new FieldModule() { M = "isfolder", N = "isfolder", T = SQLValueType.Boolean, B = this.N };
            this.ishidden = new FieldModule() { M = "ishidden", N = "ishidden", T = SQLValueType.Boolean, B = this.N };
            this.isRoute = new FieldModule() { M = "isRoute", N = "isRoute", T = SQLValueType.Boolean, B = this.N };
            this.ismb = new FieldModule() { M = "ismb", N = "ismb", T = SQLValueType.Boolean, B = this.N };
            this.power_serial = new FieldModule() { M = "power_serial", N = "power_serial", T = SQLValueType.Int, B = this.N };
            this._隱藏 = new FieldModule() { M = "_隱藏", N = "_隱藏", T = SQLValueType.Boolean, B = this.N };
            this._新增人員 = new FieldModule() { M = "_新增人員", N = "_新增人員", T = SQLValueType.Int, B = this.N };
            this._新增單位 = new FieldModule() { M = "_新增單位", N = "_新增單位", T = SQLValueType.Int, B = this.N };
            this._新增日期 = new FieldModule() { M = "_新增日期", N = "_新增日期", T = SQLValueType.DateTime, B = this.N };
            this._修改人員 = new FieldModule() { M = "_修改人員", N = "_修改人員", T = SQLValueType.Int, B = this.N };
            this._修改單位 = new FieldModule() { M = "_修改單位", N = "_修改單位", T = SQLValueType.Int, B = this.N };
            this._修改日期 = new FieldModule() { M = "_修改日期", N = "_修改日期", T = SQLValueType.DateTime, B = this.N };
            this._語系 = new FieldModule() { M = "_語系", N = "_語系", T = SQLValueType.String, B = this.N };

            KeyFieldModules = new Dictionary<String, FieldModule>() { { this.id.N, this.id } };
        }
        public FieldModule id { get; set; }
        public FieldModule area { get; set; }
        public FieldModule controller { get; set; }
        public FieldModule action { get; set; }
        public FieldModule path { get; set; }
        public FieldModule page { get; set; }
        public FieldModule prog_name { get; set; }
        public FieldModule sort { get; set; }
        public FieldModule isfolder { get; set; }
        public FieldModule ishidden { get; set; }
        public FieldModule isRoute { get; set; }
        public FieldModule ismb { get; set; }
        public FieldModule power_serial { get; set; }
        public FieldModule _隱藏 { get; set; }
        public FieldModule _新增人員 { get; set; }
        public FieldModule _新增單位 { get; set; }
        public FieldModule _新增日期 { get; set; }
        public FieldModule _修改人員 { get; set; }
        public FieldModule _修改單位 { get; set; }
        public FieldModule _修改日期 { get; set; }
        public FieldModule _語系 { get; set; }
    }
    public class UnitData : TableMap<UnitData>
    {
        public UnitData()
        {
            N = "UnitData"; GetTabObj = this;
            this.id = new FieldModule() { M = "id", N = "unit_id", T = SQLValueType.Int, B = this.N };
            this.unit_name = new FieldModule() { M = "unit_name", N = "unit_name", T = SQLValueType.String, B = this.N };
            this.sort = new FieldModule() { M = "sort", N = "sort", T = SQLValueType.Int, B = this.N };
            this._隱藏 = new FieldModule() { M = "_隱藏", N = "_隱藏", T = SQLValueType.Boolean, B = this.N };
            this._新增人員 = new FieldModule() { M = "_新增人員", N = "_新增人員", T = SQLValueType.Int, B = this.N };
            this._新增單位 = new FieldModule() { M = "_新增單位", N = "_新增單位", T = SQLValueType.Int, B = this.N };
            this._新增日期 = new FieldModule() { M = "_新增日期", N = "_新增日期", T = SQLValueType.DateTime, B = this.N };
            this._修改人員 = new FieldModule() { M = "_修改人員", N = "_修改人員", T = SQLValueType.Int, B = this.N };
            this._修改單位 = new FieldModule() { M = "_修改單位", N = "_修改單位", T = SQLValueType.Int, B = this.N };
            this._修改日期 = new FieldModule() { M = "_修改日期", N = "_修改日期", T = SQLValueType.DateTime, B = this.N };

            KeyFieldModules = new Dictionary<String, FieldModule>() { { this.id.N, this.id } };
        }
        public FieldModule id { get; set; }
        public FieldModule unit_name { get; set; }
        public FieldModule sort { get; set; }
        public FieldModule _隱藏 { get; set; }
        public FieldModule _新增人員 { get; set; }
        public FieldModule _新增單位 { get; set; }
        public FieldModule _新增日期 { get; set; }
        public FieldModule _修改人員 { get; set; }
        public FieldModule _修改單位 { get; set; }
        public FieldModule _修改日期 { get; set; }
    }
    public class UserData : TableMap<UserData>
    {
        public UserData()
        {
            N = "UserData"; GetTabObj = this;
            this.id = new FieldModule() { M = "id", N = "user_id", T = SQLValueType.Int, B = this.N };
            this.account = new FieldModule() { M = "account", N = "account", T = SQLValueType.String, B = this.N };
            this.password = new FieldModule() { M = "password", N = "password", T = SQLValueType.String, B = this.N };
            this.user_name = new FieldModule() { M = "user_name", N = "user_name", T = SQLValueType.String, B = this.N };
            this.unit_id = new FieldModule() { M = "unit_id", N = "unit_id", T = SQLValueType.Int, B = this.N };
            this.state = new FieldModule() { M = "state", N = "state", T = SQLValueType.String, B = this.N };
            this.isadmin = new FieldModule() { M = "isadmin", N = "isadmin", T = SQLValueType.Boolean, B = this.N };
            this.type = new FieldModule() { M = "type", N = "type", T = SQLValueType.String, B = this.N };
            this.email = new FieldModule() { M = "email", N = "email", T = SQLValueType.String, B = this.N };
            this.zip = new FieldModule() { M = "zip", N = "zip", T = SQLValueType.String, B = this.N };
            this.city = new FieldModule() { M = "city", N = "city", T = SQLValueType.String, B = this.N };
            this.country = new FieldModule() { M = "country", N = "country", T = SQLValueType.String, B = this.N };
            this.address = new FieldModule() { M = "address", N = "address", T = SQLValueType.String, B = this.N };
            this._隱藏 = new FieldModule() { M = "_隱藏", N = "_隱藏", T = SQLValueType.Boolean, B = this.N };
            this._新增人員 = new FieldModule() { M = "_新增人員", N = "_新增人員", T = SQLValueType.Int, B = this.N };
            this._新增單位 = new FieldModule() { M = "_新增單位", N = "_新增單位", T = SQLValueType.Int, B = this.N };
            this._新增日期 = new FieldModule() { M = "_新增日期", N = "_新增日期", T = SQLValueType.DateTime, B = this.N };
            this._修改人員 = new FieldModule() { M = "_修改人員", N = "_修改人員", T = SQLValueType.Int, B = this.N };
            this._修改單位 = new FieldModule() { M = "_修改單位", N = "_修改單位", T = SQLValueType.Int, B = this.N };
            this._修改日期 = new FieldModule() { M = "_修改日期", N = "_修改日期", T = SQLValueType.DateTime, B = this.N };

            KeyFieldModules = new Dictionary<String, FieldModule>() { { this.id.N, this.id } };
        }
        public FieldModule id { get; set; }
        public FieldModule account { get; set; }
        public FieldModule password { get; set; }
        public FieldModule user_name { get; set; }
        public FieldModule unit_id { get; set; }
        public FieldModule state { get; set; }
        public FieldModule isadmin { get; set; }
        public FieldModule type { get; set; }
        public FieldModule email { get; set; }
        public FieldModule zip { get; set; }
        public FieldModule city { get; set; }
        public FieldModule country { get; set; }
        public FieldModule address { get; set; }
        public FieldModule _隱藏 { get; set; }
        public FieldModule _新增人員 { get; set; }
        public FieldModule _新增單位 { get; set; }
        public FieldModule _新增日期 { get; set; }
        public FieldModule _修改人員 { get; set; }
        public FieldModule _修改單位 { get; set; }
        public FieldModule _修改日期 { get; set; }
    }
    #endregion

    #region Case Module Description
    ///<summary>
    ///會員
    ///</summary>
    public class Member : TableMap<Member>
    {
        public Member()
        {
            N = "Member"; GetTabObj = this;
            this.id = new FieldModule() { M = "id", N = "member_id", T = SQLValueType.Int, B = this.N };
            this.member_name = new FieldModule() { M = "member_name", N = "member_name", T = SQLValueType.String, B = this.N };
            this.gender = new FieldModule() { M = "gender", N = "gender", T = SQLValueType.Boolean, B = this.N };
            this.email = new FieldModule() { M = "email", N = "email", T = SQLValueType.String, B = this.N };
            this.password = new FieldModule() { M = "password", N = "password", T = SQLValueType.String, B = this.N };
            this.tel = new FieldModule() { M = "tel", N = "tel", T = SQLValueType.String, B = this.N };
            this.mobile = new FieldModule() { M = "mobile", N = "mobile", T = SQLValueType.String, B = this.N };
            this.zip = new FieldModule() { M = "zip", N = "zip", T = SQLValueType.String, B = this.N };
            this.address = new FieldModule() { M = "address", N = "address", T = SQLValueType.String, B = this.N };
            this.birthday = new FieldModule() { M = "birthday", N = "birthday", T = SQLValueType.DateTime, B = this.N };
            this.state = new FieldModule() { M = "state", N = "state", T = SQLValueType.String, B = this.N };
            this.valid_code = new FieldModule() { M = "valid_code", N = "valid_code", T = SQLValueType.String, B = this.N };
            this._隱藏 = new FieldModule() { M = "_隱藏", N = "_隱藏", T = SQLValueType.Boolean, B = this.N };
            this._新增人員 = new FieldModule() { M = "_新增人員", N = "_新增人員", T = SQLValueType.Int, B = this.N };
            this._新增單位 = new FieldModule() { M = "_新增單位", N = "_新增單位", T = SQLValueType.Int, B = this.N };
            this._新增日期 = new FieldModule() { M = "_新增日期", N = "_新增日期", T = SQLValueType.DateTime, B = this.N };
            this._修改人員 = new FieldModule() { M = "_修改人員", N = "_修改人員", T = SQLValueType.Int, B = this.N };
            this._修改單位 = new FieldModule() { M = "_修改單位", N = "_修改單位", T = SQLValueType.Int, B = this.N };
            this._修改日期 = new FieldModule() { M = "_修改日期", N = "_修改日期", T = SQLValueType.DateTime, B = this.N };
            this._語系 = new FieldModule() { M = "_語系", N = "_語系", T = SQLValueType.String, B = this.N };

            KeyFieldModules = new Dictionary<String, FieldModule>() { { this.id.N, this.id } };
        }
        public FieldModule id { get; set; }
        public FieldModule member_name { get; set; }
        public FieldModule gender { get; set; }
        ///<summary>
        ///會員電子郵件
        ///</summary>
        public FieldModule email { get; set; }
        ///<summary>
        ///密碼
        ///</summary>
        public FieldModule password { get; set; }
        public FieldModule tel { get; set; }
        public FieldModule mobile { get; set; }
        public FieldModule zip { get; set; }
        public FieldModule address { get; set; }
        public FieldModule birthday { get; set; }
        public FieldModule state { get; set; }
        ///<summary>
        ///會員加入驗證 寄發Eamil驗證使用，為MD5格式。
        ///</summary>
        public FieldModule valid_code { get; set; }
        public FieldModule _隱藏 { get; set; }
        public FieldModule _新增人員 { get; set; }
        public FieldModule _新增單位 { get; set; }
        public FieldModule _新增日期 { get; set; }
        public FieldModule _修改人員 { get; set; }
        public FieldModule _修改單位 { get; set; }
        public FieldModule _修改日期 { get; set; }
        public FieldModule _語系 { get; set; }
    }
    ///<summary>
    ///訂單主檔
    ///</summary>
    public class Orders : TableMap<Orders>
    {
        public Orders()
        {
            N = "Orders"; GetTabObj = this;
            this.id = new FieldModule() { M = "id", N = "orders_id", T = SQLValueType.Int, B = this.N };
            this.order_serial = new FieldModule() { M = "order_serial", N = "order_serial", T = SQLValueType.String, B = this.N };
            this.order_state = new FieldModule() { M = "order_state", N = "order_state", T = SQLValueType.String, B = this.N };
            this.transation_date = new FieldModule() { M = "transation_date", N = "transation_date", T = SQLValueType.DateTime, B = this.N };
            this.shipping_fee = new FieldModule() { M = "shipping_fee", N = "shipping_fee", T = SQLValueType.Int, B = this.N };
            this.order_money = new FieldModule() { M = "order_money", N = "order_money", T = SQLValueType.Int, B = this.N };
            this.total_money = new FieldModule() { M = "total_money", N = "total_money", T = SQLValueType.Int, B = this.N };
            this.order_name = new FieldModule() { M = "order_name", N = "order_name", T = SQLValueType.String, B = this.N };
            this.order_gender = new FieldModule() { M = "order_gender", N = "order_gender", T = SQLValueType.Boolean, B = this.N };
            this.order_zip = new FieldModule() { M = "order_zip", N = "order_zip", T = SQLValueType.String, B = this.N };
            this.order_address = new FieldModule() { M = "order_address", N = "order_address", T = SQLValueType.String, B = this.N };
            this.order_email = new FieldModule() { M = "order_email", N = "order_email", T = SQLValueType.String, B = this.N };
            this.order_tel = new FieldModule() { M = "order_tel", N = "order_tel", T = SQLValueType.String, B = this.N };
            this.order_memo = new FieldModule() { M = "order_memo", N = "order_memo", T = SQLValueType.String, B = this.N };
            this.receive_name = new FieldModule() { M = "receive_name", N = "receive_name", T = SQLValueType.String, B = this.N };
            this.receive_gender = new FieldModule() { M = "receive_gender", N = "receive_gender", T = SQLValueType.Boolean, B = this.N };
            this.receive_zip = new FieldModule() { M = "receive_zip", N = "receive_zip", T = SQLValueType.String, B = this.N };
            this.receive_address = new FieldModule() { M = "receive_address", N = "receive_address", T = SQLValueType.String, B = this.N };
            this.receive_email = new FieldModule() { M = "receive_email", N = "receive_email", T = SQLValueType.String, B = this.N };
            this.receive_tel = new FieldModule() { M = "receive_tel", N = "receive_tel", T = SQLValueType.String, B = this.N };
            this.pay_date = new FieldModule() { M = "pay_date", N = "pay_date", T = SQLValueType.DateTime, B = this.N };
            this.pay_style = new FieldModule() { M = "pay_style", N = "pay_style", T = SQLValueType.String, B = this.N };
            this.pay_money = new FieldModule() { M = "pay_money", N = "pay_money", T = SQLValueType.Int, B = this.N };
            this.pay_state = new FieldModule() { M = "pay_state", N = "pay_state", T = SQLValueType.String, B = this.N };
            this.is_reject = new FieldModule() { M = "is_reject", N = "is_reject", T = SQLValueType.Boolean, B = this.N };
            this.reject_date = new FieldModule() { M = "reject_date", N = "reject_date", T = SQLValueType.DateTime, B = this.N };
            this.reject_reason = new FieldModule() { M = "reject_reason", N = "reject_reason", T = SQLValueType.String, B = this.N };
            this.vat_number = new FieldModule() { M = "vat_number", N = "vat_number", T = SQLValueType.String, B = this.N };
            this.member_id = new FieldModule() { M = "member_id", N = "member_id", T = SQLValueType.Int, B = this.N };
            this._隱藏 = new FieldModule() { M = "_隱藏", N = "_隱藏", T = SQLValueType.Boolean, B = this.N };
            this._新增人員 = new FieldModule() { M = "_新增人員", N = "_新增人員", T = SQLValueType.Int, B = this.N };
            this._新增單位 = new FieldModule() { M = "_新增單位", N = "_新增單位", T = SQLValueType.Int, B = this.N };
            this._新增日期 = new FieldModule() { M = "_新增日期", N = "_新增日期", T = SQLValueType.DateTime, B = this.N };
            this._修改人員 = new FieldModule() { M = "_修改人員", N = "_修改人員", T = SQLValueType.Int, B = this.N };
            this._修改單位 = new FieldModule() { M = "_修改單位", N = "_修改單位", T = SQLValueType.Int, B = this.N };
            this._修改日期 = new FieldModule() { M = "_修改日期", N = "_修改日期", T = SQLValueType.DateTime, B = this.N };
            this._語系 = new FieldModule() { M = "_語系", N = "_語系", T = SQLValueType.String, B = this.N };

            KeyFieldModules = new Dictionary<String, FieldModule>() { { this.id.N, this.id } };
        }
        public FieldModule id { get; set; }
        ///<summary>
        ///訂單編號
        ///</summary>
        public FieldModule order_serial { get; set; }
        ///<summary>
        ///訂單狀態
        ///</summary>
        public FieldModule order_state { get; set; }
        ///<summary>
        ///交易日期
        ///</summary>
        public FieldModule transation_date { get; set; }
        ///<summary>
        ///運費
        ///</summary>
        public FieldModule shipping_fee { get; set; }
        ///<summary>
        ///訂單金額
        ///</summary>
        public FieldModule order_money { get; set; }
        ///<summary>
        ///總計金額
        ///</summary>
        public FieldModule total_money { get; set; }
        public FieldModule order_name { get; set; }
        public FieldModule order_gender { get; set; }
        public FieldModule order_zip { get; set; }
        public FieldModule order_address { get; set; }
        public FieldModule order_email { get; set; }
        public FieldModule order_tel { get; set; }
        ///<summary>
        ///訂單備註
        ///</summary>
        public FieldModule order_memo { get; set; }
        public FieldModule receive_name { get; set; }
        public FieldModule receive_gender { get; set; }
        public FieldModule receive_zip { get; set; }
        public FieldModule receive_address { get; set; }
        public FieldModule receive_email { get; set; }
        public FieldModule receive_tel { get; set; }
        public FieldModule pay_date { get; set; }
        ///<summary>
        ///付款方式
        ///</summary>
        public FieldModule pay_style { get; set; }
        ///<summary>
        ///付款金額
        ///</summary>
        public FieldModule pay_money { get; set; }
        ///<summary>
        ///付款狀態
        ///</summary>
        public FieldModule pay_state { get; set; }
        ///<summary>
        ///是否退貨
        ///</summary>
        public FieldModule is_reject { get; set; }
        ///<summary>
        ///退貨日期
        ///</summary>
        public FieldModule reject_date { get; set; }
        ///<summary>
        ///退貨原因
        ///</summary>
        public FieldModule reject_reason { get; set; }
        ///<summary>
        ///統一編號
        ///</summary>
        public FieldModule vat_number { get; set; }
        ///<summary>
        ///會員序號
        ///</summary>
        public FieldModule member_id { get; set; }
        public FieldModule _隱藏 { get; set; }
        public FieldModule _新增人員 { get; set; }
        public FieldModule _新增單位 { get; set; }
        public FieldModule _新增日期 { get; set; }
        public FieldModule _修改人員 { get; set; }
        public FieldModule _修改單位 { get; set; }
        public FieldModule _修改日期 { get; set; }
        public FieldModule _語系 { get; set; }
    }
    ///<summary>
    ///訂單明細資料
    ///</summary>
    public class Orders_Detail : TableMap<Orders_Detail>
    {
        public Orders_Detail()
        {
            N = "Orders_Detail"; GetTabObj = this;
            this.ids = new FieldModule() { M = "ids", N = "orders_detail_id", T = SQLValueType.Int, B = this.N };
            this.order_serial = new FieldModule() { M = "order_serial", N = "order_serial", T = SQLValueType.String, B = this.N };
            this.orders_id = new FieldModule() { M = "orders_id", N = "orders_id", T = SQLValueType.Int, B = this.N };
            this.product_id = new FieldModule() { M = "product_id", N = "product_id", T = SQLValueType.Int, B = this.N };
            this.product_name = new FieldModule() { M = "product_name", N = "product_name", T = SQLValueType.String, B = this.N };
            this.product_serial = new FieldModule() { M = "product_serial", N = "product_serial", T = SQLValueType.String, B = this.N };
            this.item_no = new FieldModule() { M = "item_no", N = "item_no", T = SQLValueType.Int, B = this.N };
            this.amt = new FieldModule() { M = "amt", N = "amt", T = SQLValueType.Int, B = this.N };
            this.unit_price = new FieldModule() { M = "unit_price", N = "unit_price", T = SQLValueType.Int, B = this.N };
            this.unit_name = new FieldModule() { M = "unit_name", N = "unit_name", T = SQLValueType.String, B = this.N };
            this.currency = new FieldModule() { M = "currency", N = "currency", T = SQLValueType.String, B = this.N };
            this.subtotal = new FieldModule() { M = "subtotal", N = "subtotal", T = SQLValueType.Int, B = this.N };
            this._隱藏 = new FieldModule() { M = "_隱藏", N = "_隱藏", T = SQLValueType.Boolean, B = this.N };
            this._新增人員 = new FieldModule() { M = "_新增人員", N = "_新增人員", T = SQLValueType.Int, B = this.N };
            this._新增單位 = new FieldModule() { M = "_新增單位", N = "_新增單位", T = SQLValueType.Int, B = this.N };
            this._新增日期 = new FieldModule() { M = "_新增日期", N = "_新增日期", T = SQLValueType.DateTime, B = this.N };
            this._修改人員 = new FieldModule() { M = "_修改人員", N = "_修改人員", T = SQLValueType.Int, B = this.N };
            this._修改單位 = new FieldModule() { M = "_修改單位", N = "_修改單位", T = SQLValueType.Int, B = this.N };
            this._修改日期 = new FieldModule() { M = "_修改日期", N = "_修改日期", T = SQLValueType.DateTime, B = this.N };
            this._語系 = new FieldModule() { M = "_語系", N = "_語系", T = SQLValueType.String, B = this.N };

            KeyFieldModules = new Dictionary<String, FieldModule>() { { this.ids.N, this.ids } };
        }
        public FieldModule ids { get; set; }
        public FieldModule order_serial { get; set; }
        public FieldModule orders_id { get; set; }
        public FieldModule product_id { get; set; }
        public FieldModule product_name { get; set; }
        public FieldModule product_serial { get; set; }
        public FieldModule item_no { get; set; }
        public FieldModule amt { get; set; }
        ///<summary>
        ///單價
        ///</summary>
        public FieldModule unit_price { get; set; }
        ///<summary>
        ///計價單位
        ///</summary>
        public FieldModule unit_name { get; set; }
        ///<summary>
        ///計價幣別
        ///</summary>
        public FieldModule currency { get; set; }
        ///<summary>
        ///小計
        ///</summary>
        public FieldModule subtotal { get; set; }
        public FieldModule _隱藏 { get; set; }
        public FieldModule _新增人員 { get; set; }
        public FieldModule _新增單位 { get; set; }
        public FieldModule _新增日期 { get; set; }
        public FieldModule _修改人員 { get; set; }
        public FieldModule _修改單位 { get; set; }
        public FieldModule _修改日期 { get; set; }
        public FieldModule _語系 { get; set; }
    }
    ///<summary>
    ///產品
    ///</summary>
    public class Product : TableMap<Product>
    {
        public Product()
        {
            N = "Product"; GetTabObj = this;
            this.id = new FieldModule() { M = "id", N = "product_id", T = SQLValueType.Int, B = this.N };
            this.product_name = new FieldModule() { M = "product_name", N = "product_name", T = SQLValueType.String, B = this.N };
            this.product_serial = new FieldModule() { M = "product_serial", N = "product_serial", T = SQLValueType.String, B = this.N };
            this.cost_price = new FieldModule() { M = "cost_price", N = "cost_price", T = SQLValueType.Int, B = this.N };
            this.original_price = new FieldModule() { M = "original_price", N = "original_price", T = SQLValueType.Int, B = this.N };
            this.special_price = new FieldModule() { M = "special_price", N = "special_price", T = SQLValueType.Int, B = this.N };
            this.member_price = new FieldModule() { M = "member_price", N = "member_price", T = SQLValueType.Int, B = this.N };
            this.product_state = new FieldModule() { M = "product_state", N = "product_state", T = SQLValueType.String, B = this.N };
            this.unit_name = new FieldModule() { M = "unit_name", N = "unit_name", T = SQLValueType.String, B = this.N };
            this.currency = new FieldModule() { M = "currency", N = "currency", T = SQLValueType.String, B = this.N };
            this.is_shelf = new FieldModule() { M = "is_shelf", N = "is_shelf", T = SQLValueType.Boolean, B = this.N };
            this.sort = new FieldModule() { M = "sort", N = "sort", T = SQLValueType.Int, B = this.N };
            this.can_sell_amt = new FieldModule() { M = "can_sell_amt", N = "can_sell_amt", T = SQLValueType.Int, B = this.N };
            this.introduction = new FieldModule() { M = "introduction", N = "introduction", T = SQLValueType.String, B = this.N };
            this.specifications = new FieldModule() { M = "specifications", N = "specifications", T = SQLValueType.String, B = this.N };
            this.product_category_l1_id = new FieldModule() { M = "product_category_l1_id", N = "product_category_l1_id", T = SQLValueType.Int, B = this.N };
            this.product_category_l2_id = new FieldModule() { M = "product_category_l2_id", N = "product_category_l2_id", T = SQLValueType.Int, B = this.N };
            this.product_category = new FieldModule() { M = "product_category", N = "product_category", T = SQLValueType.String, B = this.N };
            this.product_tree_id = new FieldModule() { M = "product_tree_id", N = "product_tree_id", T = SQLValueType.Int, B = this.N };
            this._隱藏 = new FieldModule() { M = "_隱藏", N = "_隱藏", T = SQLValueType.Boolean, B = this.N };
            this._新增人員 = new FieldModule() { M = "_新增人員", N = "_新增人員", T = SQLValueType.Int, B = this.N };
            this._新增單位 = new FieldModule() { M = "_新增單位", N = "_新增單位", T = SQLValueType.Int, B = this.N };
            this._新增日期 = new FieldModule() { M = "_新增日期", N = "_新增日期", T = SQLValueType.DateTime, B = this.N };
            this._修改人員 = new FieldModule() { M = "_修改人員", N = "_修改人員", T = SQLValueType.Int, B = this.N };
            this._修改單位 = new FieldModule() { M = "_修改單位", N = "_修改單位", T = SQLValueType.Int, B = this.N };
            this._修改日期 = new FieldModule() { M = "_修改日期", N = "_修改日期", T = SQLValueType.DateTime, B = this.N };
            this._語系 = new FieldModule() { M = "_語系", N = "_語系", T = SQLValueType.String, B = this.N };

            KeyFieldModules = new Dictionary<String, FieldModule>() { { this.id.N, this.id } };
        }
        public FieldModule id { get; set; }
        ///<summary>
        ///產品名稱
        ///</summary>
        public FieldModule product_name { get; set; }
        ///<summary>
        ///產品編號
        ///</summary>
        public FieldModule product_serial { get; set; }
        ///<summary>
        ///原價
        ///</summary>
        public FieldModule original_price { get; set; }
        ///<summary>
        ///特價
        ///</summary>
        public FieldModule special_price { get; set; }
        ///<summary>
        ///會員價
        ///</summary>
        public FieldModule member_price { get; set; }
        public FieldModule cost_price { get; set; }
        ///<summary>
        ///產品狀態
        ///</summary>
        public FieldModule product_state { get; set; }
        public FieldModule unit_name { get; set; }
        public FieldModule currency { get; set; }
        ///<summary>
        ///是否上架
        ///</summary>
        public FieldModule is_shelf { get; set; }
        public FieldModule sort { get; set; }
        public FieldModule can_sell_amt { get; set; }
        ///<summary>
        ///產品介紹
        ///</summary>
        public FieldModule introduction { get; set; }
        ///<summary>
        ///產品規格
        ///</summary>
        public FieldModule specifications { get; set; }
        public FieldModule product_category_l1_id { get; set; }
        public FieldModule product_category_l2_id { get; set; }
        public FieldModule product_category { get; set; }
        ///<summary>
        ///產品樹狀分類用
        ///</summary>
        public FieldModule product_tree_id { get; set; }
        public FieldModule _隱藏 { get; set; }
        public FieldModule _新增人員 { get; set; }
        public FieldModule _新增單位 { get; set; }
        public FieldModule _新增日期 { get; set; }
        public FieldModule _修改人員 { get; set; }
        public FieldModule _修改單位 { get; set; }
        public FieldModule _修改日期 { get; set; }
        public FieldModule _語系 { get; set; }
    }
    ///<summary>
    ///產品分類第一階
    ///</summary>
    public class Product_Category_L1 : TableMap<Product_Category_L1>
    {
        public Product_Category_L1()
        {
            N = "Product_Category_L1"; GetTabObj = this;
            this.id = new FieldModule() { M = "id", N = "product_category_l1_id", T = SQLValueType.Int, B = this.N };
            this.category_l1_name = new FieldModule() { M = "category_l1_name", N = "category_l1_name", T = SQLValueType.String, B = this.N };
            this.sort = new FieldModule() { M = "sort", N = "sort", T = SQLValueType.Int, B = this.N };
            this._隱藏 = new FieldModule() { M = "_隱藏", N = "_隱藏", T = SQLValueType.Boolean, B = this.N };
            this._新增人員 = new FieldModule() { M = "_新增人員", N = "_新增人員", T = SQLValueType.Int, B = this.N };
            this._新增單位 = new FieldModule() { M = "_新增單位", N = "_新增單位", T = SQLValueType.Int, B = this.N };
            this._新增日期 = new FieldModule() { M = "_新增日期", N = "_新增日期", T = SQLValueType.DateTime, B = this.N };
            this._修改人員 = new FieldModule() { M = "_修改人員", N = "_修改人員", T = SQLValueType.Int, B = this.N };
            this._修改單位 = new FieldModule() { M = "_修改單位", N = "_修改單位", T = SQLValueType.Int, B = this.N };
            this._修改日期 = new FieldModule() { M = "_修改日期", N = "_修改日期", T = SQLValueType.DateTime, B = this.N };
            this._語系 = new FieldModule() { M = "_語系", N = "_語系", T = SQLValueType.String, B = this.N };

            KeyFieldModules = new Dictionary<String, FieldModule>() { { this.id.N, this.id } };
        }
        public FieldModule id { get; set; }
        public FieldModule category_l1_name { get; set; }
        public FieldModule sort { get; set; }
        public FieldModule _隱藏 { get; set; }
        public FieldModule _新增人員 { get; set; }
        public FieldModule _新增單位 { get; set; }
        public FieldModule _新增日期 { get; set; }
        public FieldModule _修改人員 { get; set; }
        public FieldModule _修改單位 { get; set; }
        public FieldModule _修改日期 { get; set; }
        public FieldModule _語系 { get; set; }
    }
    ///<summary>
    ///產品分類第二階
    ///</summary>
    public class Product_Category_L2 : TableMap<Product_Category_L2>
    {
        public Product_Category_L2()
        {
            N = "Product_Category_L2"; GetTabObj = this;
            this.id = new FieldModule() { M = "id", N = "product_category_l2_id", T = SQLValueType.Int, B = this.N };
            this.product_category_l1_id = new FieldModule() { M = "product_category_l1_id", N = "product_category_l1_id", T = SQLValueType.Int, B = this.N };
            this.category_l2_name = new FieldModule() { M = "category_l2_name", N = "category_l2_name", T = SQLValueType.String, B = this.N };
            this.sort = new FieldModule() { M = "sort", N = "sort", T = SQLValueType.Int, B = this.N };
            this._隱藏 = new FieldModule() { M = "_隱藏", N = "_隱藏", T = SQLValueType.Boolean, B = this.N };
            this._新增人員 = new FieldModule() { M = "_新增人員", N = "_新增人員", T = SQLValueType.Int, B = this.N };
            this._新增單位 = new FieldModule() { M = "_新增單位", N = "_新增單位", T = SQLValueType.Int, B = this.N };
            this._新增日期 = new FieldModule() { M = "_新增日期", N = "_新增日期", T = SQLValueType.DateTime, B = this.N };
            this._修改人員 = new FieldModule() { M = "_修改人員", N = "_修改人員", T = SQLValueType.Int, B = this.N };
            this._修改單位 = new FieldModule() { M = "_修改單位", N = "_修改單位", T = SQLValueType.Int, B = this.N };
            this._修改日期 = new FieldModule() { M = "_修改日期", N = "_修改日期", T = SQLValueType.DateTime, B = this.N };
            this._語系 = new FieldModule() { M = "_語系", N = "_語系", T = SQLValueType.String, B = this.N };

            KeyFieldModules = new Dictionary<String, FieldModule>() { { this.id.N, this.id } };
        }
        public FieldModule id { get; set; }
        public FieldModule product_category_l1_id { get; set; }
        public FieldModule category_l2_name { get; set; }
        public FieldModule sort { get; set; }
        public FieldModule _隱藏 { get; set; }
        public FieldModule _新增人員 { get; set; }
        public FieldModule _新增單位 { get; set; }
        public FieldModule _新增日期 { get; set; }
        public FieldModule _修改人員 { get; set; }
        public FieldModule _修改單位 { get; set; }
        public FieldModule _修改日期 { get; set; }
        public FieldModule _語系 { get; set; }
    }
    ///<summary>
    ///產品樹狀分類
    ///</summary>
    public class Product_Tree : TableMap<Product_Tree>
    {
        public Product_Tree()
        {
            N = "Product_Tree"; GetTabObj = this;
            this.id = new FieldModule() { M = "id", N = "product_tree_id", T = SQLValueType.Int, B = this.N };
            this.pid = new FieldModule() { M = "pid", N = "parent_id", T = SQLValueType.Int, B = this.N };
            this.tree_name = new FieldModule() { M = "tree_name", N = "tree_name", T = SQLValueType.String, B = this.N };
            this.sort = new FieldModule() { M = "sort", N = "sort", T = SQLValueType.Int, B = this.N };
            this.is_category = new FieldModule() { M = "is_category", N = "is_category", T = SQLValueType.Boolean, B = this.N };
            this._隱藏 = new FieldModule() { M = "_隱藏", N = "_隱藏", T = SQLValueType.Boolean, B = this.N };
            this._新增人員 = new FieldModule() { M = "_新增人員", N = "_新增人員", T = SQLValueType.Int, B = this.N };
            this._新增單位 = new FieldModule() { M = "_新增單位", N = "_新增單位", T = SQLValueType.Int, B = this.N };
            this._新增日期 = new FieldModule() { M = "_新增日期", N = "_新增日期", T = SQLValueType.DateTime, B = this.N };
            this._修改人員 = new FieldModule() { M = "_修改人員", N = "_修改人員", T = SQLValueType.Int, B = this.N };
            this._修改單位 = new FieldModule() { M = "_修改單位", N = "_修改單位", T = SQLValueType.Int, B = this.N };
            this._修改日期 = new FieldModule() { M = "_修改日期", N = "_修改日期", T = SQLValueType.DateTime, B = this.N };
            this._語系 = new FieldModule() { M = "_語系", N = "_語系", T = SQLValueType.String, B = this.N };

            KeyFieldModules = new Dictionary<String, FieldModule>() { { this.id.N, this.id } };
        }
        public FieldModule id { get; set; }
        public FieldModule pid { get; set; }
        public FieldModule tree_name { get; set; }
        public FieldModule sort { get; set; }
        public FieldModule is_category { get; set; }
        public FieldModule _隱藏 { get; set; }
        public FieldModule _新增人員 { get; set; }
        public FieldModule _新增單位 { get; set; }
        public FieldModule _新增日期 { get; set; }
        public FieldModule _修改人員 { get; set; }
        public FieldModule _修改單位 { get; set; }
        public FieldModule _修改日期 { get; set; }
        public FieldModule _語系 { get; set; }
    }
    public class News : TableMap<News>
    {
        public News()
        {
            N = "News"; GetTabObj = this;
            this.id = new FieldModule() { M = "id", N = "news_id", T = SQLValueType.Int, B = this.N };
            this.title = new FieldModule() { M = "title", N = "title", T = SQLValueType.String, B = this.N };
            this.set_date = new FieldModule() { M = "set_date", N = "set_date", T = SQLValueType.DateTime, B = this.N };
            this.news_category_id = new FieldModule() { M = "news_category_id", N = "news_category_id", T = SQLValueType.Int, B = this.N };
            this.is_open = new FieldModule() { M = "is_open", N = "is_open", T = SQLValueType.Boolean, B = this.N };
            this.context = new FieldModule() { M = "context", N = "context", T = SQLValueType.String, B = this.N };
            this._隱藏 = new FieldModule() { M = "_隱藏", N = "_隱藏", T = SQLValueType.Boolean, B = this.N };
            this._新增人員 = new FieldModule() { M = "_新增人員", N = "_新增人員", T = SQLValueType.Int, B = this.N };
            this._新增單位 = new FieldModule() { M = "_新增單位", N = "_新增單位", T = SQLValueType.Int, B = this.N };
            this._新增日期 = new FieldModule() { M = "_新增日期", N = "_新增日期", T = SQLValueType.DateTime, B = this.N };
            this._修改人員 = new FieldModule() { M = "_修改人員", N = "_修改人員", T = SQLValueType.Int, B = this.N };
            this._修改單位 = new FieldModule() { M = "_修改單位", N = "_修改單位", T = SQLValueType.Int, B = this.N };
            this._修改日期 = new FieldModule() { M = "_修改日期", N = "_修改日期", T = SQLValueType.DateTime, B = this.N };
            this._語系 = new FieldModule() { M = "_語系", N = "_語系", T = SQLValueType.String, B = this.N };

            KeyFieldModules = new Dictionary<String, FieldModule>() { { this.id.N, this.id } };
        }
        public FieldModule id { get; set; }
        public FieldModule title { get; set; }
        public FieldModule set_date { get; set; }
        public FieldModule news_category_id { get; set; }
        public FieldModule is_open { get; set; }
        public FieldModule context { get; set; }
        public FieldModule _隱藏 { get; set; }
        public FieldModule _新增人員 { get; set; }
        public FieldModule _新增單位 { get; set; }
        public FieldModule _新增日期 { get; set; }
        public FieldModule _修改人員 { get; set; }
        public FieldModule _修改單位 { get; set; }
        public FieldModule _修改日期 { get; set; }
        public FieldModule _語系 { get; set; }
    }
    public class News_Category : TableMap<News_Category>
    {
        public News_Category()
        {
            N = "News_Category"; GetTabObj = this;
            this.news_category_id = new FieldModule() { M = "news_category_id", N = "news_category_id", T = SQLValueType.Int, B = this.N };
            this.category_name = new FieldModule() { M = "category_name", N = "category_name", T = SQLValueType.String, B = this.N };
            this.is_open = new FieldModule() { M = "is_open", N = "is_open", T = SQLValueType.Boolean, B = this.N };
            this.sort = new FieldModule() { M = "sort", N = "sort", T = SQLValueType.Int, B = this.N };
            this._隱藏 = new FieldModule() { M = "_隱藏", N = "_隱藏", T = SQLValueType.Boolean, B = this.N };
            this._新增人員 = new FieldModule() { M = "_新增人員", N = "_新增人員", T = SQLValueType.Int, B = this.N };
            this._新增單位 = new FieldModule() { M = "_新增單位", N = "_新增單位", T = SQLValueType.Int, B = this.N };
            this._新增日期 = new FieldModule() { M = "_新增日期", N = "_新增日期", T = SQLValueType.DateTime, B = this.N };
            this._修改人員 = new FieldModule() { M = "_修改人員", N = "_修改人員", T = SQLValueType.Int, B = this.N };
            this._修改單位 = new FieldModule() { M = "_修改單位", N = "_修改單位", T = SQLValueType.Int, B = this.N };
            this._修改日期 = new FieldModule() { M = "_修改日期", N = "_修改日期", T = SQLValueType.DateTime, B = this.N };
            this._語系 = new FieldModule() { M = "_語系", N = "_語系", T = SQLValueType.String, B = this.N };

            KeyFieldModules = new Dictionary<String, FieldModule>() { { this.news_category_id.N, this.news_category_id } };
        }
        public FieldModule news_category_id { get; set; }
        public FieldModule category_name { get; set; }
        public FieldModule is_open { get; set; }
        public FieldModule sort { get; set; }
        public FieldModule _隱藏 { get; set; }
        public FieldModule _新增人員 { get; set; }
        public FieldModule _新增單位 { get; set; }
        public FieldModule _新增日期 { get; set; }
        public FieldModule _修改人員 { get; set; }
        public FieldModule _修改單位 { get; set; }
        public FieldModule _修改日期 { get; set; }
        public FieldModule _語系 { get; set; }
    }
    ///<summary>
    ///一般網頁編輯
    ///</summary>
    public class Page_Context : TableMap<Page_Context>
    {
        public Page_Context()
        {
            N = "Page_Context"; GetTabObj = this;
            this.id = new FieldModule() { M = "id", N = "page_context_id", T = SQLValueType.Int, B = this.N };
            this.page_name = new FieldModule() { M = "page_name", N = "page_name", T = SQLValueType.String, B = this.N };
            this.is_open = new FieldModule() { M = "is_open", N = "is_open", T = SQLValueType.Boolean, B = this.N };
            this.sort = new FieldModule() { M = "sort", N = "sort", T = SQLValueType.Int, B = this.N };
            this.page_html = new FieldModule() { M = "page_html", N = "page_html", T = SQLValueType.String, B = this.N };
            this._隱藏 = new FieldModule() { M = "_隱藏", N = "_隱藏", T = SQLValueType.Boolean, B = this.N };
            this._新增人員 = new FieldModule() { M = "_新增人員", N = "_新增人員", T = SQLValueType.Int, B = this.N };
            this._新增單位 = new FieldModule() { M = "_新增單位", N = "_新增單位", T = SQLValueType.Int, B = this.N };
            this._新增日期 = new FieldModule() { M = "_新增日期", N = "_新增日期", T = SQLValueType.DateTime, B = this.N };
            this._修改人員 = new FieldModule() { M = "_修改人員", N = "_修改人員", T = SQLValueType.Int, B = this.N };
            this._修改單位 = new FieldModule() { M = "_修改單位", N = "_修改單位", T = SQLValueType.Int, B = this.N };
            this._修改日期 = new FieldModule() { M = "_修改日期", N = "_修改日期", T = SQLValueType.DateTime, B = this.N };
            this._語系 = new FieldModule() { M = "_語系", N = "_語系", T = SQLValueType.String, B = this.N };

            KeyFieldModules = new Dictionary<String, FieldModule>() { { this.id.N, this.id } };
        }
        public FieldModule id { get; set; }
        public FieldModule page_name { get; set; }
        public FieldModule is_open { get; set; }
        public FieldModule sort { get; set; }
        public FieldModule page_html { get; set; }
        public FieldModule _隱藏 { get; set; }
        public FieldModule _新增人員 { get; set; }
        public FieldModule _新增單位 { get; set; }
        public FieldModule _新增日期 { get; set; }
        public FieldModule _修改人員 { get; set; }
        public FieldModule _修改單位 { get; set; }
        public FieldModule _修改日期 { get; set; }
        public FieldModule _語系 { get; set; }
    }
    public class FAQ : TableMap<FAQ>
    {
        public FAQ()
        {
            N = "FAQ";
            GetTabObj = this;

            this.id = new FieldModule() { M = "id", N = "faq_id", T = SQLValueType.Int, B = this.N };
            this.title = new FieldModule() { M = "title", N = "title", T = SQLValueType.String, B = this.N };
            this.set_date = new FieldModule() { M = "set_date", N = "set_date", T = SQLValueType.DateTime, B = this.N };
            this.faq_category_id = new FieldModule() { M = "faq_category_id", N = "faq_category_id", T = SQLValueType.Int, B = this.N };
            this.is_open = new FieldModule() { M = "is_open", N = "is_open", T = SQLValueType.Boolean, B = this.N };
            this.context = new FieldModule() { M = "context", N = "context", T = SQLValueType.String, B = this.N };
            this.sort = new FieldModule() { M = "sort", N = "sort", T = SQLValueType.Int, B = this.N };
            this._隱藏 = new FieldModule() { M = "_隱藏", N = "_隱藏", T = SQLValueType.Boolean, B = this.N };
            this._新增人員 = new FieldModule() { M = "_新增人員", N = "_新增人員", T = SQLValueType.Int, B = this.N };
            this._新增單位 = new FieldModule() { M = "_新增單位", N = "_新增單位", T = SQLValueType.Int, B = this.N };
            this._新增日期 = new FieldModule() { M = "_新增日期", N = "_新增日期", T = SQLValueType.DateTime, B = this.N };
            this._修改人員 = new FieldModule() { M = "_修改人員", N = "_修改人員", T = SQLValueType.Int, B = this.N };
            this._修改單位 = new FieldModule() { M = "_修改單位", N = "_修改單位", T = SQLValueType.Int, B = this.N };
            this._修改日期 = new FieldModule() { M = "_修改日期", N = "_修改日期", T = SQLValueType.DateTime, B = this.N };
            this._語系 = new FieldModule() { M = "_語系", N = "_語系", T = SQLValueType.String, B = this.N };

            KeyFieldModules = new Dictionary<String, FieldModule>() { { this.id.N, this.id } };
        }
        public FieldModule id { get; set; }
        public FieldModule title { get; set; }
        public FieldModule set_date { get; set; }
        public FieldModule kind { get; set; }
        public FieldModule faq_category_id { get; set; }
        public FieldModule is_open { get; set; }
        public FieldModule sort { get; set; }
        public FieldModule context { get; set; }
        public FieldModule _隱藏 { get; set; }
        public FieldModule _新增人員 { get; set; }
        public FieldModule _新增單位 { get; set; }
        public FieldModule _新增日期 { get; set; }
        public FieldModule _修改人員 { get; set; }
        public FieldModule _修改單位 { get; set; }
        public FieldModule _修改日期 { get; set; }
        public FieldModule _語系 { get; set; }
    }
    public class FAQ_Category : TableMap<FAQ_Category>
    {
        public FAQ_Category()
        {
            N = "FAQ_Category"; GetTabObj = this;
            this.faq_category_id = new FieldModule() { M = "faq_category_id", N = "FAQ_category_id", T = SQLValueType.Int, B = this.N };
            this.category_name = new FieldModule() { M = "category_name", N = "category_name", T = SQLValueType.String, B = this.N };
            this.is_open = new FieldModule() { M = "is_open", N = "is_open", T = SQLValueType.Boolean, B = this.N };
            this.sort = new FieldModule() { M = "sort", N = "sort", T = SQLValueType.Int, B = this.N };
            this._隱藏 = new FieldModule() { M = "_隱藏", N = "_隱藏", T = SQLValueType.Boolean, B = this.N };
            this._新增人員 = new FieldModule() { M = "_新增人員", N = "_新增人員", T = SQLValueType.Int, B = this.N };
            this._新增單位 = new FieldModule() { M = "_新增單位", N = "_新增單位", T = SQLValueType.Int, B = this.N };
            this._新增日期 = new FieldModule() { M = "_新增日期", N = "_新增日期", T = SQLValueType.DateTime, B = this.N };
            this._修改人員 = new FieldModule() { M = "_修改人員", N = "_修改人員", T = SQLValueType.Int, B = this.N };
            this._修改單位 = new FieldModule() { M = "_修改單位", N = "_修改單位", T = SQLValueType.Int, B = this.N };
            this._修改日期 = new FieldModule() { M = "_修改日期", N = "_修改日期", T = SQLValueType.DateTime, B = this.N };
            this._語系 = new FieldModule() { M = "_語系", N = "_語系", T = SQLValueType.String, B = this.N };

            KeyFieldModules = new Dictionary<String, FieldModule>() { { this.faq_category_id.N, this.faq_category_id } };
        }
        public FieldModule faq_category_id { get; set; }
        public FieldModule category_name { get; set; }
        public FieldModule is_open { get; set; }
        public FieldModule sort { get; set; }
        public FieldModule _隱藏 { get; set; }
        public FieldModule _新增人員 { get; set; }
        public FieldModule _新增單位 { get; set; }
        public FieldModule _新增日期 { get; set; }
        public FieldModule _修改人員 { get; set; }
        public FieldModule _修改單位 { get; set; }
        public FieldModule _修改日期 { get; set; }
        public FieldModule _語系 { get; set; }
    }
    #endregion

    #endregion
}
