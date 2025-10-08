using System;
using SERVER.Data;
using SERVER.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SERVER.Controllers
{
    // מגדיר שהקונטרולר הזה מחזיר תשובות JSON ל־API
    [ApiController]
    [Route("api/[controller]")] // הנתיב יהיה api/members
    public class MembersController : ControllerBase
    {
        private readonly AppDbContext _context; // גישה ל־DbContext

        // הזרקה של ה־DbContext ע"י ה־framework
        public MembersController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/members/register
        [HttpPost("register")]
        public async Task<ActionResult<AppUser>> Register([FromBody] AppUser user)
        {
            // בדיקה אם כבר קיים משתמש עם אותו שם
            if (await _context.Users.AnyAsync(x => x.UserName == user.UserName))
                return BadRequest("Username already taken");

            // הוספה של המשתמש החדש
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // החזרה של המשתמש החדש ללקוח
            return Ok(user);
        }

        // POST: api/members/login
        [HttpPost("login")]
        public async Task<ActionResult<AppUser>> Login([FromBody] AppUser loginData)
        {
            // חיפוש משתמש עם שם וסיסמה תואמים
            var user = await _context.Users
                .SingleOrDefaultAsync(x => x.UserName == loginData.UserName && x.Password == loginData.Password);

            // אם לא נמצא משתמש → החזרה של שגיאה
            if (user == null) return Unauthorized("Invalid username or password");

            // אם הצליח → החזרת פרטי המשתמש
            return Ok(user);
        }
    }
}

