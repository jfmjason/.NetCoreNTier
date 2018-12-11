
using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;
using BA.UI.WebV2.Models;
using Microsoft.AspNetCore.Authorization;
using BA.UI.WebV2.Extension;
using BA.IService;

namespace BA.UI.WebV2.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
       
            if (Request.IsAjaxRequest())
            {
                return PartialView();
            }

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
