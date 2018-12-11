using BA.Core.Interface;
using BA.Infra.Data;
using BA.Infra.Data.Impl;
using BA.IService;
using BA.Service.Impl;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace BA.Test
{
    public class BaseTest
    {
        public ServiceProvider ServiceProvider { get; private set; }

        public BaseTest() {

            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", true, true)
               .Build();

            var constring = configuration.GetConnectionString("DefaultConnection");

            var services = new ServiceCollection();

            services.AddDbContext<BADbContext>(options =>
               options.UseLazyLoadingProxies()
               .UseSqlServer(constring, option=> option.UseRowNumberForPaging())
               );
            services.AddScoped(typeof(IServiceItemPriceRepository), typeof(ServiceItemPriceRepository));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddTransient<IApprovalService, ApprovalService>();
            services.AddTransient<IMenuService, MenuService>();
            services.AddTransient<IMasterFileService, MasterFileService>();
            services.AddTransient<IReportService, ReportService>();
            services.AddTransient<IInpatientService, InpatientService>();
            services.AddTransient<IOPBillService, OPBillService>();
            ServiceProvider = services.BuildServiceProvider();
        }

    }
}
