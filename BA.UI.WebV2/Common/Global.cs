using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BA.UI.WebV2.Common
{
    public class Global
    {

        private static IConfiguration configuration;
        private static int? moduleId;

        public static IConfiguration Configuration
        {
            get
            {
                if (configuration == null)
                {
                    configuration = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", true, true)
                        .Build();
                }

                return configuration;
            }
        }

        public static int ModuleId
        {
            get
            {
                if (moduleId == null)
                {
                    moduleId = int.Parse(Configuration["ModuleId"]);
                }

                return moduleId.Value;
            }
        }
    }
}
