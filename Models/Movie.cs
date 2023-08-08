using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cinemax.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string MovieTitle { get; set; }
        [Required]
        public decimal MoviePrice { get; set; }
        [Required]
        public string MovieImage { get; set; }
        [Required]
        public string MovieGenre { get; set; }
        [Required]
        public string MovieDirector { get; set; }
        [Required]
        public string MovieActors { get; set; }
        [Required]
        public decimal MovieRating { get; set; }

        public virtual List<Platform> platforms { get; set; }

        public Movie()
        {
            platforms = new List<Platform>();
        }
    }
}