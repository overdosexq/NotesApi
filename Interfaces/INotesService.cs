using NoteApi.DTOs;
using NoteApi.Models;

namespace NoteApi.Interfaces;

public interface INotesService
{
    Note Create(string title, string content);
    Note? GetById(Guid id);
    IEnumerable<Note>? GetAll();
    
    bool Delete(Guid id);
}