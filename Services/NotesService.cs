using NoteApi.Interfaces;
using NoteApi.Models;

namespace NoteApi.Services;

public class NotesService : INotesService
{
    INotesRepository _notesRepository;

    public NotesService(INotesRepository notesRepository)
    {
        _notesRepository = notesRepository;
    }

    public Note Create(string title, string content)
    {
        return _notesRepository.Create(new Note(title, content));
    }

    public Note? GetById(Guid id)
    {
        return _notesRepository.GetById(id);
    }
    
    public IEnumerable<Note>? GetAll()
    {
        return _notesRepository.GetAll();
    }
}