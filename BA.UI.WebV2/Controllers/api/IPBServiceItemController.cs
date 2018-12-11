using AutoMapper;
using BA.IService;
using BA.UI.WebV2.Extension;
using BA.UI.WebV2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BA.UI.WebV2.Controllers.api
{
    [Route("api/[controller]")]
    public class IPBServiceItemController : Controller
    {
        private IMasterFileService _masterFileService;
        private IMapper _imapper;

        public IPBServiceItemController(IMasterFileService masterFileService, IMapper imapper)
        {
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

        [HttpGet("getprice/item/{itemid}/tariff/{tariffid}/bedtype/{bedtypeid}/pricetable/{pricetable}")]
        public ServiceItemPriceVm GetPrice(int itemid, int tariffid, int bedtypeid, string pricetable) {

            var itemprice = _masterFileService.GetIPServiceItemPrice(itemid, tariffid, bedtypeid, pricetable);

            return _imapper.Map<ServiceItemPriceVm>(itemprice);
        }

        private List<ServiceItemVm> getServiceItems(string mastertable, string term, int pagesize, int page, out int recordCount)
        {
            var serviceItems = new List<ServiceItemVm>();
            recordCount = 0;

            switch (mastertable.ToLower())
            {

                case "anaesthesia":
                    serviceItems = _masterFileService.PagedSearchAnaesthesia(term, pagesize, page, out recordCount).toListServiceItemVm();
                    break;

                case "assetitemsip":
                    serviceItems = _masterFileService.PagedSearchAssetItemsIP(term, pagesize, page, out recordCount).toListServiceItemVm();
                    break;

                case "bbotherprocedures":
                    serviceItems = _masterFileService.PagedSearchBBOtherProcedures(term, pagesize, page, out recordCount).toListServiceItemVm();
                    break;

                case "bedsideprocedure":
                    serviceItems = _masterFileService.PagedSearchBedsideProcedures(term, pagesize, page, out recordCount).toListServiceItemVm();
                    break;

                case "bedtype":
                    serviceItems = _masterFileService.PagedSearchBedType(term, pagesize, page, out recordCount).toListServiceItemVm();
                    break;

                case "bloodcomponent":
                    serviceItems = _masterFileService.PagedSearchBloodComponent(term, pagesize, page, out recordCount).toListServiceItemVm();
                    break;

                case "bloodissuemaster":
                    serviceItems = _masterFileService.PagedSearchBloodIssueMasterComponent(term, pagesize, page, out recordCount).toListServiceItemVm();
                    break;

                case "cathprocedure":
                    serviceItems = _masterFileService.PagedSearchCathProcedures(term, pagesize, page, out recordCount).toListServiceItemVm();
                    break;

                case "component":
                    serviceItems = _masterFileService.PagedSearchCathProcedures(term, pagesize, page, out recordCount).toListServiceItemVm();
                    break;

                case "cssitem":
                    serviceItems = _masterFileService.PagedSearchCSSItems(term, pagesize, page, out recordCount).toListServiceItemVm();
                    break;

                case "doctor":
                    serviceItems = _masterFileService.PagedSearchDoctors(term, pagesize, page, out recordCount).toListServiceItemVm();
                    break;

                case "employee":
                    serviceItems = _masterFileService.PagedSearchDoctors(term, pagesize, page, out recordCount).toListServiceItemVm();
                    break;

                case "fooditem":
                    serviceItems = _masterFileService.PagedSearchFoodItems(term, pagesize, page, out recordCount).toListServiceItemVm();
                    break;

                case "item":
                    serviceItems = _masterFileService.PagedSearchItems(term, pagesize, page, out recordCount).toListServiceItemVm();
                    break;

                case "laundryitem":
                    serviceItems = _masterFileService.PagedSearchLaundryItems(term, pagesize, page, out recordCount).toListServiceItemVm();
                    break;

                case "miscitems":
                    serviceItems = _masterFileService.PagedSearchMiscItems(term, pagesize, page, out recordCount).toListServiceItemVm();
                    break;

                case "otherprocedures":
                    serviceItems = _masterFileService.PagedSearchOtherProcedures(term, pagesize, page, out recordCount).toListServiceItemVm();
                    break;

                case "otno":
                    serviceItems = _masterFileService.PagedSearchOTNos(term, pagesize, page, out recordCount).toListServiceItemVm();
                    break;

                case "ptprocedure":
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
