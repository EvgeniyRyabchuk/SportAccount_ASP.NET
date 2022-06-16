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
    public class UserDAO : IStandartDAO<User>
    {
        private readonly DataContext db;
        public UserDAO(DataContext db)
        {
            this.db = db; 
        }
        
        public async Task<User> ByLoginAsync(string loginName)
        {
            User registeredUser = null;

            // TODO: rework without checking on exception
            try
            {
                registeredUser = await db.Users.Where(u => u.Login == loginName).Include(u => u.Role).FirstAsync(); 
            }
            catch (InvalidOperationException)
            { }

            return registeredUser;

        }


        public async Task<ICollection<User>> GetAllAsync() 
        {
            return await db.Users.ToListAsync();
        }

        public async Task<User> FindByIdAsync(int id)
        {
            User user = await db.Users
                  .Include(u => u.Role)
                  .Where(u => u.Id == id).FirstAsync();


            if (user == null)
                throw new Exception("User does't exist");

            return user; 
        }

        public async Task<ICollection<User>> AddAsync(User registerModel)
        {
            await db.Users.AddAsync(registerModel);
            await db.SaveChangesAsync();
            return await db.Users.ToListAsync(); 
        }


        public async Task<ICollection<User>> UpdateAsync(User request)
        {
            var user = await db.Users.FindAsync(request.Id); 
            if (user == null)
                throw new Exception("User does't exist");

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.MiddletName = request.MiddletName;
            user.BirthDate = request.BirthDate;

            await db.SaveChangesAsync();
            return await db.Users.ToListAsync();
        }
        

        public async Task<ICollection<User>> DeleteAsync(int id)
        {
            var user = await db.Users.FindAsync(id);
            if (user == null)
                throw new Exception("User does't exist");

            db.Users.Remove(user);
            await db.SaveChangesAsync();
            return await db.Users.ToListAsync(); 
        }

    }
}
