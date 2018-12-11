using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Scaffolding.Internal;

namespace BA.Infra.Data.DesignTimeService
{
    public class ScaffoldingDesignTimeService : IDesignTimeServices
    {
        //set first the compatibility to 100 and revert it again to 80 after generation models so that old script will work
        //ALTER DATABASE HIS  
        //SET COMPATIBILITY_LEVEL = 100;
        //GO
        //this is for the generation of model classes and dbcontext for the existing tables
        //eg package manager console command { scaffold-dbcontext "Data Source=130.1.2.186;Initial Catalog=HIS;User Id=WHCIT;Password=WHCIT;MultipleActiveResultSets=True;" -table Patient Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models}


        public void ConfigureDesignTimeServices(IServiceCollection services)
        {
            services.AddSingleton<ICandidateNamingService, CandidateNamingService>();
               
            //services.AddDbContext<BADbContext>();
        }
    }
}
