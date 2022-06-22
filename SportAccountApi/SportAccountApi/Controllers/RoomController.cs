using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportAccountApi.DAL;
using SportAccountApi.DTO.Group;
using SportAccountApi.DTO.Room;
using SportAccountApi.Mapper;
using SportAccountApi.Models;
using System;
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
            var list = await roomDAO.GetAllAsync();   
            return Ok(list);  
        }

        [HttpGet("{roomId}")]
        public async Task<ActionResult<ICollection<Room>>> ShowAsync(int roomId)
        {
            Room room = await roomDAO.FindByIdAsync(roomId); 
            return Ok(room);
        }


        [HttpPost]
        public async Task<ActionResult<ICollection<Room>>> StoreAsync(CreateRoomDTO createGroupDTO)
        {
            Room room = RoomMapper.fromCreateModel(createGroupDTO); 
            var list = await roomDAO.AddAsync(room); 
            return Ok(list); 
        }
        
        [HttpDelete("room/{roomId}")] 
        public async Task<ActionResult<ICollection<Room>>> Delete(int roomId)
        {
            var list = await roomDAO.DeleteAsync(roomId); 
            return Ok(list); 
        }
    }
}
