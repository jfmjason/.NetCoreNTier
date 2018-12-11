using BA.IService;
using BA.UI.WebV2.Extension;
using BA.UI.WebV2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace BA.UI.WebV2.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class PatientController : Controller
    {
        IMasterFileService _imasterFileService;

        public PatientController(IMasterFileService imasterFileService) {

            _imasterFileService = imasterFileService;

        }

        // GET: api/<controller>/current
        [HttpGet]
        public IEnumerable<PatientVm> Get()
        {
            return _imasterFileService.GetPatients().toListPatientVm();
        }

        // GET: api/<controller>/dispatched
        [HttpGet("registrationno/{registrationno}")]
        public PatientVm GetByRegistration(int registrationno)
        {
            return _imasterFileService.GetPatientByRegistrationNo(registrationno).toPatientVm();
        }

        [HttpGet("pagedsearch/{term?}")]
        public PagedList<PatientVm> PagedSearch(string term ="", int page =1, int pagesize = 50)
        {
            int recordCount = 0;

            var data = _imasterFileService.PagedSearchPatientsByRegistrationNo(term, pagesize, page, out recordCount).toListPatientVm();

            return new PagedList<PatientVm>()
            {
                Data = data as List<PatientVm>,
                Page = page,
                Pagesize = pagesize,
                Recordcount = recordCount
            };
        }

    }
}
