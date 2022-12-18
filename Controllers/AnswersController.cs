using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatientsCommunity.Data;
using PatientsCommunity.Interfaces;
using PatientsCommunity.Models;

namespace PatientsCommunity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswersController : ControllerBase
    {
        private readonly IAnswer _answer;

        public AnswersController(IAnswer answer)
        {
            _answer= answer;
        }

        //==================================================================================================
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnswerModel>>> GetAnswers()
        {
            var answers = await _answer.GetAnswers();

            if (!answers.Any())
            {
                return Content("No Item Found");
            }
            return answers;
        }
        //==================================================================================================
        [HttpGet("{id}")]
        public async Task<ActionResult<AnswerModel>> GetAnswer(int id)
        {
            var answer = await _answer.GetAnswer(id);

            if (answer == null)
            {
                return Content("Not Found");
            }

            return answer;
        }
        //==================================================================================================
        [HttpPut("{id}")]
        public IActionResult UpdateAnswer(int id, [FromForm] AnswerModel AnswerModel)
        {
            if (id != AnswerModel.Id)
            {
                return BadRequest();
            }

            if (_answer.AnswerExist(id) == false)
            {
                return Content("Not Found");
            }

            try
            {
                _answer.UpdateAnswer(id, AnswerModel);
                return Ok("Update Was Successful");
            }
            catch
            {
                return Content("Error on Update");
            }
        }
        //==================================================================================================
        [HttpPost]
        public ActionResult<AnswerModel> CreateAnswer([FromForm] AnswerModel AnswerModel)
        {
            try
            {
                _answer.CreateAnswer(AnswerModel);
                return Ok("Create Was Successful");
            }
            catch (Exception)
            {
                return Content("Error on Create");
            }
        }
        //==================================================================================================
        [HttpDelete("{id}")]
        public IActionResult DeleteAnswerModel(int id)
        {
            if (_answer.AnswerExist(id) == false)
            {
                return Content("Not Found");
            }

            try
            {
                _answer.DeleteAnswer(id);
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
