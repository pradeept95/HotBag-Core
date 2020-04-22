﻿using System;
using System.ComponentModel.DataAnnotations;

namespace HotBag.AspNetCore.Data.AppUser
{
    public class HotBagUserDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "First name is Required")]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }
        public string Phone { get; set; }
        public UserStatus Status { get; set; }
        public int? TanentIdId { get; set; }
    }
}
