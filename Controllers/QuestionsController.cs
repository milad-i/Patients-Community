using Microsoft.AspNetCore.Mvc;
using PatientsCommunity.Data;
using PatientsCommunity.Interfaces;
using PatientsCommunity.Models;

namespace PatientsCommunity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestion _question;

        public QuestionsController(IQuestion question)
        {
            _question = question;
        }
        //==================================================================================================
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuestionModel>>> GetQuestions()
        {
            var questions = await _question.GetQuestions();

            if (!questions.Any())
            {
                return NotFound();
            }
            return questions;
        }
        //==================================================================================================
        [HttpGet("{id}")]
        public async Task<ActionResult<QuestionModel>> GetQuestion(Guid id)
        {
            var question = await _question.GetQuestion(id);

            if (question == null)
            {
                return NotFound();
            }

            return question;
        }
        //==================================================================================================
        [HttpPut("{id}")]
        public IActionResult UpdateQuestion(Guid id, [FromForm] QuestionModel question, [FromForm] List<int> categoryIds)
        {
            if (id != question.Id)
            {
                return BadRequest();
            }

            if (_question.QuestionExist(id) == false)
            {
                return NotFound();
            }

            try
            {
                _question.UpdateQuestion(id, question, categoryIds);
                return Ok("Update Was Successful");
            }
            catch
            {
                return Content("Error on Update");
            }


        }
        //==================================================================================================
        [HttpPost]
        public ActionResult<QuestionModel> CreateQuestion([FromForm] QuestionModel question, [FromForm] List<int> categoryIds)
        {
            if (categoryIds.Count() == 0)
            {
                return Content("No Category Selected");
            }

            try
            {
                _question.CreateQuestion(question, categoryIds);
                //return CreatedAtAction("GetQuestion", new { id = question.Id }, question);
                return Ok("Create Was Successful");
            }
            catch (Exception)
            {
                return Content("Error on Create");
            }
        }
        //==================================================================================================
        [HttpDelete("{id}")]
        public IActionResult DeleteQuestion(Guid id)
        {
            if (_question.QuestionExist(id) == false)
            {
                return NotFound();
            }

            try
            {
                _question.DeleteQuestion(id);
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
