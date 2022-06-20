using SportAccountApi.Models;
using Microsoft.EntityFrameworkCore;
using SportAccountApi.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using SportAccountApi.DTO.User;

namespace SportAccountApi.DAL
{
    public class RoleDAO : IStandartDAO<Role>
    {
        private readonly DataContext db;
        public RoleDAO(DataContext db)
        {
            this.db = db; 
        }

        public async Task<ICollection<Role>> GetAllAsync()
        {
            return await db.Roles.ToListAsync();
        }

        public async Task<Role> FindByIdAsync(int id)
        {
            Role role = null; 
            try
            {
                role = await db.Roles
                 .Where(u => u.Id == id).FirstAsync();
            }
            catch(Exception ex)
            {
                if (role == null)
                    throw new Exception("Role does't exist");
                else
                    throw; 
            }

            return role;
        }
        public async Task<Role> FindByNameAsync(string name)
        {
            Role role = null;
            try
            {
                role = await db.Roles
                 .Where(u => u.Name == name)
                 .FirstAsync();
            }
            catch (Exception ex)
            {
                if (role == null)
                    throw new Exception("Role does't exist");
                else
                    throw;
            }

            return role;
        }
        public async Task<ICollection<Role>> AddAsync(Role role)
        {
            await db.Roles.AddAsync(role);
            await db.SaveChangesAsync();
            return await db.Roles.ToListAsync();
        }


        public async Task<ICollection<Role>> UpdateAsync(Role request)
        {
            Role role = await db.Roles.FindAsync(request.Id);
            if (role == null)
                throw new Exception("User does't exist");

            role.Name = request.Name;

            await db.SaveChangesAsync();
            return await db.Roles.ToListAsync();
        }


        public async Task<ICollection<Role>> DeleteAsync(int id)
        {
            Role role = await db.Roles.FindAsync(id);
            if (role == null)
                throw new Exception("User does't exist");

            db.Roles.Remove(role);
            await db.SaveChangesAsync();
            return await db.Roles.ToListAsync();
        }

    }
}
