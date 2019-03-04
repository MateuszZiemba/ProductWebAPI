using ProductWebAPI.Contexts;
using ProductWebAPI.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductWebAPI.Repository
{
    public class RepositoryWrapper:IRepositoryWrapper
    {
        private ProductContext _productContext;
        private IProductRepository _product;

        public IProductRepository Product {
            get {
                if (_product == null)
                {
                    _product = new ProductRepository(_productContext);
                }
                return _product;
            }
        }

        public RepositoryWrapper(ProductContext productContext)
        {
            _productContext = productContext;
        }
    }
}
