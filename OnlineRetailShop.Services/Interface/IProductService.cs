using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineRetailShop.Repository.Entities;

namespace OnlineRetailShop.Services.Interface
{
    public interface IProductService
    {
        Product GetProductById(Guid productId);
        IEnumerable<Product> GetAllProducts();
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Guid productId);
    }
}
