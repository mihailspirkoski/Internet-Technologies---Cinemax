using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cinemax.Models
{
    public class Platform
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string PlatformName { get; set; }
        [Required]
        public string PlatformAddress { get; set; }
        [Required]
        public string PlatformImage { get; set; }
        public virtual List<Movie> movies { get; set; }
        public Platform()
        {
            movies = new List<Movie>();
        }
    }
}