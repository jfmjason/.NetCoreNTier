using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BA.IService;
using BA.UI.WebV2.Extension;
using BA.UI.WebV2.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BA.UI.WebV2.Controllers.api
{
    [Route("api/[controller]")]
    public class UnitController : Controller
    {
        private IMasterFileService _iMasterFileService;
        private IMapper _imapper;

        public UnitController(IMasterFileService iMasterFileService, IMapper imapper) {

            _iMasterFileService = iMasterFileService;
            _imapper = imapper;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<UnitVm> Get()
        {
            return _imapper.Map<IEnumerable<UnitVm>>(_iMasterFileService.GetUnits());
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public UnitVm Get(int id)
        {
            return _imapper.Map<UnitVm>(_iMasterFileService.GetUnitById(id));
        }

       
    }
}
