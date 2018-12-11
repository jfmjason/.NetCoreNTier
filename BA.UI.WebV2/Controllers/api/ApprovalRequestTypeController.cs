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
    public class ApprovalRequestTypeController : Controller
    {
        IMasterFileService _iMasterFileService;

        public ApprovalRequestTypeController(IMasterFileService iMasterFileService) {

            _iMasterFileService = iMasterFileService;

        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<ApprovalRequestTypeVm> Get()
        {
            return _iMasterFileService.GetApprovalRequestType().toListApprovalRequestTypeVm();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ApprovalRequestTypeVm Get(int id)
        {
            return _iMasterFileService.GetApprovalRequestTypeById(id).toApprovalRequestTypeVm();
        }

        // POST api/<controller>
        [HttpPost]
        public HttpResponseMessage Post([FromBody]ApprovalRequestTypeVm value)
        {
            var entity = new ApprovalRequestType()
            {
                Name = value.Name,
                Code = value.Code,
                CreatedById = User.Identity.GetEmployeeId(),
                CreatedDate = DateTime.Now,
                Active = true
            };

            _iMasterFileService.AddApprovalRequestType(entity);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public HttpResponseMessage Put(int id, [FromBody]ApprovalRequestTypeVm value)
        {

            var entity = new ApprovalRequestType()
            {
                Id= id,
                Name = value.Name,
                Code = value.Code,
                ModifiedById = User.Identity.GetEmployeeId(),
                ModifiedDate = DateTime.Now,
            };

            _iMasterFileService.UpdateApprovalRequestType(entity);

           return new HttpResponseMessage(HttpStatusCode.OK);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public HttpResponseMessage Delete(int id)
        {
            _iMasterFileService.DeleteApprovalRequestType(id, User.Identity.GetEmployeeId());

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
