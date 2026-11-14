using System.ComponentModel.DataAnnotations;

namespace NoteApi.DTOs;

public class CreateNoteRequest
{
    [MaxLength(50)]
    [Required]
    public string Title { get; set; } = "";
    
    [MaxLength(100)]
    [Required]
    public string Content { get; set; } = "";
}