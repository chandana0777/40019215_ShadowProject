using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class User
    {
        public string Id { get; set; }

        [Display(Name = "User Name")]
        [Required(ErrorMessage = "Please Enter User Name")]
        public string UserName { get; set; }
        [Display(Name = "Password ")]
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]

        public string Password { get; set; }
    }
}