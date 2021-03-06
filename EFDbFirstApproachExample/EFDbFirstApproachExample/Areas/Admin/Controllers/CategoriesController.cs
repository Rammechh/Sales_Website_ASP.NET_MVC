using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Company.DataLayer;
using Company.DomainModels;
using EFDbFirstApproachExample.Filters;

namespace EFDbFirstApproachExample.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class CategoriesController : Controller
    {
        
        CompanyDbContext db = new CompanyDbContext();
        // GET: Categories/Index
        public ActionResult Index()
        {
            //EFDBFirstDatabaseEntities1 db = new EFDBFirstDatabaseEntities1();
            List<Category> categories = db.Categories.ToList();
            return View(categories);
        }
    }
}