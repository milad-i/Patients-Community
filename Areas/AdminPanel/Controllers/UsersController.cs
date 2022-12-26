using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PatientsCommunity.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace PatientsCommunity.Controllers
{
    [Route("api/Areas/AdminPanel/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IAdmin _admin;
        private readonly UserManager<IdentityUser> _userManager;

        public UsersController(IAdmin admin ,UserManager<IdentityUser> userManager)
        {
            _admin = admin;
            _userManager= userManager;
        }
        //==================================================================================================
        [HttpGet]
        [SwaggerOperation(summary: "Tip: Use [search] queryString for searching and [page] queryString to pagination.")]
        public async Task<ActionResult<IEnumerable<IdentityUser>>> GetUsers(int page = 1, string? search = null)
        {
            //Get Users
            var users = _userManager.Users.ToList();

            //Search
            if (!string.IsNullOrEmpty(search))
            {
                 users = users.Where(u => u.UserName.Contains(search)).ToList();
            }

            //Pagination
            int pageLimit = 30;
            users = users.Skip((page * pageLimit) - pageLimit).Take(pageLimit).ToList();

            if (!users.Any())
            {
                return Content("No Item Found");
            }
            return users;
        }
        //==================================================================================================
        [HttpGet("{id}")]
        public async Task<ActionResult<IdentityUser>> GetUser(Guid id)
        {
            var user = await _admin.GetUserById(id);

            if (user == null)
            {
                return Content("Not Found");
            }

            return user;
        }
        //==================================================================================================
    }
}
