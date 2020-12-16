using Newtonsoft.Json;

namespace TravelList.Models
{
    public class RegistrationRequest
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("passwordConfirmation")]
        public string PasswordConfirmation { get; set; }

    }
}
