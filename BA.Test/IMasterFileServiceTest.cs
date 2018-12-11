using BA.Core.Entity;
using BA.IService;
using BA.Service.Impl;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BA.Test
{
    [TestClass]
    public class IMasterFileServiceTest : BaseTest
    {
        private IMasterFileService _iMasterFileService;
        public IMasterFileServiceTest()
        {
            _iMasterFileService = ServiceProvider.GetService<IMasterFileService>();
        }

        #region [PagedSearch Test]
        [TestMethod]
        public void SanitTyest()
        {
            Assert.IsInstanceOfType(_iMasterFileService, typeof(MasterFileService));
        }

        [TestMethod]
        public void CanGet_PagedSearchAanaesthesia()
        {
            int totalrecord = 0;
            var result = _iMasterFileService.PagedSearchAnaesthesia("", 50, 1, out totalrecord).ToList();

            Assert.AreNotEqual(null, result);
        }

        [TestMethod]
        public void CanGet_PagedSearchAssetItemsIp()
        {
            int totalrecord = 0;

            var result = _iMasterFileService.PagedSearchAssetItemsIP("", 50, 1, out totalrecord).ToList();

            Assert.AreNotEqual(null, result);
        }

        [TestMethod]
        public void CanGet_PagedSearchBBOtherProcedures()
        {
            int totalrecord = 0;

            var result = _iMasterFileService.PagedSearchBBOtherProcedures("", 50, 1, out totalrecord).ToList();

            Assert.AreNotEqual(null, result);
        }

        [TestMethod]
        public void CanGet_PagedSearchBedsideProcedure()
        {
            int totalrecord = 0;

            var result = _iMasterFileService.PagedSearchBedsideProcedures("", 50, 1, out totalrecord).ToList();

            Assert.AreNotEqual(null, result);
        }

        [TestMethod]
        public void CanGet_PagedSearchBedtype()
        {
            int totalrecord = 0;

            var result = _iMasterFileService.PagedSearchBedType("", 50, 1, out totalrecord).ToList();

            Assert.AreNotEqual(null, result);
        }

        [TestMethod]
        public void CanGet_PagedSearchBloodComponent()
        {
            int totalrecord = 0;

            var result = _iMasterFileService.PagedSearchBloodComponent("", 50, 1, out totalrecord).ToList();

            Assert.AreNotEqual(null, result);
        }

        [TestMethod]
        public void CanGet_PagedSearchBloodCrossMatchComponent()
        {
            int totalrecord = 0;

            var result = _iMasterFileService.PagedSearchBloodCrossMatchComponent("", 50, 1, out totalrecord).ToList();

            Assert.AreNotEqual(null, result);
        }

        [TestMethod]
        public void CanGet_PagedSearchBloodDonationMasterComponent()
        {
            int totalrecord = 0;

            var result = _iMasterFileService.PagedSearchBloodDonationMasterComponent("", 50, 1, out totalrecord).ToList();

            Assert.AreNotEqual(null, result);
        }

        [TestMethod]
        public void CanGet_PagedSearchBloodIssueMasterComponent()
        {
            int totalrecord = 0;

            var result = _iMasterFileService.PagedSearchBloodIssueMasterComponent("", 50, 1, out totalrecord).ToList();

            Assert.AreNotEqual(null, result);
        }

        [TestMethod]
        public void CanGet_PagedSearchCathProcedures()
        {
            int totalrecord = 0;

            var result = _iMasterFileService.PagedSearchCathProcedures("", 50, 1, out totalrecord).ToList();

            Assert.AreNotEqual(null, result);
        }

        [TestMethod]
        public void CanGet_PagedSearchComponents()
        {
            int totalrecord = 0;

            var result = _iMasterFileService.PagedSearchComponent("", 50, 1, out totalrecord).ToList();

            Assert.AreNotEqual(null, result);
        }

        [TestMethod]
        public void CanGet_PagedSearchCSSItems()
        {
            int totalrecord = 0;

            var result = _iMasterFileService.PagedSearchCSSItems("", 50, 1, out totalrecord).ToList();

            Assert.AreNotEqual(null, result);
        }

        [TestMethod]
        public void CanGet_PagedSearchdoctors()
        {
            int totalrecord = 0;

            var result = _iMasterFileService.PagedSearchDoctors("", 50, 1, out totalrecord).ToList();

            Assert.AreNotEqual(null, result);
        }

        [TestMethod]
        public void CanGet_PagedSearchEmployee()
        {
            int totalrecord = 0;

            var result = _iMasterFileService.PagedSearchEmployee("", 50, 1, out totalrecord).ToList();

            Assert.AreNotEqual(null, result);
        }

        [TestMethod]
        public void CanGet_PagedSearchFoodItems()
        {
            int totalrecord = 0;

            var result = _iMasterFileService.PagedSearchFoodItems("", 50, 1, out totalrecord).ToList();

            Assert.AreNotEqual(null, result);
        }

        [TestMethod]
        public void CanGet_PagedSearchHealthCheckUp()
        {
            int totalrecord = 0;

            var result = _iMasterFileService.PagedSearchHealthCheckUps("", 50, 1, out totalrecord).ToList();

            Assert.AreNotEqual(null, result);
        }

        [TestMethod]
        public void CanGet_PagedSearchItems()
        {
            int totalrecord = 0;

            var result = _iMasterFileService.PagedSearchItems("", 50, 1, out totalrecord).ToList();

            Assert.AreNotEqual(null, result);
        }

        [TestMethod]
        public void CanGet_PagedSearchLaundryItems()
        {
            int totalrecord = 0;

            var result = _iMasterFileService.PagedSearchLaundryItems("", 50, 1, out totalrecord).ToList();

            Assert.AreNotEqual(null, result);
        }

        [TestMethod]
        public void CanGet_PagedSearchMiscsItems()
        {
            int totalrecord = 0;

            var result = _iMasterFileService.PagedSearchMiscItems("", 50, 1, out totalrecord).ToList();

            Assert.AreNotEqual(null, result);
        }

        [TestMethod]
        public void CanGet_PagedSearchOtherProcedures()
        {
            int totalrecord = 0;

            var result = _iMasterFileService.PagedSearchOtherProcedures("", 50, 1, out totalrecord).ToList();

            Assert.AreNotEqual(null, result);
        }

        [TestMethod]
        public void CanGet_PagedSearchOTNo()
        {
            int totalrecord = 0;

            var result = _iMasterFileService.PagedSearchOTNos("", 50, 1, out totalrecord).ToList();

            Assert.AreNotEqual(null, result);
        }

        [TestMethod]
        public void CanGet_PagedSearchPatient()
        {
            int totalrecord = 0;

            var result = _iMasterFileService.PagedSearchPatients("", 50, 1, out totalrecord).ToList();

            Assert.AreNotEqual(null, result);
        }

        [TestMethod]
        public void CanGet_PagedSearchPTProcedure()
        {
            int totalrecord = 0;

            var result = _iMasterFileService.PagedSearchPTProcedures("", 50, 1, out totalrecord).ToList();

            Assert.AreNotEqual(null, result);
        }

        [TestMethod]
        public void CanGet_PagedSearchSurgeries()
        {
            int totalrecord = 0;

            var result = _iMasterFileService.PagedSearchSurgeries("", 50, 1, out totalrecord).ToList();

            Assert.AreNotEqual(null, result);
        }

        [TestMethod]
        public void CanGet_PagedSearchTest()
        {
            int totalrecord = 0;

            var result = _iMasterFileService.PagedSearchTest("", 50, 1, out totalrecord).ToList();

            Assert.AreNotEqual(null, result);
        }
        #endregion

        #region  [ServiceItem Price Test]
        [TestMethod]
        public void CanGet_OpServiceItemPrice()
        {

            var result = _iMasterFileService.GetOPServiceItemPrice(6056,1,"doctor" );

            Assert.AreNotEqual(null, result);
        }

        [TestMethod]
        public void CanGet_IpServiceItemPrice()
        {

            var result = _iMasterFileService.GetIPServiceItemPrice(64, 19,37, "test");

            Assert.AreNotEqual(null, result);
        }


        #endregion
    }
}
