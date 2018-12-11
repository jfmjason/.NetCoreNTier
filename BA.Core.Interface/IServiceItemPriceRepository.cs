using BA.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BA.Core.Interface
{
    public interface IServiceItemPriceRepository
    {
        ServiceItemPrice GetOPServiceItemPrice(int itemId, int tariffId, string pricetable);
        ServiceItemPrice GetIPServiceItemPrice(int itemId, int tariffId, int bedtypeid, string pricetable);
    }
}
