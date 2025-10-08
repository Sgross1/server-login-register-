using System;
using SERVER.Entities;
using Microsoft.EntityFrameworkCore;

namespace SERVER.Data
{
    // DbContext הוא הגשר בין קוד ה־C# לבין מסד הנתונים
    public class AppDbContext : DbContext
    {
        // בנאי שמעביר את האפשרויות (למשל סוג בסיס הנתונים, connection string)
        public AppDbContext(DbContextOptions options) : base(options) { }

        // DbSet מייצג טבלה בבסיס הנתונים
        public DbSet<AppUser> Users { get; set; }
    }
}
