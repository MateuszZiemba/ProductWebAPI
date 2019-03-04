using ProductWebAPI.Contexts;
using ProductWebAPI.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProductWebAPI.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T: class
    {
        protected ProductContext ProductContext { get; set; }
        public RepositoryBase(ProductContext productContext)
        {
            this.ProductContext = productContext;
        }

        public IEnumerable<T> FindAll()
        {
            return this.ProductContext.Set<T>();
        }
        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.ProductContext.Set<T>().Where(expression);
        }
        public void Create(T entity)
        {
            this.ProductContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.ProductContext.Set<T>().Update(entity);
        }
        public void Delete(T entity)
        {
            this.ProductContext.Set<T>().Remove(entity);
        }
        public void Save()
        {
            this.ProductContext.SaveChanges();
        }
    }
}
