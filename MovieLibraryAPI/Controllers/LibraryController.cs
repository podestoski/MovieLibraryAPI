using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MovieLibraryAPI.Models;

namespace MovieLibraryAPI.Controllers
{
    public class LibraryController : ApiController
    {
        private MyMovieLibraryEntities db = new MyMovieLibraryEntities();
        private List<LibraryMovie> libraryMovies = new List<LibraryMovie>();

        // GET: Users
        public object GetLibrary(int idUser)
        {
            var movies =
                from movie in db.Movies
                join rel in db.Rel_User_Movie on movie.Id equals rel.IdMovie
                where rel.IdUser == idUser
                select new { movie.Id, movie.ImagePath, movie.Title, Id_Rel_User_Movie = rel.Id };

            foreach (var movie in movies)
            {
                var platforms =
                    (from platform in db.Cat_Platforms
                     join rel in db.Rel_User_Movie_Platform on platform.Id equals rel.IdPlatform
                     where rel.Id_Rel_User_Movie == movie.Id_Rel_User_Movie
                     select new Platform { Id = platform.Id, Name= platform.Platform }).ToList();


                LibraryMovie libraryMovie = new LibraryMovie(movie.Id, movie.Title, movie.ImagePath, platforms);
                libraryMovies.Add(libraryMovie);
            }

            return new
            {
                idUser = idUser,
                Movies = libraryMovies
            };
        }
    }
}