using ApiClient.Controllers;
using Data;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.SetMinimumLevel(LogLevel.Information);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
builder.Services.AddScoped<StudentsController>();
builder.Services.AddHttpClient();

var app = builder.Build();

var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

var studentController = services.GetRequiredService<StudentsController>();
var result = await studentController.GetAllStudents();

if (result is OkObjectResult okResult)
{
    var students = okResult.Value as List<Student>;
    if (students != null)
    {
        foreach (var student in students)
        {
            Console.WriteLine(student);
        }
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
