using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductWebAPI.Models
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductCreateInputModel, Product>();
            CreateMap<ProductUpdateInputModel, Product>();
        }
    }
}
