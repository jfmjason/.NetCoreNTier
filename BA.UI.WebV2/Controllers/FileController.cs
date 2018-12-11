using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BA.UI.WebV2.Extension;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace BA.UI.WebV2.Controllers
{
    [Authorize]
    public class FileController : Controller
    {
        public IActionResult ApprovalRequest()
        {
            if (Request.IsAjaxRequest())
                return PartialView();

            return View();
        }
        [Route("/[controller]/ApprovalRequest/{id}")]
        public IActionResult ApprovalRequestDetail(int id)
        {
            ViewBag.RequestId = id;
            ViewBag.CurrentUserId = User.Identity.GetEmployeeId();

            if (Request.IsAjaxRequest())
                return PartialView();

            return View();
        }

        [Route("/[controller]/approvalrequest/list")]
        public IActionResult ApprovalRequestList()
        {
            if (Request.IsAjaxRequest())
                return PartialView();

            return View();
        }

        [Route("/[controller]/ApprovalRequest/Update/{id}")]
        public IActionResult ApprovalRequestUpdate(int id)
        {
            ViewBag.RequestId = id;
            ViewBag.CurrentUserId = User.Identity.GetEmployeeId();

            if (Request.IsAjaxRequest())
                return PartialView();

            return View();
        }


        [Route("/[controller]/ApprovalRequest/Create")]
        public IActionResult ApprovalRequestCreate()
        {
            if (Request.IsAjaxRequest())
                return PartialView();

            return View();
        }

        [Route("/[controller]/ApprovalRequest/Release")]
        public IActionResult ApprovalRequestRelease()
        {
            if (Request.IsAjaxRequest())
                return PartialView();

            return View();
        }
    }
}
