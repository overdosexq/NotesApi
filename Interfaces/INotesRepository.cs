using NoteApi.Models;

namespace NoteApi.Interfaces;

public interface INotesRepository
{
    List<Note> GetAll();
    Note GetById(Guid id);
    Note Create(Note note);
    Note Delete(Note note);
}