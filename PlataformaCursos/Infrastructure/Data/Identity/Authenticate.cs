using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PlataformaCursos.Domain.Authetication;
using PlataformaCursos.Domain.Entities;
using PlataformaCursos.Infrastructure.Data.Context;
using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace PlataformaCursos.Infrastructure.Data.Identity
{
    public class Authenticate : IAuthenticate
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public Authenticate(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<bool> Authenticated(string email, string senha)
        {
            var usuario = await _context.Usuario.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefaultAsync();
            if (usuario == null)
            {
                return false;
            }
           
            using var hmac = new HMACSHA512((usuario.SenhaSalt));

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(senha));

            for (int x = 0; x < computedHash.Length; x++)
            {
                if (computedHash[x] != usuario.SenhaHash[x]) return false;
            }

            return true;
        }

        public (string, DateTime) GenerateToken(int id, string email)
        {
            var claims = new[]
            {
                new Claim("id", id.ToString()),
                new Claim("email", email.ToLower()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwt:secretKey"]!));

            var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.Now.AddHours(6);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["jwt:issuer"],
                audience: _configuration["jwt:audience"],
                claims: claims,
                expires: expiration,
                signingCredentials: credentials
            );

            return (new JwtSecurityTokenHandler().WriteToken(token), expiration);
        }

        public async Task<TblUsuario> GetUserByEmail(string email)
        {
            var query = await _context.Usuario.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefaultAsync();
            return query!;
        }

        public async Task<bool> UserExists(string email)
        {
            var usuario = await _context.Usuario.Where(x => x.Email.ToLower() == email.ToLower() && x.Ativo == true).FirstOrDefaultAsync();
            if (usuario == null)
            {
                return false;
            }

            return true;
        }
    }
}
