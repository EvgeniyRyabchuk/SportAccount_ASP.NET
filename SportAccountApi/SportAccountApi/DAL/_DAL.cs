
using Microsoft.EntityFrameworkCore;
using SportAccountApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace FilmsStorage.DAL
{
    public class _DAL
    {

        //private DataContext db { get; set; } 

        //public _DAL(DataContext db)
        //{
        //    this.db = db; 
        //}

        //public static class Users
        //{
        //    public async static Task<User> ByLoginAsync(string loginName)
        //    {
        //        User registeredUser = null;

        //        // TODO: rework without checking on exception
        //        try
        //        {
        //            registeredUser = await db.Users.Where(u => u.Login == loginName).FirstAsync(); 
        //        }
        //        catch (InvalidOperationException)
        //        { }

        //        return registeredUser;
                
        //    }

        //    public async static Task<User> RegisterAsync(User registerModel)
        //    {
        //        using (var db = new DataContext())
        //        {
        //            await db.Users.AddAsync(registerModel);
        //            await db.SaveChangesAsync();
        //        }

        //        return registerModel;
        //    }
        //}


        //    public static class Films {

        //        public static Film Add(FilmAddModel addFilmModel)
        //        {
        //            using(var db = new FilmsStorageDB())
        //            {
        //                Film filmToAdd = FilmMapper.FromAddModel(addFilmModel);

        //                db.Films.Add(filmToAdd);
        //                db.SaveChanges();

        //                return filmToAdd;
        //            }
        //        }
        //    }

        //    public static class Genres
        //    {
        //        public static List<Genre> All()
        //        {
        //            using (var db = new FilmsStorageDB())
        //            {
        //                return db.Genres.ToList();
        //            }
        //        }
        //    }
        //}
    }
}