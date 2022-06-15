using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportAccountApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportAccountApi.DTO.User;
using System.Net;
using System.Web;
using System.Net.Http;
using FilmsStorage.DAL;
using SportAccountApi.DAL;

namespace SportAccountApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase 
    {
        private readonly UserDAO userDTO;

        public UserController(DataContext dataContext)
        {
            userDTO = new UserDAO(dataContext); 
        }

        [HttpGet]
        public async Task<ActionResult<User>> Index()
        {
            return Ok(await userDTO.GetAllAsync());  
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Show(int id)
        {
            try
            {
                User user = await userDTO.FindByIdAsync(id); 
                return Ok(user);
            }
            catch (Exception ex)
            {
                return NotFound();
                //return BadRequest(ex.Message);

            }
        }



        [HttpPost]
        public async Task<ActionResult<User>> Store(CreateUserDTO request)
        {
            var userMapped = new User()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                MiddletName = request.MiddletName, 
                BirthDate = request.BirthDate,
                RoleId = request.RoleID
            };

            var list = await userDTO.AddAsync(userMapped); 
            return Ok(list);
        }

        [HttpPut]
        public async Task<ActionResult<User>> Update(CreateUserDTO request)
        {
            var userMapped = new User()
            {
                Id = request.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                MiddletName = request.MiddletName,
                BirthDate = request.BirthDate,
                RoleId = request.RoleID
            };

            //var user = await 
            var list = await userDTO.UpdateAsync(userMapped); 

            return Ok(list); 
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Destroy(int id)
        {
            var list = await userDTO.DeleteAsync(id); 
            return Ok(list);
        }
    }
}

