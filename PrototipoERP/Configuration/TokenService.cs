using System;
using System.Text;
using System.Security.Claims;
using PrototipoERP.Entidades;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace PrototipoERP.Configuration
{
    public static class TokenService
    {
        public static TokenInfo GenerateToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.Nome),
                }),
                Expires = DateTime.Now.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            tokenHandler.SetDefaultTimesOnTokenCreation = false;

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new TokenInfo
            {
                UsuarioId = usuario.Id,
                UsuarioNome = usuario.Nome,
                Token = tokenHandler.WriteToken(token),
                DataExpiracao = tokenDescriptor.Expires
            }; 
        }
    }
}
