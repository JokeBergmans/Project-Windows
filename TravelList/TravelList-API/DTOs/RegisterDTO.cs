using System.ComponentModel.DataAnnotations;

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
