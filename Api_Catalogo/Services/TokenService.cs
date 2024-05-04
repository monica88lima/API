using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TokenService : ITokenService
    {
        public JwtSecurityToken GenerateAcessToken(IEnumerable<Claim> claims, IConfiguration _config)
        {
            //toda vez que precisa gerar um novo token
            //obtendo a chave secreta do appsetting e verificar se der erro avisa
            var key = _config.GetSection("JWT").GetValue<string>("SecretKey") ?? throw new InvalidOperationException("Chave Inválida");

            //converter em array de bytes
            var privateKey = Encoding.UTF8.GetBytes(key);

            //criar as credenciais pra assinar o token, passando a chave como array
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(privateKey),
                                SecurityAlgorithms.HmacSha256Signature);

            //descrever as informações que usar no token
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _config.GetSection("JWT").GetValue<string>("ValidIssuer"),
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(_config.GetSection("JWT").GetValue<double>("TokenValidityInMinutes")),
                Audience = _config.GetSection("JWT").GetValue<string>("ValidAudience"),
                SigningCredentials = signingCredentials
            };
            //manipular do token, cria e valida
            var tokenHandler = new JwtSecurityTokenHandler();
            //cria e retorna o token
            var token = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);

            return token;
        }

        public string GenerateRefreshToken()
        {
            //token de atualização, novo token de acesso 
            //com isso o usuario nao precisa logar novamente
            //array de bytes aleatorios
           var secureRandomBytes = new byte[128];
            //gerardor de numeros aleatorios
            using var randomNumberGenerator = RandomNumberGenerator.Create();
            //preenchendo com bytes aleatorios
            randomNumberGenerator.GetBytes(secureRandomBytes);
            //converte os bytes em base64
            var refreshToken = Convert.ToBase64String(secureRandomBytes);
            return refreshToken;
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token, IConfiguration _config)
        {
            //usado ra validar o token que expirou e obtem as claims principais, validado com o token que expirou

            var secretKey = _config["JWT:SecretKey"] ?? throw new InvalidOperationException("Invalid key");
            //parametros de validação para o jwt expirado
            var tokenValidationParameter = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(secretKey)),
                ValidateLifetime = false,
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameter, out SecurityToken securityToken);

            if(securityToken is not JwtSecurityToken jwtSecurityToken ||
                !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,StringComparison.InvariantCultureIgnoreCase)) 
            {
                throw new SecurityTokenException("Invalid Token");
            }
            return principal;

        }
    }
}
