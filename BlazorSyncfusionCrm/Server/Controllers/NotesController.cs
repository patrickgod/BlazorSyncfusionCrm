using BlazorSyncfusionCrm.Client.Pages;
using BlazorSyncfusionCrm.Server.Data;
using BlazorSyncfusionCrm.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Syncfusion.Blazor.Diagram;

namespace BlazorSyncfusionCrm.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly DataContext _context;

        public NotesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Note>>> GetAllNotes()
        {
            return await _context.Notes
                .Include(n => n.Contact)
                .OrderByDescending(n => n.DateCreated)
                .ToListAsync();
        }

        [HttpGet("{contactId}")]
        public async Task<ActionResult<List<Note>>> GetNotesFromContact(int contactId)
        {
            return await _context.Notes
                .Where(n => n.ContactId == contactId)
                .OrderByDescending(n => n.DateCreated)
                .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<List<Note>>> CreateNote(Note note)
        {
            _context.Notes.Add(note);
            await _context.SaveChangesAsync();

            return await _context.Notes
                .Where(n => n.ContactId == note.ContactId)
                .OrderByDescending(n => n.DateCreated)
                .ToListAsync();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Note>>> DeleteNote(int id)
        {
            var dbNote = await _context.Notes.FindAsync(id);
            if(dbNote is null)
            {
                return NotFound("Note not found.");
            }

            _context.Notes.Remove(dbNote);
            await _context.SaveChangesAsync();

            return await _context.Notes
                .Where(n => n.ContactId == dbNote.ContactId)
                .OrderByDescending(n => n.DateCreated)
                .ToListAsync();
        }
    }
}
