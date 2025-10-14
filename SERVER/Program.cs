    using Microsoft.EntityFrameworkCore;
using SERVER.Data;
var builder = WebApplication.CreateBuilder(args);

// מוסיפים DbContext עם InMemory Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("MyDb"));

// מוסיפים שירותי Controllers
builder.Services.AddControllers();

// הוספת CORS כדי לאפשר לקוח לגשת לשרת
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowClient", policy =>
    {
        policy.AllowAnyOrigin()       // מאפשר מכל מקור (לפיתוח)
              .AllowAnyMethod()       // מאפשר כל HTTP method (GET, POST, וכו')
              .AllowAnyHeader();      // מאפשר כל header
    });
});

var app = builder.Build();

// שימוש ב-CORS
app.UseCors("AllowClient");

app.MapControllers(); // מיפוי כל הקונטרולרים

app.Run(); // מפעיל את השרת
