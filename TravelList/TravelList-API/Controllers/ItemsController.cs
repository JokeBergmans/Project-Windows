using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
    public class ItemsController : ControllerBase
    {
        private readonly IItemRepository _itemRepository;
        private readonly UserManager<IdentityUser> _userManager;

        public ItemsController(IItemRepository itemRepository, UserManager<IdentityUser> userManager)
        {
            _itemRepository = itemRepository;
            _userManager = userManager;
        }

        // GET: api/Items
        /// <summary>
        /// Get all items from user
        /// </summary>
        /// <returns>array of items</returns>
        [HttpGet]
        public IEnumerable<Item> GetItems()
        {
            return _itemRepository.GetAll(GetCurrentUserEmail());
        }

        // GET: api/Items/5
        /// <summary>
        /// Get the item with given id
        /// </summary>
        /// <param name="id">the id of the item</param>
        /// <returns>The item</returns>
        [HttpGet("{id}")]
        public ActionResult<Item> GetItem(int id)
        {
            Item item = _itemRepository.GetBy(id, GetCurrentUserEmail());
            if (item == null) return NotFound("No trips were found");
            return item;
        }

        // POST: api/Items
        /// <summary>
        /// Adds a new item
        /// </summary>
        /// <param name="item">the new item</param>
        [HttpPost]
        public ActionResult<Item> PostItem(ItemAddDTO itemDTO)
        {
            IdentityUser owner = _userManager.FindByNameAsync(GetCurrentUserEmail()).Result;
            if (owner == null)
                return BadRequest();
            Item item = new Item(itemDTO, owner);
            _itemRepository.Add(item);
            _itemRepository.SaveChanges();

            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item);
        }

        // PUT: api/Items/5
        /// <summary>
        /// Modifies an item
        /// </summary>
        /// <param name="id">id of the item to be modified</param>
        /// <param name="item">the modified item</param>
        [HttpPut("{id}")]
        public IActionResult PutItem(int id, Item item)
        {
            if (id != item.Id)
                return BadRequest();
            Item i = _itemRepository.GetBy(id, GetCurrentUserEmail());
            if (i == null || i.Owner.Email != GetCurrentUserEmail())
                return BadRequest();
            i.UpdateFrom(item);
            _itemRepository.Update(i);
            _itemRepository.SaveChanges();
            return NoContent();
        }

        // DELETE: api/Items/5
        /// <summary>
        /// Deletes an item
        /// </summary>
        /// <param name="id">the id of the item to be deleted</param>

        [HttpDelete("{id}")]
        public IActionResult DeleteItem(int id)
        {
            Item item = _itemRepository.GetBy(id, GetCurrentUserEmail());
            if (item == null)
            {
                return NotFound();
            }
            _itemRepository.Delete(item);
            _itemRepository.SaveChanges();
            return NoContent();
        }

        private string GetCurrentUserEmail()
        {
            return User.Identity.Name;

        }
    }
}
