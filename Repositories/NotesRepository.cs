using NoteApi.Interfaces;
using NoteApi.Models;

namespace NoteApi.Repositories;

public class NotesRepository : INotesRepository
{
    private readonly List<Note> _notes = new()
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
        return _notes.FirstOrDefault(note => note.Id == id);
    }

    public Note Create(Note note)
    {
        _notes.Add(note);
        return note;
    }
    
    public bool Delete(Guid id)
    {
        var note = GetById(id);
        if (note is null) return false;
        _notes.Remove(note);
        return true;
    }

    public Note? Put(Guid id, Note noteToUpdate)
    {
        var note = GetById(id);
        if (note is null) return note;

        note.Title = noteToUpdate.Title;
        note.Content = noteToUpdate.Content;
        return note;
    }

    public Note? Patch(Guid id, string? title, string? content)
    {
        var note = GetById(id);
        if (note is null) return note;
        
        if (title is not null) note.Title = title;
        if (content is not null) note.Content = content;
        return note;
    }
}