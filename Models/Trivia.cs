using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cinemax.Models
{
    public class Trivia
    {
        [Key]
        public int Id { get; set; }
        public string TriviaName { get; set; }
        public string TriviaImage { get; set; }
        public string TriviaDescription { get; set; }

    }
}