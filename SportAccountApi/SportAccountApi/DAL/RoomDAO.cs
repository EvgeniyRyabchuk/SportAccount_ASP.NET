using Microsoft.EntityFrameworkCore;
using SportAccountApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAccountApi.DAL
{
    public class RoomDAO : IStandartDAO<Room>
    {
        private readonly DataContext db;
        public RoomDAO(DataContext db)
        {
            this.db = db;
        }

        public async Task<ICollection<Room>> AddAsync(Room model)
        {
            await db.Rooms.AddAsync(model);
            await db.SaveChangesAsync();
            return await db.Rooms.ToListAsync(); 
        }

        public async Task<ICollection<Room>> DeleteAsync(int id)
        {
            Room room = await db.Rooms.FindAsync(id);
            db.Rooms.Remove(room); 
            await db.SaveChangesAsync();
            return await db.Rooms.ToListAsync(); 
        }

        public async Task<Room> FindByIdAsync(int id)
        {
            return await db.Rooms.FindAsync(id); 
        }

        public async Task<ICollection<Room>> GetAllAsync()
        {
            return await db.Rooms.ToListAsync();
        }

        public Task<ICollection<Room>> UpdateAsync(Room model)
        {
            throw new System.NotImplementedException();
        }
    }
}
