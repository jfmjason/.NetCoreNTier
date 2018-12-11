using BA.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BA.IService
{
   public interface IOPBillService
   {
        OpcompanyBillDetail GetLatestOPCompanyBillDetail(int registrationNo);
    }
}
