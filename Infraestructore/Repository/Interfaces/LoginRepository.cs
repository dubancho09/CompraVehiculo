using Core.Dto;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infraestructure.Repository.Interfaces
{
    public class LoginRepository : ILoginRepository
    {
        private IConfiguration _configuration;
        private Utilities.Utilities _utilities;
        private readonly ApplicationDbContext _db;
        public LoginRepository(ApplicationDbContext db, IConfiguration config, Utilities.Utilities utilities)
        {
            _db = db;
            _configuration = config;
            _utilities = utilities;
        }
        public async Task<string> Login(UserLogin user)
        {
            string password = user.pass;
            string passwordHash = _utilities.encriptarPassword(password);


            //Verificar si los datos son correctos
            var userExist = await _db.User.FirstOrDefaultAsync(u=>u.userName.ToLower()==user.userName.ToLower()
                            && u.password==passwordHash);

            if (userExist != null)
            {
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("NameUser", userExist.userName),
                    new Claim("Id", userExist.id.ToString()),
                    new Claim("Email", userExist.email),
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


                var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);


                var tokenUser = new JwtSecurityTokenHandler().WriteToken(token);

                return tokenUser;
            }


            return "Credenciales Invalidas";

        }
    }
}
