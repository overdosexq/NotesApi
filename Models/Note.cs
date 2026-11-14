namespace NoteApi.Models;

public class Note
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreatedAt { get; set; } =  DateTime.UtcNow;
    
    public string Title { get; set; } = "";
    public string Content { get; set; } = "";

    public Note(string title, string content)
    {
        Title = title;
        Content = content;
    }
}