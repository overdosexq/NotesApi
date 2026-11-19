using Microsoft.EntityFrameworkCore;
using NoteApi.DTOs;
using NoteApi.Interfaces;
using NoteApi.Models;

namespace NoteApi.Services;

public class NotesService : INotesService
{
    private readonly NotesDbContext _db;

    public NotesService(NotesDbContext db)
    {
        _db = db;
    }

    public async Task<Note> CreateAsync(
        CreateNoteRequest request,
        CancellationToken cancellationToken)
    {
        var note = new Note(request.Title, request.Content);

        _db.Notes.Add(note);
        await _db.SaveChangesAsync(cancellationToken);

        return note;
    }

    public Task<Note?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return _db.Notes
            .AsNoTracking()
            .FirstOrDefaultAsync(n => n.Id == id, cancellationToken);
    }
    
    public Task<List<Note>> GetAllAsync(CancellationToken cancellationToken)
    {
        return _db.Notes
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var note = await _db.Notes
            .FirstOrDefaultAsync(note => note.Id == id, cancellationToken);

        if (note is null)
            return false;

        _db.Notes.Remove(note);
        await _db.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<Note?> PutAsync(
        Guid id,
        PutNoteRequest request,
        CancellationToken cancellationToken)
    {
        var note = await _db.Notes
            .FirstOrDefaultAsync(note => note.Id == id, cancellationToken);

        if (note is null)
            return null;

        note.Title = request.Title;
        note.Content = request.Content;

        await _db.SaveChangesAsync(cancellationToken);
        return note;
    }

    public async Task<Note?> PatchAsync(
        Guid id,
        PatchNoteRequest request,
        CancellationToken cancellationToken)
    {
        var note = await _db.Notes
            .FirstOrDefaultAsync(note => note.Id == id, cancellationToken);

        if (note is null)
            return null;

        if (request.Title is not null)
            note.Title = request.Title;

        if (request.Content is not null)
            note.Content = request.Content;

        await _db.SaveChangesAsync(cancellationToken);
        return note;
    }
}