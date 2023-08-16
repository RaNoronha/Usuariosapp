using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Domain.Entities;
using UsuariosApp.Domain.Helpers;
using UsuariosApp.Domain.Interfaces.Security;

namespace UsuariosApp.Security.Services
{
    public class TokenSecurity : ITokenSecuity
    {
        public string GerarToken(Usuario usuario)
        {
            var chaveSeguranca = "06E5AFC2479F44309C5990496F7A5D60";
            var expiracaoChave = 60;
            

            
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(chaveSeguranca);

            //criando o conteúdo do token
            var tokenDescriptor = new SecurityTokenDescriptor();

            tokenDescriptor.Subject = new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Name, usuario.Email) });
            tokenDescriptor.Expires = DateTime.UtcNow.AddMinutes(expiracaoChave);
            tokenDescriptor.SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);
           
            

            //retornando o token
            var accessToken = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(accessToken);


        }
    }
}
