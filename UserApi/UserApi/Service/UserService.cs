using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserApi.Context;
using UserApi.Model;
using UserApi.Service.Interface;
using UserApi.ViewModel;

namespace UserApi.Service
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _context;

        public UserService(IConfiguration configuration, AppDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public async Task<string> Login(UserLoginModel userLoginModel)
        {

            var user = await GetUsuario(userLoginModel.Email, userLoginModel.Password);

            if (user != null)
            {
                //cria claims baseado nas informações do usuário
                var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("Id", user.ID_USER.ToString()),
                    new Claim("Email", userLoginModel.Email),
                    new Claim("Login", userLoginModel.Password),
                   };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddDays(1),
                    signingCredentials: signIn
                    );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            else
            {
                return "";
            }
        }

        private async Task<Users> GetUsuario(string email, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.EMAIL == email && u.PASSWORD_USER == password);
        }
    }
}
