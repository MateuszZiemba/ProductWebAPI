using Microsoft.ApplicationInsights.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductWebAPI.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.Messages), ErrorMessageResourceName = "NameIsRequired")]
        [StringLength(100, ErrorMessageResourceType = typeof(Resources.Messages), ErrorMessageResourceName = "NameIsTooLong")] 
        public string Name { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.Messages), ErrorMessageResourceName = "PriceIsRequired")] 
        public decimal Price { get; set; }
    }
}
