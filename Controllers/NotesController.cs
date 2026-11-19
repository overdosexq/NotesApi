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
    public async Task<ActionResult<NoteResponse>> Create(CreateNoteRequest request, CancellationToken cancellationToken)
    {
        var createdNote = await _notesService.CreateAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById),
         new { id = createdNote.Id },
         ToResponse(createdNote));
    }    
    
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<NoteResponse>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var note = await _notesService.GetByIdAsync(id, cancellationToken);
        if (note is null)
            return NotFound();


        return Ok(ToResponse(note));
    }    
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<NoteResponse>>> GetAll(CancellationToken cancellationToken)
    {
        var notes = await _notesService.GetAllAsync(cancellationToken);
        return Ok(notes.Select(ToResponse));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var isDeleted = await _notesService.DeleteAsync(id, cancellationToken);
        if (!isDeleted) return NotFound();
        return NoContent();
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<NoteResponse>> Put(
        Guid id,
        PutNoteRequest request,
        CancellationToken cancellationToken)
    {
        var note = await _notesService.PutAsync(id, request, cancellationToken);
        if (note is null) return NotFound();
        return Ok(ToResponse(note));
    }

    [HttpPatch("{id:guid}")]
    public async Task<ActionResult<NoteResponse>> Patch(
        Guid id,
        PatchNoteRequest request,
        CancellationToken cancellationToken)
    {
        var note = await _notesService.PatchAsync(id, request, cancellationToken);
        if (note is null) return NotFound();
        return Ok(ToResponse(note));
    }

    private static NoteResponse ToResponse(Note note)
    {
        return new NoteResponse
        {
            Id = note.Id,
            Title = note.Title,
            Content = note.Content,
            CreatedAt = note.CreatedAt
        };
    }
}