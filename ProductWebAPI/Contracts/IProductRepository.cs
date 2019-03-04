using ProductWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductWebAPI.Contracts
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(Guid productId);
        void CreateProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
    }
}
