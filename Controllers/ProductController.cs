using EcommerceApi.Model;
using EcommerceApi.Repository;
using EcommerceApi.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository _productRepository)
        {
            this._productRepository = _productRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var listOfProduct = _productRepository.Get(null);
            return Ok(listOfProduct);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Detals(int id)
        {
            var product = _productRepository.GetOne(e => e.ProductId == id);
            if (product != null)
            {
                return Ok(product);
            }
            else
                return BadRequest();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
           
                _productRepository.Add(product);
                return Created($"{Request.Scheme}://{Request.Host}/api/Product/{product.ProductId}", product);
            
        }

        [HttpPut]
        public IActionResult Update(Product product)
        {
            if (ModelState.IsValid)
            {
                _productRepository.Update(product);
                return Created($"{Request.Scheme}://{Request.Host}/api/Product/{product.ProductId}", product);
            }
            return BadRequest(product);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var product = _productRepository.GetOne(e => e.CategoryId == id);
            if (product != null)
            {
                _productRepository.Delete(product);
                return Ok();
            }
            else
                return NotFound();

        }
    }
}
