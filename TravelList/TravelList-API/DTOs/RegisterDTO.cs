using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TravelList_API.DTOs
{

    public class RegisterDTO : LoginDTO
    {
        [Required]
        [StringLength(200)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(250)]
        public string LastName { get; set; }

        [Required]
        [Compare("Password")]
        public string PasswordConfirmation { get; set; }
    }
}
