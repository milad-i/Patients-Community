using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatientsCommunity.Data;
using PatientsCommunity.Interfaces;
using PatientsCommunity.Models;

namespace PatientsCommunity.Controllers
{
    [Route("api/Area/AdminPanel/[controller]")]
    [ApiController]
    public class AdminAnswersController : ControllerBase
    {
        private readonly IAdmin _admin;

        public AdminAnswersController(IAdmin admin)
        {
            _admin= admin;
        }
        //==================================================================================================
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnswerModel>>> GetAnswers()
        {
            var answers = await _admin.GetAnswers();

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
            var answer = await _admin.GetAnswer(id);

            if (answer == null)
            {
                return Content("Not Found");
            }

            return answer;
        }
        //==================================================================================================
    }
}
