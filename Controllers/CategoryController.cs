using EcommerceApi.Model;
using EcommerceApi.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository _categoryRepository)
        {
            this._categoryRepository = _categoryRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var listofcategory = _categoryRepository.Get(null);
            return Ok(listofcategory);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Detals(int id)
        {
            var category = _categoryRepository.GetOne(e => e.CategoryId == id);
            if (category == null)
                return NotFound();
            else
                return Ok(category);
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.Add(category);
                return Created($"{Request.Scheme}://{Request.Host}/api/Category/{category.CategoryId}" ,category);
            }
            return BadRequest(category);
        }

        
        [HttpPut]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.Update(category);
                return Created($"{Request.Scheme}://{Request.Host}/api/Category/{category.CategoryId}", category);
            }
            return BadRequest(category);
        }

        [HttpDelete]

        public IActionResult Delete(int id)
        {
            var category = _categoryRepository.GetOne(e => e.CategoryId == id);
            if (category != null)
            {
                _categoryRepository.Delete(category);
                return Ok();
            }
            else
                return NotFound();
                
        }
    }
}
