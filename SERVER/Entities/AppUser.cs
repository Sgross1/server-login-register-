using System;

namespace SERVER.Entities;

public class AppUser
{
   public int Id { get; set; } // מפתח ראשי (Primary Key)
        public string UserName { get; set; } = string.Empty; // שם משתמש
        public string Password { get; set; } = string.Empty; // סיסמה (בדוגמה פשוטה נשמרת כטקסט)
}
