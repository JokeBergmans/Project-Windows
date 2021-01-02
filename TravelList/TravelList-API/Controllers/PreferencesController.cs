using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TravelList_API.Models;
using TravelList_API.Models.Domain;

namespace TravelList_API.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class PreferencesController : ControllerBase
    {
        private readonly IPreferenceRepository _preferenceRepository;

        public PreferencesController(IPreferenceRepository preferenceRepository)
        {
            _preferenceRepository = preferenceRepository;
        }

        // GET: api/Preferences
        /// <summary>
        /// Get preference for user
        /// </summary>
        /// <returns>preference of user</returns>
        [HttpGet]
        public ActionResult<Preference> GetPreference()
        {
            return Ok(_preferenceRepository.GetBy(GetCurrentUserEmail()));
        }

        // PUT: api/Preferences/5
        /// <summary>
        /// Modifies a preference
        /// </summary>
        /// <param name="id">id of the preference to be modified</param>
        /// <param name="preference">the modified preference</param>
        [HttpPut("{id}")]
        public IActionResult PutPreference(int id, Preference preference)
        {
            if (id != preference.Id)
                return BadRequest();
            Preference p = _preferenceRepository.GetBy(GetCurrentUserEmail());
            if (p == null || p.Owner.Email != GetCurrentUserEmail())
                return BadRequest();
            p.DarkMode = preference.DarkMode;
            _preferenceRepository.Update(p);
            _preferenceRepository.SaveChanges();
            return NoContent();
        }

        private string GetCurrentUserEmail()
        {
            return User.Identity.Name;

        }
    }
}
