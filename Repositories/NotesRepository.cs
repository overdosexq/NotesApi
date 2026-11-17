using NoteApi.Interfaces;
using NoteApi.Models;

namespace NoteApi.Repositories;

public class NotesRepository : INotesRepository
{
    private List<Note> _notes = new()
    {
        new Note("Заметка 1", "Контент заметки 1"),
        new Note("Заметка 2", "Контент заметки 2"),
        new Note("Заметка 3", "Контент заметки 3")
    };
    

    public List<Note> GetAll()
    {
        return _notes;
    }

    public Note? GetById(Guid id)
    {
        return _notes.FirstOrDefault(n => n.Id == id);
    }

    public Note Create(Note note)
    {
        _notes.Add(note);
        return note;
    }
    
    public bool Delete(Guid id)
    {
        var note  = _notes.FirstOrDefault(n => n.Id == id);
        if (note is null) return false;
        _notes.Remove(note);
        return true;
    }
}