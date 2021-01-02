using Microsoft.AspNetCore.Identity;

namespace TravelList_API.Models.Domain
{
    public class Preference
    {
        #region Properties
        public int Id { get; set; }
        public bool DarkMode { get; set; }
        public IdentityUser Owner { get; set; }
        #endregion

        #region Constructors
        public Preference()
        {

        }
        #endregion
    }
}
