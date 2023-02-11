using BlazorSyncfusionCrm.Server.Data;
using BlazorSyncfusionCrm.Shared;
using GoogleMaps.LocationServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorSyncfusionCrm.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly DataContext _context;

        public ContactsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Contact>>> GetAllContacts()
        {
            return await _context.Contacts
                .Where(c => !c.IsDeleted)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContactById(int id)
        {
            var result = await _context.Contacts.FindAsync(id);
            if (result is null)
            {
                return NotFound("Contact not found.");
            }

            return result;
        }

        [HttpPost]
        public async Task<ActionResult<Contact>> CreateContact(Contact contact)
        {
            SetLatLong(contact);

            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();

            return Ok(contact);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Contact>> UpdateContact(int id, Contact contact)
        {
            var dbContact = await _context.Contacts.FindAsync(id);
            if (dbContact is null)
            {
                return NotFound("Contact not found.");
            }

            dbContact.FirstName = contact.FirstName;
            dbContact.LastName = contact.LastName;
            dbContact.NickName = contact.NickName;
            dbContact.DateOfBirth = contact.DateOfBirth;
            dbContact.Place = contact.Place;
            dbContact.DateUpdated = DateTime.Now;
            SetLatLong(dbContact);

            await _context.SaveChangesAsync();

            return Ok(contact);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Contact>>> DeleteContact(int id)
        {
            var dbContact = await _context.Contacts.FindAsync(id);
            if (dbContact is null)
            {
                return NotFound("Contact not found.");
            }

            dbContact.IsDeleted = true;
            dbContact.DateDeleted = DateTime.Now;

            await _context.SaveChangesAsync();

            return await GetAllContacts();
        }

        [HttpGet("map")]
        public async Task<ActionResult<List<Contact>>> GetMapContacts()
        {
            return await _context.Contacts
                .Where(c => !c.IsDeleted && c.Latitude != null && c.Longitude != null)
                .ToListAsync();
        }

        MapPoint? GetLatLong(Contact contact)
        {
            var gls = new GoogleLocationService("YOUR API KEY HERE");
            var latLong = gls.GetLatLongFromAddress(contact.Place);
            return latLong;
        }

        void SetLatLong(Contact contact)
        {
            var latLong = GetLatLong(contact);
            if (latLong != null)
            {
                contact.Latitude = latLong.Latitude;
                contact.Longitude = latLong.Longitude;
            }
        }
    }
}
