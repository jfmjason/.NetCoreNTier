using BA.UI.WebV2.Extension;
using Microsoft.AspNetCore.Mvc;

namespace BA.UI.WebV2.Controllers
{
    public class MasterFileController : Controller
    {
      
        public IActionResult ApprovalRequestItemStatus()
        {
            if (Request.IsAjaxRequest())
                return PartialView();

            return View();
        }


        public IActionResult ApprovalRequestStatus()
        {
            if (Request.IsAjaxRequest())
                return PartialView();

            return View();
        }

        public IActionResult ApprovalRequestType()
        {
            if (Request.IsAjaxRequest())
                return PartialView();

            return View();
        }

        public IActionResult PatientType()
        {
            if (Request.IsAjaxRequest())
                return PartialView();

            return View();
        }

    }
}
