using NoteApi.Models;

namespace NoteApi.Interfaces;

public interface INotesRepository
{
    List<Note> GetAll();
    Note? GetById(Guid id);
    Note Create(Note note);
    bool Delete(Guid id);
    Note? Put(Guid id, Note note);
    Note? Patch(Guid id, string? title, string? content);
}