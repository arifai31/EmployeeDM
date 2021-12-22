using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EmployeeTest.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string name { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string alamat { get; set; }
        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime join_date { get; set; }
        [Required]
        public bool status { get; set; }
        [Required]
        public string level { get; set; }
    }
    
}