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
using SportAccountApi.Mapper;
using Microsoft.AspNetCore.Authorization;

namespace SportAccountApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class UserController : ControllerBase 
    {
        private readonly UserDAO userDAO;
        private readonly RoleDAO roleDAO; 

        public UserController(DataContext dataContext)
        {
            userDAO = new UserDAO(dataContext);
            roleDAO = new RoleDAO(dataContext); 
        }

        [HttpGet, Authorize]
    
        public async Task<ActionResult<User>> Index()
        {
            try
            {
                return Ok(await userDAO.GetAllAsync()); 
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message); 
            }
     
        }

        [HttpGet("{id}"), Authorize]

        public async Task<ActionResult<User>> Show(int id)
        {
            try
            {
                User user = await userDAO.FindByIdAsync(id); 
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
            try
            {
                // check out if role exist 
                Role role = await roleDAO.FindByIdAsync(request.RoleId);

                User userMapped = UserMapper.FromCreateModel(request);

                var list = await userDAO.AddAsync(userMapped);

                return Ok(list);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message); 
            }
          
        }

        [HttpPut]
        public async Task<ActionResult<User>> Update(CreateUserDTO request)
        {
            try
            {
                Role role = await roleDAO.FindByIdAsync(request.RoleId);

                User userMapped = UserMapper.FromCreateModel(request);

                //var user = await 
                var list = await userDAO.UpdateAsync(userMapped);

                return Ok(list);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message); 
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Destroy(int id)
        {
            try
            {
                var list = await userDAO.DeleteAsync(id);
                return Ok(list);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

