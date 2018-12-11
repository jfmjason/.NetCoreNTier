
using System.Collections.Generic;
using AutoMapper;
using BA.Core.Entity;
using BA.IService;
using BA.UI.WebV2.Models;
using Microsoft.AspNetCore.Mvc;

namespace BA.UI.WebV2.Controllers.api
{
    [Route("api/[controller]")]
    public class OpCompanyBillDetailController : Controller
    {
        private readonly IMapper _mapper;
        IOPBillService _iopBillService;

        public OpCompanyBillDetailController(IOPBillService iopBillService, IMapper mapper)
        {

            _iopBillService = iopBillService;

            _mapper = mapper;
        }

         // GET: api/<controller>
         [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/latest/registrationno/4654646
        [HttpGet("latest/registrationno/{registrationNo}")]
        public OpCompanyBillDetailVm GetLatest(int registrationNo)
        {
            var billdetail = _iopBillService.GetLatestOPCompanyBillDetail(registrationNo);

            return _mapper.Map<OpCompanyBillDetailVm>(billdetail); ;
        }

    }
}
