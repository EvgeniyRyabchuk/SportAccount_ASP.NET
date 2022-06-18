using Microsoft.AspNetCore.Mvc;
using SportAccountApi.DAL;
using SportAccountApi.DTO.Group;
using SportAccountApi.Mapper;
using SportAccountApi.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportAccountApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : Controller
    {

        private readonly RoomDAO roomDAO; 
        
        public RoomController(DataContext dataContext)
        {
            roomDAO = new RoomDAO(dataContext);
        }

        [HttpGet] 
        public async Task<ActionResult<ICollection<Room>>> IndexAsync()
        {
            ICollection<Room> list = await roomDAO.GetAllAsync(); 
            return Ok(list);  
        }

        [HttpGet("{roomId}")]
        public async Task<ActionResult<ICollection<Room>>> ShowAsync(int roomId)
        {
            Room room = await roomDAO.FindByIdAsync(roomId); 
            return Ok(room);
        }


    }
}
