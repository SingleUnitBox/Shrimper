using Microsoft.AspNetCore.Mvc;
using ShrimperInfrastructure.Dto;
using ShrimperInfrastructure.Services;

namespace ShrimperApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        [Route("{email}")]
        public UserDto Get(string email)
            => _userService.Get(email);
    }
}
