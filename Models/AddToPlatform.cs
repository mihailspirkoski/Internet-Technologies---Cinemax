using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinemax.Models
{
    public class AddToPlatform
    {
        public List<Movie> movies { get; set; }
        public int selectedMovie { get; set; }
        public int selectedPlatform { get; set; }
        public AddToPlatform()

        {
            movies = new List<Movie>();
        }
    }
}