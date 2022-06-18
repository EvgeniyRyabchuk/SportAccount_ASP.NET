using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportAccountApi.DAL;
using SportAccountApi.DTO.Group;
using SportAccountApi.Mapper;
using SportAccountApi.Models;
using System;
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
    }
}
