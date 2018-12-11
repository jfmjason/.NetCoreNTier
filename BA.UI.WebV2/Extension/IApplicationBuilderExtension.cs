using BA.Infra.Data;
using BA.UI.WebV2.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BA.UI.WebV2.Extension
{
    public static class IApplicationBuilderExtension
    {
        public static void InitializeDatabase(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<BADbContext>();
                //use manual migration to have full control of database changes
                //context.Database.Migrate();

                //Seed Initial Table values
                if (!context.PatientType.Any())
                {
                    foreach (var item in Config.GetPatientTypeSeed())
                    {
                        context.PatientType.Add(item);
                    }
                    context.SaveChanges();
                }

                if (!context.ApprovalRequestItemStatus.Any())
                {
                    foreach (var item in Config.GetApprovalRequestItemStatusSeed())
                    {
                        context.ApprovalRequestItemStatus.Add(item);
                    }
                    context.SaveChanges();
                }

                if (!context.ApprovalRequestStatus.Any())
                {
                    foreach (var item in Config.GetApprovalRequestStatusSeed())
                    {
                        context.ApprovalRequestStatus.Add(item);
                    }
                    context.SaveChanges();
                }

                if (!context.ApprovalRequestType.Any())
                {
                    foreach (var item in Config.GetApprovalRequestTypeSeed())
                    {
                        context.ApprovalRequestType.Add(item);
                    }
                    context.SaveChanges();
                }
            }

        }

    }
}
