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
                  
                ICollection<Group> list = await groupDAO.GetAllAsync();

                ICollection<object> result = new List<object>();

                foreach(Group group in list)
                {
                    ICollection<User> users = await userDAO.ByGroupIdAsync(group.Id);
                    result.Add(new { group = group, count = users.Count }); 

                }
           

                return Ok(result);   
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

                ICollection<object> result = new List<object>();

                foreach (Group g in list)
                {
                    ICollection<User> users = await userDAO.ByGroupIdAsync(g.Id);
                    result.Add(new { group = g, count = users.Count });

                }
                
                return Ok(result);
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
