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
using Microsoft.AspNetCore.Http;
using SportAccountApi.SL;
using SportAccountApi.DTO.Group;

namespace SportAccountApi.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    
    public class UserController : ControllerBase 
    {
        private readonly UserDAO userDAO;
        private readonly GroupDAO groupDAO;
        private readonly RoleDAO roleDAO;
        private readonly IHttpContextAccessor httpContextAccessor;
        public UserController(DataContext dataContext, IHttpContextAccessor httpContextAccessor)
        {
            userDAO = new UserDAO(dataContext);
            roleDAO = new RoleDAO(dataContext);
            groupDAO = new GroupDAO(dataContext);
            this.httpContextAccessor = httpContextAccessor; 
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

        [HttpGet("{id}")]
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


        [HttpPost("/{userId}/group/{groupId}")]
        public async Task<ActionResult<User>> AddUserToGroup(int userId, int groupId)
        {
            try
            {
                User currentUser = await _SL.GetCurrentUser(userDAO, httpContextAccessor);
                //TODO: temp code for debug 
                if (currentUser == null) currentUser = await userDAO.ByIdAsync(1);
                if (currentUser.Id != userId) return BadRequest("Page not found. 404"); 

                User user = await userDAO.ByIdAsync(userId);
                Group group = await groupDAO.FindByIdAsync(groupId); 

                var list = await userDAO.AddGroupAsync(user, group);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPut]
        public async Task<ActionResult<User>> Update(UpdateUserDTO request)
        {
            try
            {
                User currentUser = await _SL.GetCurrentUser(userDAO, httpContextAccessor);
                //TODO: temp code for debug 
                if (currentUser == null) currentUser = await userDAO.ByIdAsync(1); 
                if(currentUser.Id != request.Id)
                {
                    return BadRequest("User does not found"); 
                }

                User UserFromRequest = UserMapper.FromUpdateModel(request); 

                var list = await userDAO.UpdateAsync(UserFromRequest); 

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

