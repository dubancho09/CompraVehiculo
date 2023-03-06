﻿using System.ComponentModel.DataAnnotations;

namespace Core.Dto
{
    public class UserDto
    {
        [Required]
        [MaxLength(40, ErrorMessage = "Maximo 40")]
        public string userName { get; set; }

        [MaxLength(100, ErrorMessage = "Maximo 100")]
        public string email { get; set; }

        [Required]
        public string password { get; set; }
    }
}
