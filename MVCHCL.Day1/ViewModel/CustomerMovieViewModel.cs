using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCHCL.Day1.Models;
namespace MVCHCL.Day1.ViewModel
{
    public class CustomerMovieViewModel
    {
        public Customer customer { get; set; }
        public List<Movie> movie{ get; set; }
    }
}