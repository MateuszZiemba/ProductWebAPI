using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductWebAPI.Contexts;
using ProductWebAPI.Contracts;
using ProductWebAPI.Models;

namespace ProductWebAPI.Controllers
{
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public ProductController(IMapper mapper, IRepositoryWrapper repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            try
            {
                var products = _repository.Product.GetAllProducts();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, String.Concat(Resources.Messages.InternalError, ex.ToString()));
            }
        }

        [HttpGet("{id}", Name = "ProductById")]
        public IActionResult GetProductById(Guid id)
        {
            try
            {
                var product = _repository.Product.GetProductById(id);
                if (product == null)
                    return NotFound();
                else
                    return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, String.Concat(Resources.Messages.InternalError, ex.ToString()));
            }
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody]ProductCreateInputModel productDTO) 
        {
            try
            {
                var product = _mapper.Map<ProductCreateInputModel, Product>(productDTO);
                if (product == null)
                    return BadRequest(Resources.Messages.ProductIsNull);
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.Select(x => x.Value.Errors).Where(y => y.Count > 0).ToList());

                _repository.Product.CreateProduct(product);
                return Content(product.Id.ToString());
            }
            catch (Exception ex)
            {
                return StatusCode(500, String.Concat(Resources.Messages.InternalError, ex.ToString()));
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(Guid id, [FromBody]ProductUpdateInputModel productDTO)
        {
            try
            {
                if (productDTO == null)
                    return BadRequest(Resources.Messages.ProductIsNull);
                productDTO.Id = id;
                var product = _mapper.Map<ProductUpdateInputModel, Product>(productDTO);
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.Select(x => x.Value.Errors).Where(y => y.Count > 0).ToList());

                _repository.Product.UpdateProduct(product);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, String.Concat(Resources.Messages.InternalError, ex.ToString()));
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var product = _repository.Product.GetProductById(id);
                if(product == null)
                    return BadRequest(String.Format(Resources.Messages.ObjectMissing, id));
                _repository.Product.DeleteProduct(product);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, String.Concat(Resources.Messages.InternalError, ex.ToString()));
            }
        }
    }
}
