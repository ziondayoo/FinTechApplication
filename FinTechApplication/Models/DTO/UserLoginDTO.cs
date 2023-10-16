﻿using System.ComponentModel.DataAnnotations;

namespace FinTechApplication.Models.DTO
{
    public class UserLoginDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}

