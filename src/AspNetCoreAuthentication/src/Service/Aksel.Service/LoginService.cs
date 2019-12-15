using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Aksel.Repository.Entities;
using Aksel.Models.Models.Authorization;
using Aksel.Repository.Contracts;
using Aksel.Service.Contracts;
using EnsureDotnet;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Aksel.Service
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _userRepository;
        private readonly AudienceModel _audienceModel;

        public LoginService(
            IUserRepository userRepository,
            IOptions<AudienceModel> audienceModel)
        {
            _userRepository = userRepository;
            _audienceModel = audienceModel.Value;
        }

        public async Task<string> LoginAsync(string email, string password)
        {
            Ensure.ArgumentNotNullOrEmptyString(email, nameof(email));
            Ensure.ArgumentNotNullOrEmptyString(password, nameof(password));

            UserEntity userEntity = await _userRepository.GetAsync(email);

            if (userEntity == null)
            {
                return null;
            }

            bool isPasswordMatched = BCrypt.Net.BCrypt.Verify(password, userEntity.Password);
            
            if (!isPasswordMatched)
            {
                return null;
            }

            // TO-DO : GET Roles

            string role = string.Empty;

            return CreateToken(userEntity.Id, role);
        }

        private string CreateToken(long userId, string role)
        {
            // authentication successful so generate jwt token
            byte[] key = Encoding.ASCII.GetBytes(_audienceModel.Secret);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _audienceModel.Issuer,
                Audience = _audienceModel.Aud,
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, userId.ToString()),
                    new Claim(ClaimTypes.Role, role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken securityToken = tokenHandler.CreateToken(tokenDescriptor);
            string token = tokenHandler.WriteToken(securityToken);

            return token;
        }
    }
}