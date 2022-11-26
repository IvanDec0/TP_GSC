using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TP_Back.Configuration;
using TP_Back.DataAccess;
using TP_Back.DataAccess.UnitOfWork;
using TP_Back.Dto;
using TP_Back.Entities;
using TP_Back.Migrations;
using TP_Back.Models;

namespace TP_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        
        private readonly IConfiguration configuration;
        private readonly IUnitOfWork uow;

        public UsersController(IConfiguration configuration, IUnitOfWork uow)
        {
            this.configuration = configuration;
            this.uow = uow;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(LoginUserDTO request)
        {
            var user = new User();
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            user.UserName = request.UserName;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await uow.UsersRepo.InsertAsync(user);
            await uow.SaveAsync();
            
            return Ok();
        }

        [HttpPost("login")]
        public ActionResult<string> Login(LoginUserDTO request)
        {
            if (request != null && request.UserName != null && request.Password != null)
            {
                var user = uow.UsersRepo.GetOneString(request.UserName);
                if (user.UserName != request.UserName)
                {
                    return BadRequest("User does not exist");

                }

                if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
                {
                    return BadRequest("Incorrect password");
                }



                string token = CreateToken(user);
                return Ok(token);
            }
            return BadRequest("Null data");
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
               new Claim(ClaimTypes.Name, user.UserName),
               new Claim(ClaimTypes.Role, "Admin"),
            };
            
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                configuration.GetSection("Key").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);



            var token = new JwtSecurityToken(
            claims: claims,
                issuer: configuration.GetSection("JWT:Issuer").Value,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
                );

            
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);


            return jwt;
        }




        
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA256())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }


       
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA256(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash); 
            }
        }
        }
        
}