using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DWBooking.Model;
using DWBooking.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DWBooking.Pages.Admin.Login
{
    public class LoginPageModel : PageModel
    {
        private UserService _userService;

        public LoginPageModel(UserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public string UserName { get; set; }

        [BindProperty, DataType(DataType.Password)]
        public string Password { get; set; }

        public string Message { get; set; }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            List<User> users = _userService.Users;
            foreach (User user in users)
            {
                if (UserName == user.Username)
                {
                    var passwordHasher = new PasswordHasher<string>();
                    if (passwordHasher.VerifyHashedPassword(null, user.Password, Password) == PasswordVerificationResult.Success)
                    {
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, UserName)
                        };

                        if (UserName == "admin") claims.Add(new Claim(ClaimTypes.Role, "admin"));

                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                        return RedirectToPage("/index");
                    }
                }
            }

            Message = "Invalid attempt";
            return Page();
        }
    }
}

