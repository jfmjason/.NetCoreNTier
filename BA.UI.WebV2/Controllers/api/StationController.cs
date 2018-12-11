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
    public class StationController : Controller
    {
        private IMasterFileService _iMasterFileService;

        public StationController(IMasterFileService iMasterFileService) {

            _iMasterFileService = iMasterFileService;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<StationVm> Get()
        {
            return _iMasterFileService.GetStations().toListStationVm();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public StationVm Get(int id)
        {
            return _iMasterFileService.GetStationById(id).toStationVm();
        }

        [HttpGet("search/{term}/{pagesize?}")]
        public IEnumerable<StationVm> Get(string term, int? pagesize = 50)
        {
            return _iMasterFileService.SearchStation(term, pagesize.Value).toListStationVm();
        }

        [HttpGet("pagedsearch")]
        public PagedList<StationVm> Get(string term, int page, int pagesize = 50)
        {
            int recordCount = 0;

            var data = _iMasterFileService.PagedSearchStation(term,pagesize,page, out recordCount).toListStationVm();

            return new PagedList<StationVm>()
            {
                Data = data as List<StationVm>,
                Page = page,
                Pagesize = pagesize,
                Recordcount = recordCount
            };
        }
    }
}
