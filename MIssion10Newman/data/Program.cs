using Microsoft.EntityFrameworkCore;
using MIssion10Newman.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Add DbContext using SQLite (already there)
builder.Services.AddDbContext<BowlingLeagueContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("BowlingConnection")));

// ADD THIS CORS BLOCK:
builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// ADD THIS LINE (CORS must come before UseAuthorization):
app.UseCors("ReactPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
