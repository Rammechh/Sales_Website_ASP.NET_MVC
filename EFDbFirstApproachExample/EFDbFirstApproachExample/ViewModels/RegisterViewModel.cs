using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EFDbFirstApproachExample.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Username can't be blank")]
        public string Username { get; set; }
        [Required(ErrorMessage ="Password can't be blank")]
        public string Password { get; set; }
        [Display(Name ="Confirm Password")]
        [Required(ErrorMessage ="Confirm Password can't be blank")]
        [Compare("Password",ErrorMessage ="Password and ConfirmPassword doesn't match")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage ="Email Address can't be blank")]
        [EmailAddress(ErrorMessage ="Invalid Email")]
        public string Email { get; set; }
        public string Mobile { get; set; }
        [Display(Name = "Date of Birth")]
        public DateTime? DateOfBirth { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}