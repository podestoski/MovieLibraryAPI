using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using MovieLibraryAPI.Models;

namespace MovieLibraryAPI.Controllers
{
    public class UsersController : ApiController
    {

        private MyMovieLibraryEntities db = new MyMovieLibraryEntities();

        // GET: Users
        public IQueryable<Users> GetUsers()
        {
            return db.Users;
        }

        public IQueryable<Users> GetUser(int idUser)
        {
            IQueryable<Users> results;
            results = db.Users.Where(o => o.Id.Equals(idUser));
            return results;
        }

        public int GetLogin(string user, string password)
        {
            List<Users> users = db.Users.Where(o => o.Email.Equals(user)).ToList();
            if (users.Count <= 0)
                return 0;

            users = users.Where(o => o.Password.Equals(password)).ToList();
            if (users.Count <= 0)
                return 0;

            return users[0].Id;

        }

        [HttpPost]
        public object PostUser(PostUser user)
        {
            try
            {
                Users newUser = new Users();
                newUser.Email = user.Email;
                newUser.Name = user.Name;
                newUser.Last_name = user.LastName;
                newUser.Password = user.Password;
                newUser.IdCountry = 1;

                db.Users.Add(newUser);
                db.SaveChanges();
            }
            catch (Exception err)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
            }
            return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        }
    }
}