using Dto;
using Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Catalogo_API_v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthController(ITokenService tokenService, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _tokenService = tokenService;
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }
        [HttpPost]
        [Route("register")]
        public async  Task<IActionResult> Register([FromBody]RegistoUsuarioDTO model)
        {
            var exist = await _userManager.FindByNameAsync(model.UserName!);
            if (exist != null) {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ResponseDTO { Status = "Error ", Message = "User already exists!" });
            }
            ApplicationUser user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.UserName,
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if(!result.Succeeded) {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                             new ResponseDTO { Status = "Error ", Message = "User already exists!" });
            }
            return Ok(new ResponseDTO { Status = "Sucess ", Message = "User created sucessfully!" });
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login([FromBody]LoginModelDTO model)
        {
            //buscar  o usuario pelo nome
            //!certeza que nao e nulo
            var user = await _userManager.FindByNameAsync(model.UserName);
            var senha = await _userManager.CheckPasswordAsync(user, model.Password!);
            if (user != null && senha ) 
            { 
                var userRoles = await _userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName!),
                    new Claim (ClaimTypes.Email, user.Email),
                    new Claim (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };
                foreach (var userRole in userRoles) 
                { 
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole )); 
                
                }
                var token = _tokenService.GenerateAcessToken(authClaims,
                    _configuration);
                var refrestToken = _tokenService.GenerateRefreshToken();

                //fica na variavel de saida
                _ = int.TryParse(_configuration["JWT:RefreshTokenValidityInMinutes"],
                    out int refrestTokenValidityInMinutes );

                user.RefreshTokenExpiryTime = DateTime.Now.AddMinutes(refrestTokenValidityInMinutes);
                user.RefreshToken = refrestToken;
                await _userManager.UpdateAsync(user);
                return Ok(new
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    RefreshToken = refrestToken,
                    Expiration = token.ValidTo
                });

            }
            return Unauthorized();
        }
        [HttpPost]
        [Route("refresh-token")]
        public async Task<IActionResult> RefreshToken (TokenModel model)
        {
            if(model is null)
            {
                return BadRequest("Invalid client request");
            }
            string? acessToken = model.AcessToken?? throw new ArgumentNullException(nameof(model));
            string? refreshToken = model.RefreshToken ?? throw new ArgumentNullException(nameof(model));
            var principal = _tokenService.GetPrincipalFromExpiredToken(acessToken!, _configuration);
            if(principal == null)
            {
                return BadRequest("Invalid Acess Token/refresh token");
            }
            string username = principal.Identity.Name;
            var user = await _userManager.FindByNameAsync(username);
            if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
            {
                return BadRequest("Invalid Acess Token/refresh token");
            }
            var newAcessToken = _tokenService.GenerateAcessToken(principal.Claims.ToList(),_configuration);
            var newRefreshToken = _tokenService.GenerateRefreshToken;
            await _userManager.UpdateAsync(user);
            return new ObjectResult(new
            {
                acessToken = new JwtSecurityTokenHandler().WriteToken(newAcessToken),
                refreshToken = newRefreshToken
            });

        }
        [Authorize]
        [HttpPost]
        [Route("revoke/{username}")]
        public async Task<IActionResult>Revoke (string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            if(user == null) { return BadRequest("Usuario Inválido!"); }
            user.RefreshToken = null;
            await _userManager.UpdateAsync(user);
            return NoContent();
        }

    }
}
