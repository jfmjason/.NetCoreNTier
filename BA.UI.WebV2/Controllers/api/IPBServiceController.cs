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
    public class IPBServiceController : Controller
    {
        private IMasterFileService _masterFileService;
        private IMapper _imapper;


        public IPBServiceController(IMasterFileService masterFileService , IMapper imapper)
        {
            _masterFileService = masterFileService;
            _imapper = imapper;
        }

        // GET: api/<controller>/pagedsearch
        [HttpGet]
        public List<ServiceVm> Get()
        {
            var services = _masterFileService.GetIPBServices();

            return _imapper.Map<List<ServiceVm>>(services); 
        }

       

    }
}
