﻿using System.ComponentModel.DataAnnotations;

namespace TP_Back.Models.Users
{
    public class RegisterRequest
    {

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
