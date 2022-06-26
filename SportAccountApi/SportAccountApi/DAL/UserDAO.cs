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
                registeredUser = await db.Users.Where(u => u.Login == loginName)
                    .Include(u => u.Role)
                    .Include(u => u.Specialization)
                    .Include(u => u.Status)
                    .Include(u => u.Sex)
                    .Include(u => u.Role)
                    .Include(u => u.Phones)
                    .Include(u => u.Groups)
                    .FirstAsync(); 
            }
            catch (InvalidOperationException)
            { }

            return registeredUser;

        }

        public async Task<User> ByIdAsync(int id)
        {
            return await db.Users.Where(u => u.Id == id)
                .Include(u => u.Role)
                .Include(u => u.Specialization)
                .Include(u => u.Status)
                .Include(u => u.Sex)
                .Include(u => u.Role)
                .Include(u => u.Phones)
                .Include(u => u.Groups)
                .FirstAsync();  
        }


        public async Task<ICollection<User>> ByGroupIdAsync(int groupId)
        {
            ICollection<User> users = await db.Groups
                .Where(g => g.Id == groupId)
                .SelectMany(u => u.Users)
                .Include(u => u.Sex)
                .Include(u => u.Phones)
                .Include(u => u.Status)
                .Include(u => u.Specialization)
                .Include(u => u.Role)
                .ToListAsync();
            return users; 
        }


        public async Task<ICollection<User>> GetAllAsync() 
        {
            return await db.Users
                .Include(u => u.Role)
                .Include(u => u.Specialization)
                .Include(u => u.Status)
                .Include(u => u.Sex)
                .Include(u => u.Role)
                .Include(u => u.Phones)
                .Include(u => u.Groups)
                .ToListAsync();
        }

        //public async Task<User> ByRoleIdAsync(,int roleId)
        //{
        //    return await db.Users
        //        .Where(u => u.RoleId == roleId)
        //        .Include(u => u.Role)
        //        .Include(u => u.Specialization)
        //        //.Include(u => u.StatusId)
        //        .Include(u => u.Sex)
        //        .Include(u => u.Role)
        //        .Include(u => u.Phones)
        //        .Include(u => u.Groups)
        //        .FirstAsync();
        //}

        public async Task<ICollection<User>> GetAllByRoleIdAsync(int roleId)
        {
            return await db.Users
                .Where(u => u.RoleId == roleId) 
                .Include(u => u.Role) 
                .Include(u => u.Specialization)
                .Include(u => u.Status)
                .Include(u => u.Sex) 
                .Include(u => u.Role) 
                .Include(u => u.Phones)
                .Include(u => u.Groups)
                .ToListAsync();
        }

        public async Task<User> FindByIdAsync(int id)
        {
            User user = await db.Users
                .Include(u => u.Role)
                .Include(u => u.Specialization)
                .Include(u => u.Status)
                .Include(u => u.Sex)
                .Include(u => u.Role)
                .Include(u => u.Phones)
                .Include(u => u.Groups)
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

        public async Task<ICollection<User>> AddGroupAsync(User user, Group group)
        {
            if (user.Groups.Find(g => g.Id == group.Id) != null)
            {
                throw new Exception("The group already exist for this user"); 
            }
            
            user.Groups.Add(group);
            await db.SaveChangesAsync();
            return group.Users; 
        }
        
        public async Task<ICollection<User>> UpdateAsync(User request)
        {
            var user = await db.Users.FindAsync(request.Id); 
            if (user == null)
                throw new Exception("User does't exist");
            
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.MiddleName = request.MiddleName;
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

        public async Task<ICollection<User>> DeleteGroupFromUserAsync(int groupId, int userId)
        {
            Group group = await db.Groups.Include(g => g.Users).Where(g => g.Id == groupId).FirstAsync(); 
            User user = null; 
            
            foreach (User curUser in group.Users) 
            {
                if(curUser.Id == userId) 
                {
                    user = curUser;
                    break;
                }
            }
         
            
            if (user == null)
                throw new Exception("User does't exist");
            if (group == null)
                throw new Exception("Group does't exist");

            user.Groups.Remove(group); 
            
            await db.SaveChangesAsync();
            return group.Users; 
        }


    }
}
