
using System.Collections.Generic;

using BA.IService;
using BA.UI.WebV2.Extension;
using BA.UI.WebV2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace BA.UI.WebV2.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        IMasterFileService _iMasterFileService;

        public CategoryController(IMasterFileService iMasterFileService) {

            _iMasterFileService = iMasterFileService;

        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<CategoryVm> Get()
        {
            return _iMasterFileService.GetCategories().toListCategoryVm();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public CategoryVm Get(int id)
        {
            return _iMasterFileService.GetCategoryById(id).toCategoryVm();
        }

        [HttpGet("search/{term}/{pagesize?}")]
        public IEnumerable<CategoryVm> Get(string term, int? pagesize =50)
        {
            return _iMasterFileService.SearchCategories(term, pagesize.Value).toListCategoryVm();
        }


    }
}
