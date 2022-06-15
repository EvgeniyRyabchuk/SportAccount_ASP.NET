using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportAccountApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportAccountApi.DTO.User; 

namespace SportAccountApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context; 

        public UserController(DataContext dataContext)
        {
            _context = dataContext; 
        }
        
        [HttpGet]
        public async Task<ActionResult<User>> Index()
        {
            return Ok(await _context.Users.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Show(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return BadRequest("User does't exist"); 
            
            return Ok(user); 
        }

        [HttpPost]
        public async Task<ActionResult<User>> Store(CreateUserDTO request)
        {
            var user = new User()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                MiddletName = request.MiddletName,
                BirthDate = request.BirthDate
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            
            return Ok(await _context.Users.ToListAsync()); 
        }

        [HttpPut]
        public async Task<ActionResult<User>> Update(User request)
        {
            var user = await _context.Users.FindAsync(request.Id);
            if (user == null)
                return BadRequest("User does't exist");
            
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.MiddletName = request.MiddletName;
            user.BirthDate = request.BirthDate;
            


            await _context.SaveChangesAsync();

            return Ok(await _context.Users.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Destroy(int id) 
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return BadRequest("User does't exist");

            _context.Users.Remove(user);  
            await _context.SaveChangesAsync(); 

            return Ok(await _context.Users.ToListAsync());
        }
    }
}
