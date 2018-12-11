using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace BA.Infra.Data.DesignTimeFactory
{
    public sealed class BADbContextDesignFactory : IDesignTimeDbContextFactory<BADbContext>
    {
        //for migration
        public BADbContext CreateDbContext(string[] args)
        {

            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", true, true)
               .Build();

            var constring = configuration.GetConnectionString("DefaultConnection");

            var builder = new DbContextOptionsBuilder<BADbContext>();

            builder.UseSqlServer(constring
                , x=>x.MigrationsHistoryTable("__ApprovalMigrationHistory"));

            return new BADbContext(builder.Options);
        }
    }
}
