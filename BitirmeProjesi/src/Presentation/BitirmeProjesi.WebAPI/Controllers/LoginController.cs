using BitirmeProjesi.Application.Dto;
using BitirmeProjesi.Domain.Entities;
using BitirmeProjesi.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BitirmeProjesi.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        // Register, Login ve authenticate işlemleri
        private UserManager<User> _userManager;
        private RoleManager<ApplicationRole> _roleManager;
        //private readonly IConfiguration _configuration;
        private readonly JwtBearerOptions jwtOpts;
        private readonly IJWTManagerRepository _jWTManager;

        public LoginController(UserManager<User> userManager, RoleManager<ApplicationRole> roleManager, IJWTManagerRepository jWTManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            this._jWTManager = jWTManager;
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate(User usersdata)
        {//giriş yapan kullanıcı buraya name ve password ile istek atar ve doğrulanmış olur
            var token = _jWTManager.Authenticate(usersdata);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
        [Route("User")]
        [HttpPost]
        public async Task<ActionResult> UserCreate([FromBody] UserCreateViewModel model)
        {// yeni kullanıcı kaydı
            if (ModelState.IsValid)
            {
                User user = new User()
                {
                    UserName = model.UserName.Trim(),
                    Email = model.Email.Trim()
                    
                };
                IdentityResult result = await _userManager.CreateAsync(user, model.Password.Trim());
                if(result.Succeeded)
                {
                    if(!_roleManager.RoleExistsAsync("User").Result)
                    {
                        ApplicationRole role = new ApplicationRole()
                        {
                            Name = "User"
                        };
                        IdentityResult roleResult = await _roleManager.CreateAsync(role);
                        if (roleResult.Succeeded)
                        {
                            _userManager.AddToRoleAsync(user, "User").Wait();
                        }
                    }
                    _userManager.AddToRoleAsync(user, "User").Wait();
                    return Ok();
                }
                String errorMessage = String.Empty;
                foreach (var item in result.Errors)
                {
                    errorMessage += item.Description;
                }
                return BadRequest(errorMessage);
            }
            return BadRequest("Check your information. Not in the desired format");

        }
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult> Login([FromBody] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {//Kullanıcı girişi
                User user = await _userManager.FindByNameAsync(model.UserName.Trim());
                if (user != null && await _userManager.CheckPasswordAsync(user, model.Password.Trim()))
                {
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                    };

                    var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySuperSecureKey"));

                    var token = new JwtSecurityToken(

                        expires: DateTime.UtcNow.AddHours(1),
                        claims: claims,
                        signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)
                        );
                    return Ok(
                    //{new
                    //    token = new JwtSecurityTokenHandler().WriteToken(token),
                    //    expiration = token.ValidTo}
                      );
                }
                else
                {
                    return BadRequest("Check your login information, it seems to be incorrect.");
                }
            }
            return BadRequest("Data is not available");
        }




    }
}
