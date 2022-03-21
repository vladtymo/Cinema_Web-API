using Cinema.Core.DTO;
using Cinema.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] RegisterUserDTO data)
        {
            await accountService.RegisterAsync(data);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthorizationDTO>> Login([FromBody] UserLoginDTO data)
        {
            return await accountService.LoginAsync(data.Email, data.Password);
        }
    }
}
