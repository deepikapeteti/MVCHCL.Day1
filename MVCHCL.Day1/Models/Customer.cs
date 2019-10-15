using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace MVCHCL.Day1.Models
{
    public class Customer
    {
        
        public int id { get; set; }
        [Display(Name ="YOUR NAME")]
        [Required]
        public string customername { get; set; }
        [Required]
        [Display(Name ="DOB")]
        public DateTime? BirthDate { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string City { get; set; }
        public MembershipType MembershipType { get; set; }
      [Required]
        public int? MembershipTypeId { get; set; }
    }
}