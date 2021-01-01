using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TravelList_API.DTOs;
using TravelList_API.Models;
using TravelList_API.Models.Domain;

namespace TravelList_API.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private readonly ITripRepository _tripRepository;
        private readonly UserManager<IdentityUser> _userManager;

        public TripsController(ITripRepository tripRepository, UserManager<IdentityUser> userManager)
        {
            _tripRepository = tripRepository;
            _userManager = userManager;
        }

        // GET: api/Trips
        /// <summary>
        /// Get all trips from user
        /// </summary>
        /// <returns>array of trips</returns>
        [HttpGet]
        public IEnumerable<TripDTO> GetTrips()
        {
            return _tripRepository.GetAll(GetCurrentUserEmail()).Select(t => new TripDTO(t));
        }

        // GET: api/Trips/5
        /// <summary>
        /// Get the trip with given id
        /// </summary>
        /// <param name="id">the id of the trip</param>
        /// <returns>The trip</returns>
        [HttpGet("{id}")]
        public ActionResult<TripDTO> GetTrip(int id)
        {
            Trip trip = _tripRepository.GetBy(id, GetCurrentUserEmail());
            if (trip == null) return NotFound("No trips were found");
            return new TripDTO(trip);
        }

        // POST: api/Trips
        /// <summary>
        /// Adds a new trip
        /// </summary>
        /// <param name="trip">the new trip</param>
        [HttpPost]
        public ActionResult<Trip> PostTrip(TripAddDTO tripDTO)
        {
            Trip trip = new Trip(tripDTO, _userManager.FindByNameAsync(GetCurrentUserEmail()).Result);
            _tripRepository.Add(trip);
            _tripRepository.SaveChanges();

            return CreatedAtAction(nameof(GetTrip), new { id = trip.Id }, new TripDTO(trip));
        }

        // PUT: api/Trips/5
        /// <summary>
        /// Modifies a trip
        /// </summary>
        /// <param name="id">id of the trip to be modified</param>
        /// <param name="trip">the modified trip</param>
        [HttpPut("{id}")]
        public IActionResult PutTrip(int id, TripDTO tripDTO)
        {
            if (id != tripDTO.Id)
                return BadRequest();
            Trip trip = _tripRepository.GetBy(id, GetCurrentUserEmail());
            if (trip == null || trip.Owner.Email != GetCurrentUserEmail())
                return BadRequest();
            trip.UpdateFromDTO(tripDTO);
            _tripRepository.Update(trip);
            _tripRepository.SaveChanges();
            return Ok();
        }

        // DELETE: api/Trips/5
        /// <summary>
        /// Deletes a trip
        /// </summary>
        /// <param name="id">the id of the trip to be deleted</param>

        [HttpDelete("{id}")]
        public IActionResult DeleteTrip(int id)
        {
            Trip trip = _tripRepository.GetBy(id, GetCurrentUserEmail());
            if (trip == null)
            {
                return NotFound();
            }
            _tripRepository.Delete(trip);
            _tripRepository.SaveChanges();
            return Ok();
        }

        private string GetCurrentUserEmail()
        {
            return User.Identity.Name;

        }
    }
}
