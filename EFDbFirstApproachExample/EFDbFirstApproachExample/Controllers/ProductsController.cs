using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Company.DataLayer;
using Company.DomainModels;
using EFDbFirstApproachExample.Filters;

namespace EFDbFirstApproachExample.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        [MyAuthenticationFilter]
        [CustomerAuthorization]
        public ActionResult Index()
        {
            CompanyDbContext db = new CompanyDbContext();
            List<Product> products = db.Products.ToList();
            return View(products);
        }
        [ChildActionOnly]
        public ActionResult DisplaySingleProduct(Product p)
        {
            return PartialView("MyProduct",p);
        }
    }
}