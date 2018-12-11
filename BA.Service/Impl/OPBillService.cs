using BA.Core.Entity;
using BA.Core.Interface;
using BA.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BA.Service.Impl
{
    public class OPBillService : IOPBillService
    {
        IUnitOfWork _iunitOfWork;

        public OPBillService(IUnitOfWork iunitOfWork) {

            _iunitOfWork = iunitOfWork;
        }

        public OpcompanyBillDetail GetLatestOPCompanyBillDetail(int registrationNo)
        {
            return _iunitOfWork.OpcompanyBillDetail.Entities.OrderBy(i => i.Billdatetime).FirstOrDefault();
        }
    }
}
