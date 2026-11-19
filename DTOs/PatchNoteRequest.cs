using System.ComponentModel.DataAnnotations;

namespace NoteApi.DTOs;

public class PatchNoteRequest
{
    [MaxLength(50)]
    public string? Title { get; set; }

    [MaxLength(100)]
    public string? Content { get; set; }
}