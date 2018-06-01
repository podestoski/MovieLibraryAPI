using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieLibraryAPI.Models;

namespace MovieLibraryAPI.Models
{
    public class LibraryMovie
    {
        private MyMovieLibraryEntities db = new MyMovieLibraryEntities();

        public int Id { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public List<Platform> platforms {get; set;}

        public LibraryMovie(int Id, string Title, string ImagePath, List<Platform> platforms)
        {
            this.Id = Id;
            this.Title = Title;
            this.ImagePath = ImagePath;
            this.platforms = platforms;
        }
    }
}