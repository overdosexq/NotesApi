using System.ComponentModel.DataAnnotations;

namespace NoteApi.DTOs;

public class PutNoteRequest
{
    [MaxLength(50)]
    [Required]
    public string Title { get; set; } = "";

    [MaxLength(100)]
    [Required]
    public string Content { get; set; } = "";
}