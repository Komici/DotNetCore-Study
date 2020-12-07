using JWTDemo.ApiAuthorizePolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWTDemo.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private readonly IConfiguration _configuration;
        private readonly JwtSettingOptions _jwtSettingOptions;
        private readonly PermissionRequirement _requirement;
        public LoginController(ILogger<LoginController> logger, IConfiguration configuration, IOptions<JwtSettingOptions> jwtSettingOptions, PermissionRequirement requirement)
        {
            _logger = logger;
            _configuration = configuration;
            _jwtSettingOptions = jwtSettingOptions.Value;
            _requirement = requirement;
        }

        [HttpPost]
        public IActionResult Post([FromBody]LoginPostModel loginPostModel)
        {
            if (loginPostModel.UserName == "xbh" && loginPostModel.Password == "123456")
            {
                var claims = new[]
                {
                   new Claim(ClaimTypes.Name, loginPostModel.UserName),
                   new Claim(ClaimTypes.Expiration,DateTime.Now.AddDays(7).ToString())
               };

                return Ok(JwtToken.BuildJwtToken(claims, _requirement));
            }

            return BadRequest("用户名密码错误");
        }

        public class LoginPostModel
        {
            public string UserName { get; set; }

            public string Password { get; set; }
        }
    }
}
