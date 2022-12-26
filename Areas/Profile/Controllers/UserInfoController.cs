using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PatientsCommunity.Interfaces;

namespace PatientsCommunity.Areas.Profile.Controllers
{
    [Route("api/Areas/Profile/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private readonly IProfile _profile;
        private readonly UserManager<IdentityUser> _userManager;

        public UserInfoController(IProfile profile, UserManager<IdentityUser> userManager)
        {
            _profile = profile;
            _userManager = userManager;
        }
        //==================================================================================================
        private Guid GetUserId()
        {
            //return User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            return Guid.NewGuid();
        }
        //==================================================================================================
        [HttpGet]
        public async Task<IdentityUser> UserInfo()
        {
            return await _userManager.GetUserAsync(User);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUserInfo(Guid id)
        {
            return Content("Error");
        }
    }
}
