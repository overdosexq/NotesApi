using Microsoft.EntityFrameworkCore;
using NoteApi;
using NoteApi.Interfaces;
using NoteApi.Repositories;
using NoteApi.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddOpenApi();
builder.Services.AddControllers();

builder.Services.AddScoped<INotesService, NotesService>();

builder.Services.AddDbContext<NotesDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("NotesDb")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "NoteApi v1");
    });
}
app.UseHttpsRedirection();
app.MapControllers();


app.Run();
