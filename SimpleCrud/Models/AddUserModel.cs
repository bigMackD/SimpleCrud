using SimpleCrud.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimpleCrud.Models
{
    public class AddUserModel
    {
        [Required(ErrorMessage ="First name must be entered!")]
        [MinLength(3, ErrorMessage = "Last name can't be shorter than 3 characters!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name must be entered!")]
        [MinLength(3, ErrorMessage ="Last name can't be shorter than 3 characters!")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        public Role Role { get; set; }
    }
}