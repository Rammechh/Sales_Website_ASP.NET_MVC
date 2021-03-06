using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.DomainModels;
using Company.ServiceContracts;
using Company.DataLayer;
using Company.RepositoryContracts;
using Company.RepositoryLayer;

namespace Company.ServiceLayer
{
    public class ProductsService : iProductsService
    {
        //CompanyDbContext db;
        //public ProductsService()
        //{
        //    this.db = new CompanyDbContext();
        //}

        IProductsRepository prodRep;
        public ProductsService(IProductsRepository r)
        {
            this.prodRep = r;
        }
        public List<Product> GetProducts()
        {
            //List<Product> products = db.Products.ToList();
            List<Product> products = prodRep.GetProducts();
            return products;
        }

        public List<Product> SearchProducts(string ProductName)
        {
            //List<Product> products = db.Products.Where(temp => temp.ProductName.Contains(ProductName)).ToList();
            List<Product> products = prodRep.SearchProducts(ProductName);
            return products;
        }

        public Product GetProductByProductID(long ProductID)
        {
            //Product p = db.Products.Where(temp => temp.ProductID == ProductID).FirstOrDefault();
            Product p = prodRep.GetProductByProductID(ProductID);
            return p;
        }

        public void InsertProduct(Product p)
        {
            //db.Products.Add(p);
            //db.SaveChanges();

            //adding Business Logic
            if (p.Price <= 1000000)
            {
                prodRep.InsertProduct(p);
            }
            else
            {
                throw new Exception("Product exceeds the limit");
            }
        }

        public void UpdateProduct(Product p)
        {
            //Product existingProduct = db.Products.Where(temp => temp.ProductID == p.ProductID).FirstOrDefault();
            //existingProduct.ProductName = p.ProductName;
            //existingProduct.Price = p.Price;
            //existingProduct.DOP = p.DOP;
            //existingProduct.CategoryID = p.CategoryID;
            //existingProduct.BrandID = p.BrandID;
            //existingProduct.AvailabilityStatus = p.AvailabilityStatus;
            //existingProduct.Active = p.Active;
            //existingProduct.Photo = p.Photo;
            //db.SaveChanges();
            prodRep.UpdateProduct(p);
        }

        public void DeleteProduct(long ProductID)
        {
            //Product p = db.Products.Where(temp => temp.ProductID == ProductID).FirstOrDefault();
            //db.Products.Remove(p);
            //db.SaveChanges();
            prodRep.DeleteProduct(ProductID);
        }
    }
}
