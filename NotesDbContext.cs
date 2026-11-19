using Microsoft.EntityFrameworkCore;
using NoteApi.Models;

namespace NoteApi;

public class NotesDbContext : DbContext
{
    public NotesDbContext(DbContextOptions<NotesDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<Note> Notes => Set<Note>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Note>()
            .Property(n => n.Title)
            .HasMaxLength(50)
            .IsRequired();
        modelBuilder.Entity<Note>()
            .Property(n => n.Content)
            .HasMaxLength(100)
            .IsRequired();
        
    }
}