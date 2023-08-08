using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinemax.Models
{
    public class DeleteFromPlatform
    {
        public List<Movie> movies { get; set; }
        public int selectedMovie { get; set; }
        public int selectedPlatform { get; set; }
        public DeleteFromPlatform()

        {
            movies = new List<Movie>();
        }
    }
}