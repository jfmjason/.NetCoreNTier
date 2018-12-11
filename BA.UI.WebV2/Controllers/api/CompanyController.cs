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
    public class CompanyController : Controller
    {
        private IMasterFileService _iMasterFileService;

        public CompanyController(IMasterFileService iMasterFileService) {

            _iMasterFileService = iMasterFileService;
        }

        [HttpGet]
        public IEnumerable<CompanyVm> Get()
        {
            return _iMasterFileService.GetCompanies().toListCompanyVm();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public CompanyVm Get(int id)
        {
             return _iMasterFileService.GetCompanyById(id).toCompanyVm();
        }

        [HttpGet("search/term/{term}/page/{page}/pagesize/{pagesize}")]
        public PagedList<CompanyVm> PagedSearch(string term, int page, int pagesize = 50)
        {
            int recordCount = 0;

            var data = _iMasterFileService.PagedSearchCompanies(term, pagesize, page, out recordCount);

            return new PagedList<CompanyVm>()
            {
                Data = data as List<CompanyVm>,
                Page = page,
                Pagesize = pagesize,
                Recordcount = recordCount
            };

        }

 }
}
