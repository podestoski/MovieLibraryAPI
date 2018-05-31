using System.Linq;
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
    }
}