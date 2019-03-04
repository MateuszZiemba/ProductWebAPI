using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductWebAPI.Models
{
    public class ProductUpdateInputModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.Messages), ErrorMessageResourceName = "NameIsRequired")]
        [StringLength(100, ErrorMessageResourceType = typeof(Resources.Messages), ErrorMessageResourceName = "NameIsTooLong")]
        public string Name { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.Messages), ErrorMessageResourceName = "PriceIsRequired")]
        public decimal Price { get; set; }
    }
}
