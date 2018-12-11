using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BA.Core.Entity;
using BA.IService;
using BA.UI.WebV2.Extension;
using BA.UI.WebV2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace BA.UI.WebV2.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class ApprovalRequestStatusController : Controller
    {
        IMasterFileService _iMasterFileService;

        public ApprovalRequestStatusController(IMasterFileService iMasterFileService) {

            _iMasterFileService = iMasterFileService;

        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<ApprovalRequestStatusVm> Get()
        {
            return _iMasterFileService.GetApprovalRequestStatus().toListApprovalRequestStatusVm();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ApprovalRequestStatusVm Get(int id)
        {
            return _iMasterFileService.GetApprovalRequestStatusById(id).toApprovalRequestStatusVm();
        }

        // POST api/<controller>
        [HttpPost]
        public HttpResponseMessage Post([FromBody]ApprovalRequestStatusVm value)
        {
            var entity = new ApprovalRequestStatus()
            {
                Name = value.Name,
                Code = value.Code,
                CreatedById = User.Identity.GetEmployeeId(),
                CreatedDate = DateTime.Now,
                Active = true
            };

            _iMasterFileService.AddApprovalRequestStatus(entity);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public HttpResponseMessage Put(int id, [FromBody]ApprovalRequestStatusVm value)
        {

            var entity = new ApprovalRequestStatus()
            {
                Id= id,
                Name = value.Name,
                Code = value.Code,
                ModifiedById = User.Identity.GetEmployeeId(),
                ModifiedDate = DateTime.Now,
            };

            _iMasterFileService.UpdateApprovalRequestStatus(entity);

           return new HttpResponseMessage(HttpStatusCode.OK);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public HttpResponseMessage Delete(int id)
        {
            _iMasterFileService.DeleteApprovalRequestStatus(id, User.Identity.GetEmployeeId());

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
