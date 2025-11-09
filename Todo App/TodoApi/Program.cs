using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TodoApi.Services;
using TodoApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<TodoRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

var corsPolicyName = "AllowAngular";
builder.Services.AddCors(options =>
{
    options.AddPolicy(corsPolicyName, policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors(corsPolicyName);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/todos", (TodoRepository repo) =>
{
    return Results.Ok(repo.GetAll());
});

app.MapPost("/api/todos", (TodoRepository repo, TodoItem item) =>
{
    if (string.IsNullOrWhiteSpace(item.Title))
        return Results.BadRequest("Title is required");

    var created = repo.Add(item.Title);
    return Results.Created($"/api/todos/{created.Id}", created);
});

app.MapPost("/api/todos/{id:int}/toggle", (TodoRepository repo, int id) =>
{
    var updated = repo.ToggleDone(id);
    return updated is null ? Results.NotFound() : Results.Ok(updated);
});

app.MapDelete("/api/todos/{id:int}", (TodoRepository repo, int id) =>
{
    var ok = repo.Delete(id);
    return ok ? Results.NoContent() : Results.NotFound();
});

app.Run();