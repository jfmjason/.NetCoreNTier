
using Microsoft.AspNetCore.Mvc;
using BA.UI.WebV2.Extension;
using AspNetCore.Reporting;
using BA.IService;
using Microsoft.AspNetCore.Hosting;
using BA.UI.WebV2.Models;
using System;
using System.Collections.Generic;

namespace BA.UI.WebV2.Controllers
{
    public class ReportsController : Controller
    {
        private string _reportPath = "";

        private IHostingEnvironment _env;

        private IReportService _iReportService;
        private IMasterFileService _masterFileService;

        public ReportsController(IReportService iReportService, IHostingEnvironment env, IMasterFileService masterFileService) {

            _env = env;
            _iReportService = iReportService;
            _reportPath = _env.ContentRootPath + @"\ReportFiles\";
            _masterFileService = masterFileService;

            var test = _env.WebRootFileProvider;
            var x = _env.WebRootPath;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ReleaseProcess() {
            if (Request.IsAjaxRequest())
                return PartialView();

            return View();
        }

        public IActionResult ReleaseProcessList()
        {
            if (Request.IsAjaxRequest())
                return PartialView();

            return View();
        }


        public IActionResult ReleaseProcessToPDF(DateTime from , DateTime to)
        {
            var rdlpath = _reportPath + "ReleaseProcess.rdl";
            var reportData = _iReportService.GetApprovalRequestProcessReleases(from, to).toRPTReleaseProcessVm();
            var branch = _masterFileService.GetOrganisationDetailById(1);

            var param = new Dictionary<string, string>()
            {
                { "fromdate" , from.ToString("MMMM d, yyyy") },
                { "todate" , to.ToString("MMMM d, yyyy") },
                { "branch" , branch.Name + " - " + branch.City },
                { "printedby" , User.Identity.Name }
            };

            var localrep = new LocalReport(rdlpath);
            localrep.AddDataSource("DataSet1", reportData);

            return new FileStreamResult(
                localrep.ExecuteToMemoryStreamResult(RenderType.Pdf,1,param, null)
                , "application/pdf"
            );
        }


        public IActionResult TestIframe()
        {
            return View();
        }


        public IActionResult PrintPreview([FromQuery] PrintPreviewVm vm) {
            return View(vm);
        }
    }
}
