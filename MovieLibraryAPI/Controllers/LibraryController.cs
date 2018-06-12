using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

        [HttpPost]
        public HttpResponseMessage PostMovie(int idUser, LibraryMovie libraryMovie)
        {
            List<Movies> existing_movie = db.Movies.Where(o => o.Id.Equals(libraryMovie.Id)).ToList();
                
            

            if (existing_movie.Count <= 0)
            {
                Movies new_movie = new Movies();
                new_movie.Id = libraryMovie.Id;
                new_movie.ImagePath = libraryMovie.ImagePath;
                new_movie.Title = libraryMovie.Title;
                db.Movies.Add(new_movie);
                db.SaveChanges();
            }

            Rel_User_Movie new_rel_User_Movie = new Rel_User_Movie();

            new_rel_User_Movie.IdMovie = libraryMovie.Id;
            new_rel_User_Movie.IdUser = idUser;

            db.Rel_User_Movie.Add(new_rel_User_Movie);

            db.SaveChanges();

            var existing_rel =
                from rels in db.Rel_User_Movie
                where rels.IdMovie == libraryMovie.Id && rels.IdUser == idUser
                select new { rels.Id };
            

            foreach (Platform platform in libraryMovie.platforms)
            {
                Rel_User_Movie_Platform new_rel_user_Movie_Platform = new Rel_User_Movie_Platform();
                new_rel_user_Movie_Platform.IdPlatform = platform.Id;
                new_rel_user_Movie_Platform.Id_Rel_User_Movie = existing_rel.First().Id;
                db.Rel_User_Movie_Platform.Add(new_rel_user_Movie_Platform);
            }

            db.SaveChanges();
            return new HttpResponseMessage(System.Net.HttpStatusCode.OK);

        }
    }
}