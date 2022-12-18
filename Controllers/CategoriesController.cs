using Microsoft.AspNetCore.Mvc;
using PatientsCommunity.Interfaces;
using PatientsCommunity.Models;

namespace PatientsCommunity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategory _category;

        public CategoriesController(ICategory category)
        {
            _category = category;
        }
        //==================================================================================================
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryModel>>> GetCategories()
        {
          var categories =  await _category.GetCategories();

            if (!categories.Any())
            {
                return Content("No Item Found");
            }
            return categories;
        }
        //==================================================================================================
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryModel>> GetCategory(int id)
        {
          var category =  await _category.GetCategory(id);

            if (category == null)
            {
                return Content("Not Found");
            }

            return category;
        }
        //==================================================================================================
        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, [FromForm] CategoryModel category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            if (_category.CategoryExist(id) == false)
            {
                return Content("Not Found");
            }

            try
            {
                _category.UpdateCategory(id, category);
                return Ok("Update Was Successful");
            }
            catch
            {
                return Content("Error on Update");
            }

            
        }
        //==================================================================================================
        [HttpPost]
        public ActionResult<CategoryModel> CreateCategory([FromForm] CategoryModel category)
        {
            try
            {
                if (_category.CategoryExistByName(category.Name))
                {
                    return Content("Category Name Already Exist");

                }
                _category.CreateCategory(category);
                //return CreatedAtAction("GetCategory", new { id = categoryModel.Id }, categoryModel);
                return Ok("Create Was Successful");
            }
            catch (Exception)
            {
                return Content("Error on Create");
            }
        }
        //==================================================================================================
        [HttpDelete("{id}")]
        public IActionResult DeleteCategoryModel(int id)
        {
            if (_category.CategoryExist(id) == false)
            {
                return Content("Not Found");
            }

            try
            {
                _category.DeleteCategory(id);
                return Ok("Delete Was Successful");
            }
            catch (Exception)
            {
                return Content("Error on Delete");
            }
            
        }
        //==================================================================================================
    }
}
