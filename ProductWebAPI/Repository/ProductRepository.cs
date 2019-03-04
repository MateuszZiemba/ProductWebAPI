using ProductWebAPI.Contexts;
using ProductWebAPI.Contracts;
using ProductWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductWebAPI.Repository
{
    public class ProductRepository: RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(ProductContext productContext) :base (productContext)
        {

        }

        public IEnumerable<Product> GetAllProducts()
        {
            return FindAll().OrderBy(p => p.Name);
        }

        public Product GetProductById(Guid productId)
        {
            return FindByCondition(p => p.Id.Equals(productId)).FirstOrDefault();
        }

        public void CreateProduct(Product product)
        {
            product.Id = Guid.NewGuid();
            Create(product);
            Save();
        }

        public void UpdateProduct(Product product)
        {
            Update(product);
            Save();
        }

        public void DeleteProduct(Product product)
        {
            Delete(product);
            Save();
        }
    }
}
