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
    public class InpatientController : Controller
    {
        IInpatientService _iInpatientService;

        public InpatientController(IInpatientService iInpatientService) {

            _iInpatientService = iInpatientService;

        }

        // GET: api/<controller>/current
        [HttpGet("current")]
        public IEnumerable<InpatientVm> GetCurrent()
        {
            return _iInpatientService.GetAllCurrentInpatients().toListInpatientVm();
        }

        // GET: api/<controller>/dispatched
        [HttpGet("dispatched")]
        public IEnumerable<InpatientVm> GetDispatched()
        {
            return _iInpatientService.GetAllOldInpatients().toListInpatientVm();
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<InpatientVm> Get()
        {
            var dispatched = _iInpatientService.GetAllOldInpatients().toListInpatientVm();
            var current  = _iInpatientService.GetAllCurrentInpatients().toListInpatientVm();

            dispatched.AddRange(current);

            return dispatched;
        }

        [HttpGet("ipid/{ipid}")]
        public InpatientVm GetByIpId(int ipid)
        {  
            var current = _iInpatientService.GetCurrentInPatientByIpId(ipid).toInpatientVm();

            return current.IPId > 0? current : _iInpatientService.GetOldInPatientByIpId(ipid).toInpatientVm();
        }

        [HttpGet("registrationno/{registrationNo}")]
        public InpatientVm GetByRegistrationNo(int registrationNo)
        {
            var current = _iInpatientService.GetCurrentInPatientByRegno(registrationNo).toInpatientVm();

            return current.IPId > 0 ? current : _iInpatientService.GetOldInPatientByRegno(registrationNo).toInpatientVm();
        }

    }
}
