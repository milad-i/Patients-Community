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
    [Route("api/Area/Profile/[controller]")]
    [ApiController]
    public class UserAnswersController : ControllerBase
    {
        private readonly IProfile _profile;

        public UserAnswersController(IProfile profile)
        {
            _profile = profile;
        }

        //==================================================================================================
        private Guid GetUserId()
        {
            //return User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            return Guid.NewGuid();
        }
        //==================================================================================================
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnswerModel>>> GetAnswers()
        {
            var answers = await _profile.GetUserAnswers(GetUserId());

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
            var answer = await _profile.GetUserAnswer(id, GetUserId());

            if (answer == null)
            {
                return Content("Not Found");
            }

            return answer;
        }
        //==================================================================================================
    }
}
