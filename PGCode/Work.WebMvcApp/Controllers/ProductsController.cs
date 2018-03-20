using System.Web.Mvc;
using ProcCore.Business.Logic;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DotWeb.WebApp.Controllers
{
    public class ProductsController : WebFrontController
    {
        public ActionResult Index(int? id)
        {
            ViewBag.BodyClass = "Products";
            if (id == null)
            {
                a_Product ac_Product = new a_Product() { Connection = getSQLConnection(), logPlamInfo = plamInfo };
                var r = ac_Product.SearchMaster2(new q_Product() { MaxRecord = 1 }, 0).SearchData.FirstOrDefault();
                webInfo.product_category.Product_Category_Fix_Product = r.id;
                this.webInfo.product = r;

            }
            else
            {
                a_Product ac_Product = new a_Product() { Connection = getSQLConnection(), logPlamInfo = plamInfo };
                var r = ac_Product.GetDataMaster((int)id, 0).SearchData;
                webInfo.product_category.Product_Category_Fix_Product = r.id;
                this.webInfo.product = r;
            }

            var c = CodeSheet.ProductCategory.MakeCodes().Where(x => x.Code == webInfo.product.product_category).First();
            this.webInfo.product_category.Product_Category_Fix_Select = new m_Product_Category_Fix() { Category_Code = c.Code, Category_Name = c.Value };

            return View("Products", webInfo);
        }
    }
}