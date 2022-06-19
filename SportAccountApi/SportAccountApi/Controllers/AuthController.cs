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
        private readonly RefreshTokenDAO refreshTokenDAO;

        private readonly IConfiguration _confiuration;
        private readonly IHttpContextAccessor httpContextAccessor; 
        //public static User user = new User();
        //private UserManager<User> _userManager;

        public AuthController(DataContext dataContext, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            userDAO = new UserDAO(dataContext);
            roleDAO = new RoleDAO(dataContext);
            _confiuration = configuration;
            refreshTokenDAO = new RefreshTokenDAO(dataContext); 
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
        public async Task<ActionResult<User>> Login(LogInDTO request)
        {
            User user = await userDAO.ByLoginAsync(request.login);
            if (user == null)
                return BadRequest("User not exist");

            if (!_SL.VerifyPasswordHash(request.password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Wrong password.");
            }


            string token = CreateToken(user);

            var refreshToken = GenerateRefreshToken();

            await SetRefreshToken(refreshToken, user);

            await SaveRefreshTokenToDbAsync(refreshToken, user); 

            return Ok(token); 
        }
        
        private async Task<ICollection<_RefreshToken>> SaveRefreshTokenToDbAsync(RefreshToken refreshToken, User user)
        {
            _RefreshToken rf = RefreshTokenMapper.FromRefreshTokenClass(refreshToken, user);
            var list = await refreshTokenDAO.AddAsync(rf);
            return list; 
        }

        
        [HttpPost("refresh-token"), Authorize]
        public async Task<ActionResult<string>> RefreshToken() 
        {
            var refreshToken = Request.Cookies["refreshToken"];

            if(refreshToken == null)
            {
                return Unauthorized("No Refresh Token.");
            }

            // get refresh token from db 
            _RefreshToken rf = await refreshTokenDAO.FindByTokenAsync(refreshToken);
            //get current user 
            User user = await _SL.GetCurrentUser(userDAO, httpContextAccessor);
            // if refresh token belongs current user 
            if (rf.UserId != user.Id) 
            {
                return Unauthorized("Invalid Refresh Token For Current User");
            }
            
            if (!rf.RefreshToken.Equals(refreshToken))
            {
                return Unauthorized("Invalid Refresh Token."); 
            }
            else if (rf.Expired_At < DateTime.Now)
            {
                return Unauthorized("Token expired."); 
            }

            string token = CreateToken(user);
            var newRefreshToken = GenerateRefreshToken(); 
            await SetRefreshToken(newRefreshToken, user);
            await SaveRefreshTokenToDbAsync(newRefreshToken, user); 
            return Ok(token);
        }

        //TODO: logout 
        //TODO: json responce 
        [HttpPost("logout"), Authorize]
        public async Task<ActionResult> Logout()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            
            await refreshTokenDAO.DeleteByTokenAsync(refreshToken); 

            Response.Cookies.Delete("refreshToken");
            
            return Ok("user is logged out");
            #region currentUSer 
            /* 
                //var user = await _userManager.GetUserAsync(User); 

                //var userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                //string userId = HttpContext.User.FindFirstValue("id"); 

            
        //public User GetCurrentUser()
        //{
        //    ClaimsPrincipal currentUser = User;
        //    var user = _userManager.GetUserAsync(User).Result;
        //    return user;
        //}
            */
            #endregion
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
                Expires = DateTime.Now.AddMinutes(1),
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

            await userDAO.UpdateAsync(user); 
        }
        
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
                expires: DateTime.Now.AddMinutes(1), 
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

    }
}
