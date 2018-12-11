using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BA.Core.Entity;
using BA.IService;
using BA.UI.WebV2.Extension;
using BA.UI.WebV2.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BA.UI.WebV2.Controllers.api
{
    [Route("api/[controller]")]
    public class OPBServiceController : Controller
    {
        private IMasterFileService _imasterFileService;
        private IMapper _imapper;
        public OPBServiceController(IMasterFileService imasterFileService, IMapper imapper)
        {
            _imasterFileService = imasterFileService;
            _imapper = imapper;
        }

        // GET: api/<controller>/pagedsearch
        [HttpGet]
        public List<ServiceVm> Get()
        {
            var services = _imasterFileService.GetOPBServices();
           return _imapper.Map<List<ServiceVm>>(services);
        }

       

    }
}
