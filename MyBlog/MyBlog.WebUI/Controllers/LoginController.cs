using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Data.Concrete.EfCore;
using MyBlog.Entities.Concrete;
using System.Security.Claims;

namespace MyBlog.WebUI.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            ClaimsPrincipal claims = HttpContext.User;
            if (claims.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Admin");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Author author)
        {
            using (var context = new BlogContext())
            {
                var admin = context.Authors.FirstOrDefault(x => x.Email == author.Email && x.Password == author.Password);
                if (admin != null)
                {
                    var claims = new List<Claim>
                   {
                       new Claim(ClaimTypes.Name,admin.AuthorName),
                   };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties();
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    return RedirectToAction();
                }
            }
        }
    }
}
