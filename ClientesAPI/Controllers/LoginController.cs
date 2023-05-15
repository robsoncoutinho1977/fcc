using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;

namespace Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration config;
        public LoginController(IConfiguration _config)
        {
            config = _config;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> Get()
        {
            return Ok("API Online");
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<TokenModel>> Post([FromBody] LoginModel model)
        {
            try
            {
                TokenModel _token = new TokenModel();
                BLL.Login bllLogin = new BLL.Login();
                _token = bllLogin.Gerar(model.login, model.senha);
                return _token;
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
