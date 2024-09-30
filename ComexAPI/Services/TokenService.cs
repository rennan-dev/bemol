using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using WebApi.Models;

namespace WebApi.Services;
public class TokenService {

    public string GenerateToken(Admin admin) {

        Claim[] claims = new Claim[] {

            new Claim("Username", admin.UserName),
            new Claim("Id", admin.Id)
        };

        var chave = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes("2323R02N902FI03908N038J31093N10ND2049NASIDPOM0J923")
            );

        var signingCredentials = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            expires: DateTime.Now.AddMinutes(10),
            claims: claims,
            signingCredentials: signingCredentials
            );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
