using OnlineRetailShop.Repository.Entities;
using OnlineRetailShop.Services.Interface;
using OnlineRetailShop.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailShop.Services.SImplementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void AddProduct(Product product)
        {
            product.ProductId = Guid.NewGuid();
            _productRepository.Add(product);
        }

        public void DeleteProduct(Guid productId)
        {
            _productRepository.Delete(productId);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _productRepository.GetAll();
        }

        public Product GetProductById(Guid productId)
        {
            return _productRepository.GetById(productId);
        }

        public void UpdateProduct(Product product)
        {
            _productRepository.Update(product);
        }
    }
}
