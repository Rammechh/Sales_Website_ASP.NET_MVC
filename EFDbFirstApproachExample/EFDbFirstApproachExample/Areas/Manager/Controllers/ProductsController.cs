using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Company.DataLayer;
using Company.DomainModels;
using EFDbFirstApproachExample.Filters;

namespace EFDbFirstApproachExample.Areas.Manager.Controllers
{
    [ManagerAuthorization]
    public class ProductsController : Controller
    {
        CompanyDbContext db = new CompanyDbContext();
        // GET: Products/Index
        public ActionResult Index(string search = "", string SortColumn = "ProductID", string IconClass = "fa-sort-asc", int PageNo = 1)
        {
            //EFDBFirstDatabaseEntities1 db = new EFDBFirstDatabaseEntities1();

            //SqlParameter[] sqlParameters = new SqlParameter[]
            //{     
            //    new SqlParameter("@BrandID",2)
            //};
            //List<Product> products = db.Database.SqlQuery<Product>("exec getProductsByBrandID @BrandID", sqlParameters).ToList();
            ViewBag.searchh = search;
            List<Product> products = db.Products.Where(temp => temp.ProductName.Contains(search)).ToList();

            //Sorting
            ViewBag.SortColumn = SortColumn;
            ViewBag.IconClass = IconClass;
            if (SortColumn == "ProductID")
            {
                if (IconClass == "fa-sort-asc")
                {
                    products = products.OrderBy(temp => temp.ProductID).ToList();
                }
                else
                {
                    products = products.OrderByDescending(temp => temp.ProductID).ToList();
                }
            }
            if (SortColumn == "ProductName")
            {
                if (IconClass == "fa-sort-asc")
                {
                    products = products.OrderBy(temp => temp.ProductName).ToList();
                }
                else
                {
                    products = products.OrderByDescending(temp => temp.ProductName).ToList();
                }
            }
            if (SortColumn == "Price")
            {
                if (IconClass == "fa-sort-asc")
                {
                    products = products.OrderBy(temp => temp.Price).ToList();
                }
                else
                {
                    products = products.OrderByDescending(temp => temp.Price).ToList();
                }
            }
            if (SortColumn == "DateofPurchase")
            {
                if (IconClass == "fa-sort-asc")
                {
                    products = products.OrderBy(temp => temp.DOP).ToList();
                }
                else
                {
                    products = products.OrderByDescending(temp => temp.DOP).ToList();
                }
            }
            if (SortColumn == "Availabilitystatus")
            {
                if (IconClass == "fa-sort-asc")
                {
                    products = products.OrderBy(temp => temp.AvailabilityStatus).ToList();
                }
                else
                {
                    products = products.OrderByDescending(temp => temp.AvailabilityStatus).ToList();
                }
            }
            if (SortColumn == "CategoryId")
            {
                if (IconClass == "fa-sort-asc")
                {
                    products = products.OrderBy(temp => temp.CategoryID).ToList();
                }
                else
                {
                    products = products.OrderByDescending(temp => temp.CategoryID).ToList();
                }
            }
            if (SortColumn == "BrandId")
            {
                if (IconClass == "fa-sort-asc")
                {
                    products = products.OrderBy(temp => temp.BrandID).ToList();
                }
                else
                {
                    products = products.OrderByDescending(temp => temp.BrandID).ToList();
                }
            }
            if (SortColumn == "Active")
            {
                if (IconClass == "fa-sort-asc")
                {
                    products = products.OrderBy(temp => temp.Active).ToList();
                }
                else
                {
                    products = products.OrderByDescending(temp => temp.Active).ToList();
                }
            }
            /*Paging*/
            int NoOfRecordsPerPage = 5;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(products.Count) / Convert.ToDouble(NoOfRecordsPerPage)));
            int NoOfRecordsToSkip = (PageNo - 1) * NoOfRecordsPerPage;
            ViewBag.NoOfPages = NoOfPages;
            ViewBag.PageNo = PageNo;
            ViewBag.NoOfRecordsPerPage = NoOfRecordsPerPage;
            products = products.Skip(NoOfRecordsToSkip).Take(NoOfRecordsPerPage).ToList();
            return View(products);
            //when condition needed use below
            //List<Product> products = db.Products.ToList();
            //List<Product> products = db.Products.Where(temp=>temp.CategoryID==1 && temp.Price >=50000).ToList();
            //List<Product> products = db.Products.Where(temp => temp.ProductName.Contains(search)).ToList();
            //return View(products);
        }
        public ActionResult Details(int id)
        {
            //EFDBFirstDatabaseEntities1 db = new EFDBFirstDatabaseEntities1();
            Product p = db.Products.Where(temp => temp.ProductID == id).FirstOrDefault();
            return View(p);
        }
        public ActionResult Create()
        {
            //EFDBFirstDatabaseEntities1 db = new EFDBFirstDatabaseEntities1();
            ViewBag.Categories = db.Categories.ToList();
            ViewBag.Brands = db.Brands.ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,ProductName,Price,DOP,AvailabilityStatus,CategoryID,BrandID,Active,Photo")] Product p)

        {
            if (ModelState.IsValid)
            {
                //EFDBFirstDatabaseEntities1 db = new EFDBFirstDatabaseEntities1();
                if (Request.Files.Count >= 1)
                {
                    var file = Request.Files[0];
                    byte[] imgBytes = new Byte[file.ContentLength];
                    file.InputStream.Read(imgBytes, 0, file.ContentLength - 1);
                    var base64String = Convert.ToBase64String(imgBytes, 0, imgBytes.Length);
                    p.Photo = base64String;
                }
                db.Products.Add(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.categories = db.Categories.ToList();
                ViewBag.Brands = db.Brands.ToList();
                return View();
            }
        }
        public ActionResult Edit(long id)
        {
            //EFDBFirstDatabaseEntities1 db = new EFDBFirstDatabaseEntities1();
            Product existingProduct = db.Products.Where(temp => temp.ProductID == id).FirstOrDefault();
            ViewBag.Categories = db.Categories.ToList();
            ViewBag.Brands = db.Brands.ToList();
            return View(existingProduct);
        }
        [HttpPost]
        public ActionResult Edit(Product p)
        {
            if (ModelState.IsValid)
            {
                Product existingProduct = db.Products.Where(temp => temp.ProductID == p.ProductID).FirstOrDefault();
                if (Request.Files.Count >= 1)
                {
                    var file = Request.Files[0];
                    var imgBytes = new Byte[file.ContentLength];
                    file.InputStream.Read(imgBytes, 0, file.ContentLength);
                    var base64String = Convert.ToBase64String(imgBytes, 0, imgBytes.Length);
                    existingProduct.Photo = base64String;
                }
                //EFDBFirstDatabaseEntities1 db = new EFDBFirstDatabaseEntities1();

                existingProduct.ProductName = p.ProductName;
                existingProduct.Price = p.Price;
                existingProduct.DOP = p.DOP;
                existingProduct.CategoryID = p.CategoryID;
                existingProduct.BrandID = p.BrandID;
                existingProduct.AvailabilityStatus = p.AvailabilityStatus;
                existingProduct.Active = p.Active;

                db.SaveChanges();
            }
            return RedirectToAction("Index", "Products");
        }
    }
}