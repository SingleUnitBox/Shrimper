using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShrimperInfrastructure.Commands;
using ShrimperInfrastructure.Commands.Users;
using ShrimperInfrastructure.Dto;
using ShrimperInfrastructure.Services;

namespace ShrimperApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly ITokenService _tokenService;

        //private readonly ICommandHandler<LoginUser> _commandHandler;

        public UserController(IUserService userService,
            ICommandDispatcher commandDispatcher,
            ITokenService tokenService
            //ICommandHandler<LoginUser> commandHandler
            )
        {
            _userService = userService;
            _commandDispatcher = commandDispatcher;
            _tokenService = tokenService;
            //_commandHandler = commandHandler;
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet]
        [Route("{email}")]
        public UserDto Get(string email)
            => _userService.Get(email);

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] LoginUser loginUserCommand)
        {
            loginUserCommand.TokenId = Guid.NewGuid();
            await _commandDispatcher.DispatchAsync(loginUserCommand);
            var token = _tokenService.Get(loginUserCommand.TokenId);

            return Json(token.Token);
        }
    }
}
