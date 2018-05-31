using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieLibraryAPI.Models;

namespace MovieLibraryAPI.Controllers
{
    public class MoviesController : ApiController
    {
        private MyMovieLibraryEntities db = new MyMovieLibraryEntities();

        // GET: Users
        public IQueryable<Movies> GetMovies ()
        {
            return db.Movies;
        }

        public IQueryable<Movies> GetMovie(int idMovie)
        {
            IQueryable<Movies> results;
            results = db.Movies.Where(o => o.Id.Equals(idMovie));
            return results;
        }

        public HttpResponseMessage PostMovie(Movies movie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, movie);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = movie.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }
    }
}