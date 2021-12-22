//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EmployeeTest.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Employee
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
        public System.DateTime join_date { get; set; }
        public bool status { get; set; }
        public Nullable<System.DateTime> entry_date { get; set; }
        [Required]
        public string level { get; set; }
    }
}
