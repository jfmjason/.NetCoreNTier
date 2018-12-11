using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using AutoMapper;
using BA.Core.Entity;
using BA.Core.Entity.data;
using BA.IService;
using BA.UI.WebV2.Extension;
using BA.UI.WebV2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PatientType = BA.Core.Entity.data.PatientType;

namespace BA.UI.WebV2.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class ReleaseApprovalController : Controller
    {
        IReportService _ireportservice;
        IMapper _imapper;
        public ReleaseApprovalController(IReportService ireportservice, IMapper imapper) {

            _ireportservice = ireportservice;

            _imapper = imapper;
        }

        [HttpGet("{fromdate}/{todate}/{releasebyId?}")]
        public IEnumerable<RPTReleaseProcessVm> Get(DateTime fromdate, DateTime todate, int? releasebyId)
        {
            var release = _ireportservice.GetApprovalRequestProcessReleases(fromdate, todate.AddDays(1), releasebyId).toRPTReleaseProcessVm();

            return _imapper.Map<List<RPTReleaseProcessVm>>(release);
        }

      

    }


   
}
