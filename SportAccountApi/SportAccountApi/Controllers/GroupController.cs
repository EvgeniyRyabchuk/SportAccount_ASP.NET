using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportAccountApi.DAL;
using SportAccountApi.DTO.Group;
using SportAccountApi.Mapper;
using SportAccountApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportAccountApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : Controller
    {
        private readonly UserDAO userDAO;
        private readonly GroupDAO groupDAO;
        private readonly IHttpContextAccessor httpContextAccessor;
        public GroupController(DataContext dataContext, IHttpContextAccessor httpContextAccessor)
        {
            userDAO = new UserDAO(dataContext);
            groupDAO = new GroupDAO(dataContext);
            this.httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            try
            {
                var list = await groupDAO.GetAllAsync();

                return Ok(list); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{groupId}")]
        public async Task<ActionResult<Group>> ShowAsync(int groupId)
        {
            Group group = await groupDAO.FindByIdAsync(groupId);
            ICollection<User> users = await userDAO.ByGroupIdAsync(groupId);
            int count = 0; 
            if (group.Users != null)
                count = group.Users.Count; 

            return Ok(new { group, count, users }); 
        }


        [HttpPost]
        public async Task<IActionResult> StoreAsync(CreateGroupDTO createGroupDTO)
        {
            try
            {
                Group group = GroupMapper.FromCreateModel(createGroupDTO);

                var list = await groupDAO.AddAsync(group); 

                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{groupId}/members")]
        public async Task<IActionResult> GetAllMembersAsync(int groupId)
        {
            Group group = await groupDAO.FindByIdAsync(groupId);
            ICollection<User> list = await userDAO.ByGroupIdAsync(groupId); 


            if (list == null) list = new List<User>();  
            
            return Ok(list);
        }
    }
}
