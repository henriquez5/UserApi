using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserApi.Service;
using UserApi.Service.Interface;
using UserApi.ViewModel;

namespace UserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        public IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginModel userLoginModel)
        {
            try
            {
                var token = await _userService.Login(userLoginModel);

                if(token == null)
                {
                    throw new Exception("Token Invalido");
                }

                return Ok(token);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
