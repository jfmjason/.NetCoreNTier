using AutoMapper;
using BA.Core.Interface;
using BA.Infra.Data;
using BA.Infra.Data.Impl;
using BA.IService;
using BA.Service.Impl;
using BA.UI.WebV2.AutoMapper;
using BA.UI.WebV2.Custom;
using BA.UI.WebV2.Extension;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace BA.UI.WebV2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BADbContext>(options =>
                options.UseLazyLoadingProxies()
                .UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), option => option.UseRowNumberForPaging())
                );

            services.AddAuthentication(CustomCookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options=> 
              options.Cookie.SameSite = SameSiteMode.None
            )
            .AddCustomAuthentication(CustomCookieAuthenticationDefaults.AuthenticationScheme
            , ".NET CORE SCHEME", o =>
            { 
            });
            services.Configure<IISOptions>(options =>
            {
                options.ForwardClientCertificate = false;
            });

            services.AddScoped(typeof(IServiceItemPriceRepository), typeof(ServiceItemPriceRepository));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddTransient<IApprovalService, ApprovalService>();
            services.AddTransient<IMenuService, MenuService>();
            services.AddTransient<IMasterFileService, MasterFileService>();
            services.AddTransient<IReportService, ReportService>();
            services.AddTransient<IInpatientService, InpatientService>();
            services.AddTransient<IOPBillService, OPBillService>();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.InitializeDatabase();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
