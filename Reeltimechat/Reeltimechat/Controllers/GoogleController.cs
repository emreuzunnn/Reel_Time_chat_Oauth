using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace Reeltimechat.Controllers
{
    public class GoogleController :Controller
    {

        public IActionResult Login(string returnUrl = "/")
        {
            var redirectUrl = Url.Action("OAuthCallback", "Google", new { ReturnUrl = returnUrl });
            var properties = new AuthenticationProperties { RedirectUri = redirectUrl };
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }

        public async Task<IActionResult> OAuthCallback(string returnUrl = "/")
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            if (result.Succeeded && result.Principal != null)
            {
               
                var pass = result.Principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var email = result.Principal.FindFirst(ClaimTypes.Email)?.Value;

                dataController data=new dataController();
               if (data.usercontrol(email, pass)== "Başarısız")
                {
                    data.useradd(email, pass);
                }
                HomeController.kullanıcıadı = email;
                return RedirectToAction("mesajlar", "mesajlar");
            }

            return RedirectToAction("Login");
        }

    }
}
