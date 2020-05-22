using Monster.DTO_s;
using System;
using System.ComponentModel.DataAnnotations;

namespace RecipeApi.DTOs
{
    public class RegisterDTO : LoginDTO
    {
        [Required]
        [StringLength(200)]
        public String FirstName { get; set; }

        [Required]
        [StringLength(250)]
        public String LastName { get; set; }

        [Required]
        [Compare("Password")]
        [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "Passwords must be at least 8 characters and contain upper case (A-Z), lower case (a-z) and number (0-9)")]
        public String PasswordConfirmation { get; set; }
    }
}
