using Measurement.Entities;
using Measurement.Exceptions;
using Measurement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Measurement.Services
{
    public class UserService
    {
        private readonly DataContext _context;
        private readonly IPasswordHasher<Users> _passwordHasher;
        private readonly AuthenticationSettings _authSettings;

        public UserService(DataContext context,IPasswordHasher<Users> hasher, AuthenticationSettings authSett)
        {
            _context = context;
            _passwordHasher = hasher;
            _authSettings = authSett;
        }


        public bool ReqisterUser(RegisterUserDto dto)
        {
            try
            {
                var newUser = new Users()
                {
                    Email = dto.Email,
                    Username = dto.Username,
                    RoleId = dto.RoleId,
                    MonitorType = dto.MonitorType.ToString(),

                };
                var hashedPassword = _passwordHasher.HashPassword(newUser,dto.Password);
                newUser.Password = hashedPassword;
                _context.Users.Add(newUser);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }

        }

        public string GenerateJwt(LoginDto dto)
        {
            var user = _context.Users
                .FirstOrDefault(u => u.Email == dto.Email);

            if (user is null)
                throw new BadRequestException("Invalid username or password");

            var result = _passwordHasher.VerifyHashedPassword(user,user.Password,dto.Password);

            if (result == PasswordVerificationResult.Failed)
                throw new BadRequestException("Invalid username or password");

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                new Claim(ClaimTypes.Name,user.Username.ToString()),
                new Claim(ClaimTypes.Role,$"{user.Role.Name}"),
                new Claim("MonitoringType",user.MonitorType.ToString())
            };


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authSettings.JwtKey));

            var cred = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            var expiersM = DateTime.Now.AddDays(_authSettings.JwtExpireDays);

            var token = new JwtSecurityToken(_authSettings.JwtIssuer,
                _authSettings.JwtIssuer,
                claims,
                expires:expiersM,
                signingCredentials: cred);

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }




    }
}
