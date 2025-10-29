using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Pie API",
        Version = "v1",
        Description = "A minimal API for managing pies",
    });
});

// In-memory pie list for simplicity
var pies = new List<Pie>
{
    new Pie(1, "Apple Pie", "A classic apple pie with cinnamon.", 12.99m),
    new Pie(2, "Cherry Pie", "Sweet cherry filling with a flaky crust.", 14.99m),
    new Pie(3, "Pumpkin Pie", "A spiced pumpkin pie perfect for autumn.", 11.99m)
};

var app = builder.Build();

// Configure Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Pie API v1");
        options.RoutePrefix = string.Empty; // Makes Swagger UI the home page
    });
}

app.UseHttpsRedirection();

// Get all pies
app.MapGet("/pies", () => Results.Ok(pies))
   .WithName("GetAllPies")
   .WithDescription("Gets all pies")
   .WithOpenApi();

// Get a pie by ID
app.MapGet("/pies/{id:int}", (int id) =>
{
    var pie = pies.FirstOrDefault(p => p.Id == id);
    return pie is not null ? Results.Ok(pie) : Results.NotFound($"Pie with ID {id} not found.");
})
.WithName("GetPieById")
.WithDescription("Gets a pie by ID")
.WithOpenApi();

// Add a new pie
app.MapPost("/pies", (Pie newPie) =>
{
    if (pies.Any(p => p.Id == newPie.Id))
    {
        return Results.Conflict($"A pie with ID {newPie.Id} already exists.");
    }

    pies.Add(newPie);
    return Results.Created($"/pies/{newPie.Id}", newPie);
})
.WithName("AddPie")
.WithDescription("Adds a pie")
.WithOpenApi();

// Update an existing pie
app.MapPut("/pies/{id:int}", (int id, Pie updatedPie) =>
{
    var index = pies.FindIndex(p => p.Id == id);
    if (index == -1)
    {
        return Results.NotFound($"Pie with ID {id} not found.");
    }

    pies[index] = updatedPie;
    return Results.NoContent();
})
.WithName("UpdatePie")
.WithDescription("Updates a pie")
.WithOpenApi();

// Delete a pie
app.MapDelete("/pies/{id:int}", (int id) =>
{
    var pie = pies.FirstOrDefault(p => p.Id == id);
    if (pie is null)
    {
        return Results.NotFound($"Pie with ID {id} not found.");
    }

    pies.Remove(pie);
    return Results.NoContent();
})
.WithName("DeletePie")
.WithDescription("Deletes a pie")
.WithOpenApi();

app.Run();

internal record Pie(int Id, string Name, string Description, decimal Price);
