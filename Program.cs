using NoteApi.Interfaces;
using NoteApi.Repositories;
using NoteApi.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddOpenApi();
builder.Services.AddControllers();

builder.Services.AddSingleton<INotesRepository, NotesRepository>();
builder.Services.AddScoped<INotesService, NotesService>();

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
