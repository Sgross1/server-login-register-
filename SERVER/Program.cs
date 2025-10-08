    using Microsoft.EntityFrameworkCore;
using SERVER.Data;
var builder = WebApplication.CreateBuilder(args);

// מוסיפים DbContext עם InMemory Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("MyDb"));

// מוסיפים שירותי Controllers
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers(); // מיפוי כל הקונטרולרים

app.Run(); // מפעיל את השרת

/*var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();*/
