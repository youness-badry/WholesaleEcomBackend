﻿using System.ComponentModel.DataAnnotations;

namespace WholesaleEcomBackend.Dtos
{
    public class UserForAuthenticationDto
    {
        [Required(ErrorMessage = "Username is required")]
        public string? UserName { get; init; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; init; } 


    }
}
