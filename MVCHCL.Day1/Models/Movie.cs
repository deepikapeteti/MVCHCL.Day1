using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MVCHCL.Day1.Models
{
    public class Movie
    {
        public int id { get; set; }
        [Display(Name ="Movie Name")]
        [Required]
        public string name { get; set; }
       // public string Genre { get; set; }
       [Required]
        public DateTime? Releasedate{ get; set; }
        [Required]
        public DateTime? Dateadded { get; set; }
        public Genre Genre { get; set; }
        [Required]
        public int? GenreId { get; set; }
        [Required]
        public int Availablestock { get; set; }
    }
}