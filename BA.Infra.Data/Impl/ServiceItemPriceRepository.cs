using BA.Core.Entity;
using BA.Core.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace BA.Infra.Data.Impl
{
    public class ServiceItemPriceRepository : IServiceItemPriceRepository
    {
        private readonly BADbContext _dbContext;

        public ServiceItemPriceRepository(BADbContext dbContext) {

            _dbContext = dbContext;
        }

        public ServiceItemPrice GetIPServiceItemPrice(int itemId, int tariffId, int bedtypeid, string pricetable)
        {
            var query = "SELECT Id, CAST(Price AS DECIMAL(30,2)) Price, StartDateTime, Deleted FROM P_" + tariffId+"_" + bedtypeid + "_" + pricetable + " WHERE Id = " + itemId;

            var pquery = new SqlParameter("query", query);

            return _dbContext.ServiceItemPrice.FromSql("EXEC (@query)", pquery).FirstOrDefault();
        }

        public ServiceItemPrice GetOPServiceItemPrice(int itemId, int tariffId, string priceTable)
        {
            var query = "SELECT Id, CAST(Price AS DECIMAL(30,2)) Price, StartDateTime, Deleted FROM OP_P_" + tariffId + "_" + priceTable +" WHERE Id = "+itemId;

            var pquery = new SqlParameter("query", query);

            return _dbContext.ServiceItemPrice.FromSql("EXEC (@query)", pquery).FirstOrDefault();
        }
    }
}
