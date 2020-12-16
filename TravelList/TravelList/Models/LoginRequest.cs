using Newtonsoft.Json;

namespace TravelList.Models
{
    public class LoginRequest
    {
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
