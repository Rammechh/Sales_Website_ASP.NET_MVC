using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFDbFirstApproachExample.Models;

namespace EFDbFirstApproachExample.Controllers
{
    public class BrandsController : Controller
    {
        // GET: Brands/Index
        CompanyDbContext db = new CompanyDbContext();
        public ActionResult Index()
        {
            //EFDBFirstDatabaseEntities1 db = new EFDBFirstDatabaseEntities1();
            List<Brand> brands = db.Brands.ToList();
            return View(brands);
        }
    }
}