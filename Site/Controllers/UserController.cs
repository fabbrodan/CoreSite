using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Site.Models;

namespace Site.Controllers
{
    [Consumes("application/x-www-form-urlencoded")]
    public class UserController : Controller
    {
        private readonly SiteDBContext _context;

        public UserController(SiteDBContext context)
        {
            this._context = context;
        }

        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> New(Users user)
        {
            SecurePassword psw = new SecurePassword();
            string PasswordSalt = psw.RandomSalt;
            string UserPassword = psw.GenerateSaltedHash(user.Password);

            await _context.Users.AddAsync(new Users
            {
                UserName = user.UserName,
                Email = user.Email,
                Password = UserPassword,
                PasswordSalt = PasswordSalt
            });

            await _context.SaveChangesAsync();

            return CreatedAtAction("Post", user);
        }

        [HttpPost]
        [Route("Verify")]
        public async Task<IActionResult> Verify(Users user)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(500, "Not a valid model");
            }

            SecurePassword psw = new SecurePassword();
            string submittedUserName = user.UserName;
            string submittedPassword = user.Password;
            try
            {
                Users userToVerify = await _context.Users.FirstOrDefaultAsync<Users>(u => u.UserName == user.UserName);
                if (user == null)
                {
                    return NoContent();
                }

                if (psw.VerifyPassword(submittedPassword, userToVerify.PasswordSalt, userToVerify.Password))
                {
                    HttpContext.Session.Set("Authenticated", new byte[1] { 1 });
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            
            return RedirectToAction("Index", "Home");
        }
    }
}