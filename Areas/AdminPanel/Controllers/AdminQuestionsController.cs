using Microsoft.AspNetCore.Mvc;
using PatientsCommunity.Data;
using PatientsCommunity.Interfaces;
using PatientsCommunity.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace PatientsCommunity.Controllers
{
    [Route("api/Areas/AdminPanel/[controller]")]
    [ApiController]
    public class AdminQuestionsController : ControllerBase
    {
        private readonly IAdmin _admin;

        public AdminQuestionsController(IAdmin admin)
        {
            _admin = admin;
        }
        //==================================================================================================
        [HttpGet]
        [SwaggerOperation(summary: "Tip: Use [search] queryString for searching and [page] queryString to pagination.")]
        public async Task<ActionResult<IEnumerable<QuestionModel>>> GetQuestions(int page = 1, string? search = null)
        {
            //Get Questions from DB
            var questions = await _admin.GetQuestions();

            //Search
            if (!string.IsNullOrEmpty(search))
            {
                questions = questions.Where(q => q.Title.Contains(search)).ToList();
            }

            //Pagination
            int pageLimit = 30;
            questions = questions.Skip((page * pageLimit) - pageLimit).Take(pageLimit).ToList();

            if (!questions.Any())
            {
                return Content("No Item Found");
            }
            return questions;
        }
        //==================================================================================================
        [HttpGet("{id}")]
        public async Task<ActionResult<QuestionModel>> GetQuestion(Guid id)
        {
            var question = await _admin.GetQuestion(id);

            if (question == null)
            {
                return Content("Not Found");
            }

            return question;
        }
        //==================================================================================================
    }
}
