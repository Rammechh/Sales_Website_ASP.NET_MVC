using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.DomainModels;

namespace Company.ServiceContracts
{
    public interface iProductsService
    {
        List<Product> GetProducts();
        List<Product> SearchProducts(string ProductName);
        Product GetProductByProductID(long ProductID);
        void InsertProduct(Product p);
        void DeleteProduct(long ProductID);
        void UpdateProduct(Product p);
    }
}
