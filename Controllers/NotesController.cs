using Microsoft.AspNetCore.Mvc;
using NoteApi.DTOs;
using NoteApi.Interfaces;
using NoteApi.Models;

namespace NoteApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotesController : ControllerBase
{
    private readonly INotesService _notesService;

    public NotesController(INotesService notesService)
    {
        _notesService = notesService;
    }

    [HttpPost]
    public ActionResult<Note> Create(CreateNoteRequest request)
    {
        var createdNote = _notesService.Create(request.Title, request.Content);
        return Ok(createdNote);
    }    
    
    [HttpGet("{id:guid}")]
    public ActionResult<Note> GetById(Guid id)
    {
        var note = _notesService.GetById(id);
        if (note is not null)
            return Ok(note);
        return NotFound();
    }    
    
    [HttpGet]
    public ActionResult<IEnumerable<Note>> GetAll()
    {
        var notes = _notesService.GetAll();
        if (notes is not null && notes.Any())
            return Ok(notes);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        var isDeleted = _notesService.Delete(id);
        if (!isDeleted) return NotFound();
        return NoContent();
    }
}