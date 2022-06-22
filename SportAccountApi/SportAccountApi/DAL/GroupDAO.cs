using Microsoft.EntityFrameworkCore;
using SportAccountApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SportAccountApi.DAL
{
    public class GroupDAO : IStandartDAO<Models.Group>
    {
        private readonly DataContext db;
        public GroupDAO(DataContext db)
        {
            this.db = db;
        }


        public async Task<ICollection<Models.Group>> AddAsync(Models.Group model)
        {
            await db.Groups.AddAsync(model);
            await db.SaveChangesAsync(); 
            return await db.Groups.ToListAsync(); 
        }

        public async Task<ICollection<Models.Group>> DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Models.Group> FindByIdAsync(int id)
        {
            Models.Group group = await db.Groups
                .Where(g => g.Id == id)
                .Include(g => g.Users).FirstAsync(); 
            
            if (group == null) throw new Exception("Group does not exist"); 
            return group; 
        }

        public async Task<ICollection<Models.Group>> GetAllAsync()
        {
            return await db.Groups
                .Include(g => g.Users)
                .ToListAsync(); 
        }

        public async Task<ICollection<Models.Group>> UpdateAsync(Models.Group model)
        {
            throw new System.NotImplementedException();
        }
    }
}
