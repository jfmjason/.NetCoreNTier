using BA.Core.Entity;
using BA.IService;
using BA.Service.Impl;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BA.Test
{
    [TestClass]
    public class IOPBillServiceTest : BaseTest
    {
        private IOPBillService _iservice;
        public IOPBillServiceTest()
        {
            _iservice = ServiceProvider.GetService<IOPBillService>();
        }

        #region [BillTest]
        [TestMethod]
        public void SanitTyest()
        {
            Assert.IsInstanceOfType(_iservice, typeof(IOPBillService));
        }


        [TestMethod]
        public void CanGet_LatestOPCompanyBillDeta()
        {

            var result = _iservice.GetLatestOPCompanyBillDetail(1359159);

            Assert.AreNotEqual(null, result);
        }
        #endregion 


    }
}
