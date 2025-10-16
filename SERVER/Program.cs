    using Microsoft.EntityFrameworkCore;
using SERVER.Data;
var builder = WebApplication.CreateBuilder(args);

// קונפיגורציית DbContext: שימוש ב‑SQLite עם מחרוזת חיבור מהגדרות
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(connectionString));

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

// יצירת/הכנת DB במעלית כדי למנוע cold-start איטי של EF
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

// שימוש ב-CORS
app.UseCors("AllowClient");

app.MapControllers(); // מיפוי כל הקונטרולרים

app.Run(); // מפעיל את השרת
