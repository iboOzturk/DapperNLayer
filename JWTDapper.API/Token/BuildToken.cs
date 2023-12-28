using Dapper;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace JWTDapper.API.Token
{
    public class BuildToken
    {
        protected readonly DALContext _context;

        public BuildToken()
        {
            _context = new DALContext();

        }   

        public async Task<string> AuthenticateUserAsync(string username, string password)
        {
            string query = "SELECT * FROM Users WHERE Username = @Username AND PasswordHash = @PasswordHash";
            using (var connection = _context.CreateConnection())
            {
                var user = await connection.QueryFirstOrDefaultAsync<User>(query,
                    new { Username = username, PasswordHash = HashPassword(password) }
                );
                if (user == null)
                {
                    return "Kullanıcı bulunamadı";
                }

                var token = GenerateJwtToken(user.UserId, user.UserName);

                return token;
            }
        }
        private string GenerateJwtToken(int userId, string username)
        {

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("dapperormnlayerarchitectureproject");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(ClaimTypes.Name, username)
            }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
    }
}
