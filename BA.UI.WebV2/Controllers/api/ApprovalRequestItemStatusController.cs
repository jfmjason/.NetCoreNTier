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
    public class ApprovalRequestItemStatusController : Controller
    {
        IMasterFileService _iMasterFileService;

        public ApprovalRequestItemStatusController(IMasterFileService iMasterFileService) {

            _iMasterFileService = iMasterFileService;

        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<ApprovalRequestItemStatusVm> Get()
        {
            return _iMasterFileService.GetApprovalRequestItemStatus().toListApprovalRequestItemStatusVm();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ApprovalRequestItemStatusVm Get(int id)
        {
            return _iMasterFileService.GetApprovalRequestItemStatusById(id).toApprovalRequestItemStatusVm();
        }

        // POST api/<controller>
        [HttpPost]
        public HttpResponseMessage Post([FromBody]ApprovalRequestItemStatusVm value)
        {
            var entity = new ApprovalRequestItemStatus()
            {
                Name = value.Name,
                Code = value.Code,
                CreatedById = User.Identity.GetEmployeeId(),
                CreatedDate = DateTime.Now,
                Active = true
            };

            _iMasterFileService.AddApprovalRequestItemStatus(entity);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public HttpResponseMessage Put(int id, [FromBody]ApprovalRequestItemStatusVm value)
        {

            var entity = new ApprovalRequestItemStatus()
            {
                Id= id,
                Name = value.Name,
                Code = value.Code,
                ModifiedById = User.Identity.GetEmployeeId(),
                ModifiedDate = DateTime.Now,
            };

            _iMasterFileService.UpdateApprovalRequestItemStatus(entity);

           return new HttpResponseMessage(HttpStatusCode.OK);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public HttpResponseMessage Delete(int id)
        {
            _iMasterFileService.DeleteApprovalRequestItemStatus(id, User.Identity.GetEmployeeId());

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
