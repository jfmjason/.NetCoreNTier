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
    public class GradeController : Controller
    {
        private IMasterFileService _iMasterFileService;

        public GradeController(IMasterFileService iMasterFileService) {

            _iMasterFileService = iMasterFileService;
        }

        [HttpGet]
        public IEnumerable<GradeVm> Get()
        {
            return _iMasterFileService.GetGrades().toListGradeVm();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public GradeVm Get(int id)
        {
             return _iMasterFileService.GetGradeById(id).toGradeVm();
        }

        [HttpGet("search/term/{term}/page/{page}/pagesize/{pagesize}")]
        public PagedList<GradeVm> PagedSearch(string term, int page, int pagesize = 50)
        {
            int recordCount = 0;

            var data = _iMasterFileService.PagedSearchGrades(term, pagesize, page, out recordCount);

            return new PagedList<GradeVm>()
            {
                Data = data as List<GradeVm>,
                Page = page,
                Pagesize = pagesize,
                Recordcount = recordCount
            };

        }

 }
}
