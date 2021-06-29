using API.Models.Forms;
using BxlForm.DemoSecurity.Models.Client.Data;
using BxlForm.DemoSecurity.Models.Client.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryRepository _category;

        public CategoryController(ICategoryRepository category)
        {
            _category = category;
        }


        // GET: api/<CategoryController>
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return _category.Get();
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public Category Get(int id)
        {
            return _category.GetCat(id);
        }

        //// POST api/<CategoryController>
        [HttpPost]
        public IActionResult Post([FromBody] CategoryForm categoryform)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Category category = new Category(categoryform.Name);

            _category.Insert(category);

            return Ok();
        }

        //// PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateCategoryForm categoryForm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Category category = new Category(categoryForm.Name);

            _category.Update(id, category);

            return Ok();
        }

        //// DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_category.GetCat(id) is null)
            {
                return BadRequest();
            }
            _category.Delete(id);

            return Ok();
        }
    }
}
