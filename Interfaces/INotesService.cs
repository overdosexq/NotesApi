using NoteApi.DTOs;
using NoteApi.Models;

namespace NoteApi.Interfaces;

public interface INotesService
{
    Task<Note> CreateAsync(string title, string content, CancellationToken cancellationToken);
    Task<Note?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<List<Note>> GetAllAsync(CancellationToken cancellationToken);
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken);
    Task<Note?> PutAsync(Guid id, PutNoteRequest request, CancellationToken cancellationToken);
    Task<Note?> PatchAsync(Guid id, PatchNoteRequest request, CancellationToken cancellationToken);
}