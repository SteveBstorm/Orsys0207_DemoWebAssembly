﻿using System.ComponentModel.DataAnnotations;

namespace DemoWebAssembly.Models
{
    public class LoginForm
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
