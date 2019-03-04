using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductWebAPI.Contracts
{
    public interface IRepositoryWrapper
    {
        IProductRepository Product { get; }
    }
}
