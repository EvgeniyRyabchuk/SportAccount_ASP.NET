using SportAccountApi.DTO.Room;
using SportAccountApi.Models;

namespace SportAccountApi.Mapper
{
    public class RoomMapper
    {
        public static Room fromCreateModel(CreateRoomDTO createRoomDTO)
        {
            return new Room()
            {
                Number = createRoomDTO.Number,
                Name = createRoomDTO.Name,
                AreaSize = createRoomDTO.AreaSize,
                Floor = createRoomDTO.Floor
            }; 
        }
    }
}
