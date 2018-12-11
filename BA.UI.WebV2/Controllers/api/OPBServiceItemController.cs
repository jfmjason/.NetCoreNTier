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
    public class OPBServiceItemController : Controller
    {
        private IMasterFileService _masterFileService;
        private IMapper _imapper;

        public OPBServiceItemController(IMasterFileService masterFileService, IMapper imapper) {
            _masterFileService = masterFileService;
            _imapper = imapper;
        }

        // GET: api/<controller>/pagedsearch
        [HttpGet("pagedsearch")]
        public PagedList<ServiceItemVm> Get(string mastertable, string term, int page, int pagesize = 50)
        {
            int recordCount = 0;

            var data = getServiceItems(mastertable, term, pagesize, page, out recordCount);

            return new PagedList<ServiceItemVm>()
            {
                Data = data as List<ServiceItemVm>,
                Page = page,
                Pagesize = pagesize,
                Recordcount = recordCount
            };
        }

        [HttpGet("getprice/item/{itemid}/tariff/{tariffid}/pricetable/{pricetable}")]
        public ServiceItemPriceVm GetPrice(int itemid, int tariffid, string pricetable)
        {
            var itemprice = _masterFileService.GetOPServiceItemPrice(itemid, tariffid, pricetable);

            return _imapper.Map<ServiceItemPriceVm>(itemprice);
        }

        private List<ServiceItemVm> getServiceItems(string mastertable, string term, int pagesize, int page, out int recordCount) {
            var serviceItems = new List<ServiceItemVm>();
            recordCount = 0;

            switch (mastertable.ToLower()){
                case "bbotherorocedures":
                    serviceItems = _masterFileService.PagedSearchBBOtherProcedures(term, pagesize, page, out recordCount).toListServiceItemVm();
                    break;
                case "bloodcomponent":
                    serviceItems = _masterFileService.PagedSearchBloodComponent(term, pagesize, page, out recordCount).toListServiceItemVm();
                    break;
                case "bloodcrossmatch":
                    serviceItems = _masterFileService.PagedSearchBloodCrossMatchComponent(term, pagesize, page, out recordCount).toListServiceItemVm();
                    break;
                case "blooddonationmaster":
                    serviceItems = _masterFileService.PagedSearchBloodDonationMasterComponent(term, pagesize, page, out recordCount).toListServiceItemVm();
                    break;
                case "bloodissuemaster":
                    serviceItems = _masterFileService.PagedSearchBloodIssueMasterComponent(term, pagesize, page, out recordCount).toListServiceItemVm();
                    break;
                case "cathprocedure":
                    serviceItems = _masterFileService.PagedSearchCathProcedures(term, pagesize, page, out recordCount).toListServiceItemVm();
                    break;
                case "doctor":
                    serviceItems = _masterFileService.PagedSearchDoctors(term, pagesize, page, out recordCount).toListServiceItemVm();
                    break;
                case "fooditem":
                    serviceItems = _masterFileService.PagedSearchFoodItems(term, pagesize, page, out recordCount).toListServiceItemVm();
                    break;
                case "healthcheckup":
                    serviceItems = _masterFileService.PagedSearchHealthCheckUps(term, pagesize, page, out recordCount).toListServiceItemVm();
                    break;
                case "item":
                    serviceItems = _masterFileService.PagedSearchItems(term, pagesize, page, out recordCount).toListServiceItemVm();
                    break;
                case "otherprocedures":
                    serviceItems = _masterFileService.PagedSearchOtherProcedures(term, pagesize, page, out recordCount).toListServiceItemVm();
                    break;
                case "patient":
                    serviceItems = _masterFileService.PagedSearchPatients(term, pagesize, page, out recordCount).toListServiceItemVm();
                    break;
                case "physiotherapy":
                    serviceItems = _masterFileService.PagedSearchPTProcedures(term, pagesize, page, out recordCount).toListServiceItemVm();
                    break;
                case "surgery":
                    serviceItems = _masterFileService.PagedSearchSurgeries(term, pagesize, page, out recordCount).toListServiceItemVm();
                    break;
                case "test":
                    serviceItems = _masterFileService.PagedSearchTest(term, pagesize, page, out recordCount).toListServiceItemVm();
                    break;
                default:
                   break;
            }

            return serviceItems;
        }
 
    }
}
