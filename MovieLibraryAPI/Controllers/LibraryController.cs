using System.Linq;
using System.Web.Http;
using MovieLibraryAPI.Models;

namespace MovieLibraryAPI.Controllers
{
    public class LibraryController : ApiController
    {
        private MyMovieLibraryEntities db = new MyMovieLibraryEntities();

        // GET: Users
        public object GetLibrary(int idUser)
        {
            var query =
                from movie in db.Movies
                join rel in db.Rel_User_Movie on movie.Id equals rel.IdMovie
                select new { movie.Id, movie.ImagePath, movie.Title };

            return new
            {
                idUser = idUser,
                Movies = query
            };
        }
    }
}