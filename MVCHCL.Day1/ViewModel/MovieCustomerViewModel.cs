using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCHCL.Day1.Models;
namespace MVCHCL.Day1.ViewModel
{
    public class MovieCustomerViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}