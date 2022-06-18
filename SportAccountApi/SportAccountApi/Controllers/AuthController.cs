using JwtWebApiTutorial;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SportAccountApi.DAL;
using SportAccountApi.DTO.User;
using SportAccountApi.Mapper;
using SportAccountApi.Models;
using SportAccountApi.SL;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace SportAccountApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly UserDAO userDAO;
        private readonly RoleDAO roleDAO;
        private readonly IConfiguration _confiuration;
        private readonly IHttpContextAccessor httpContextAccessor; 
        //public static User user = new User();
        //private UserManager<User> _userManager;

        public AuthController(DataContext dataContext, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            userDAO = new UserDAO(dataContext);
            roleDAO = new RoleDAO(dataContext);
            _confiuration = configuration;
            //_userManager = userManager;

            this.httpContextAccessor = httpContextAccessor; 

        }
        // 14: 175 177

        [HttpPost("register")]
        public async Task<ActionResult<User>> Registrate(CreateUserDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            //if (registerRequest.Password != registerRequest.ConfirmPassword)
            //{
            //    return BadRequest(new ErrorResponse("Password does not match confirm password."));
            //}

            User userExist = await userDAO.ByLoginAsync(request.Login);
            if (userExist == null)
            {
                User user = UserMapper.FromCreateModel(request); 

                await userDAO.AddAsync(user);
                
                return Ok(user);
            }
            else
            {
                return BadRequest("Such user already exist");
            }

        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> Login(CreateUserDTO request)
        {
            User user = await userDAO.ByLoginAsync(request.Login);
            if (user == null)
                return BadRequest("User not exist");

            if (!_SL.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Wrong password.");
            }


            string token = CreateToken(user);

            var refreshToken = GenerateRefreshToken();
            await SetRefreshToken(refreshToken, user); 
            
            return Ok(token); 
        }

        

        [HttpPost("refresh-token"), Authorize]
        public async Task<ActionResult<string>> RefreshToken() 
        {
            User user = await _SL.GetCurrentUser(userDAO, httpContextAccessor);
            var refreshToken = Request.Cookies["refreshToken"];
            
            if (!user.RefreshToken.Equals(refreshToken))
            {
                return Unauthorized("Invalid Refresh Token.");
            }
            else if (user.TokenExpires < DateTime.Now)
            {
                return Unauthorized("Token expired."); 
            }

            string token = CreateToken(user);
            var newRefreshToken = GenerateRefreshToken();
            await SetRefreshToken(newRefreshToken, user);

            return Ok(token);
        }

        //TODO: logout 
        //TODO: json responce 
        [HttpPost("logout"), Authorize]
        public async Task<ActionResult> Logout()
        {
            User current = await _SL.GetCurrentUser(userDAO, httpContextAccessor);  
            current.TokenExpires = DateTime.Now;
            current.RefreshToken = null;

            await userDAO.UpdateAsync(current); 
            return Ok("user log out");
            //var user = await _userManager.GetUserAsync(User);

            //var userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            //string userId = HttpContext.User.FindFirstValue("id");

        }


        private RefreshToken GenerateRefreshToken()
        {
            byte[] random = new Byte[64];
            //RNGCryptoServiceProvider is an implementation of a random number generator.
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(random); // The array is now filled with cryptographically strong random bytes.
           
            var refreshToken = new RefreshToken
            {
                Token = Convert.ToBase64String(random),
                Expires = DateTime.Now.AddDays(7),
                Created = DateTime.Now
            };

            return refreshToken;
        }

        private async Task SetRefreshToken(RefreshToken newRefreshToken, User user)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = newRefreshToken.Expires
            };
            Response.Cookies.Append("refreshToken", newRefreshToken.Token, cookieOptions);

            user.RefreshToken = newRefreshToken.Token;
            user.TokenCreated = newRefreshToken.Created;
            user.TokenExpires = newRefreshToken.Expires;
            await userDAO.UpdateAsync(user); 
        }


        //public User GetCurrentUser()
        //{
        //    ClaimsPrincipal currentUser = User;
        //    var user = _userManager.GetUserAsync(User).Result;
        //    return user;
        //}

        
        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.FirstName + " " + user.LastName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role.Name)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _confiuration.GetSection("AppSettings:Token").Value));
            
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1), 
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

    }
}
