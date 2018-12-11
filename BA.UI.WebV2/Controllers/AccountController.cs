using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BA.UI.WebV2.Common;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BA.UI.WebV2.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            HttpContext.Response.Cookies.Delete(Global.Configuration["Authentication:AuthCookieName"]);

            return Redirect(Global.Configuration["Authentication:LoginUri"]);
        }
    }
}