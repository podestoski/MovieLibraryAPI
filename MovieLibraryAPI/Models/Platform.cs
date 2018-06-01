using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieLibraryAPI.Models
{
    public class Platform
    {
        public int Id;
        public string Name;

        public Platform(int Id,string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }

        public Platform()
        {

        }
            
    }
}