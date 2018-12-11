using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BA.IService;
using BA.UI.WebV2.Extension;
using BA.UI.WebV2.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BA.UI.WebV2.Controllers.api
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private IMasterFileService _iMasterFileService;

        public EmployeeController(IMasterFileService iMasterFileService) {

            _iMasterFileService = iMasterFileService;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<EmployeeVm> Get()
        {
            return _iMasterFileService.GetEmployees().toListEmployeeVM();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public EmployeeVm Get(int id)
        {
            return _iMasterFileService.GetEmployeeById(id).toEmployeeVM();
        }

        [HttpGet("search/{term}/{pagesize?}")]
        public IEnumerable<EmployeeVm> Get(string term, int? pagesize = 50)
        {
            return _iMasterFileService.SearchEmployee(term, pagesize.Value).toListEmployeeVM();
        }



        [HttpGet("pagedsearch")]
        public PagedList<EmployeeVm> Get(string term, int page, int pagesize = 50)
        {
            int recordCount = 0;

            var data = _iMasterFileService.PagedSearchEmployee(term,pagesize,page, out recordCount).toListEmployeeVM();

            return new PagedList<EmployeeVm>()
            {
                Data = data as List<EmployeeVm>,
                Page = page,
                Pagesize = pagesize,
                Recordcount = recordCount
            };
        }


        [HttpGet("doctor/search/{term?}")]
        public PagedList<EmployeeVm> SearchDoctors(string term, int page, int pagesize = 50)
        {
            int recordCount = 0;

            var data = _iMasterFileService.PagedSearchDoctors(term, pagesize, page, out recordCount).toListEmployeeVM();

            return new PagedList<EmployeeVm>()
            {
                Data = data as List<EmployeeVm>,
                Page = page,
                Pagesize = pagesize,
                Recordcount = recordCount
            };
        }
    }
}
