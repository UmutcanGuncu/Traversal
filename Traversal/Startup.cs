using BusinnesLayer.Container;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using Traversal.Areas.Admin.Controllers;
using Traversal.CQRS.Commands.DestinationCommand;
using Traversal.CQRS.Handlers.DestinationHandlers;
using Traversal.Models;

namespace Traversal
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
            //services.AddMediatR(typeof(Startup));
            services.AddScoped<GetAllDestinationQueryHandler>();
            services.AddScoped<GetDestinationByIdQueryHandler>();
            services.AddScoped<CreateDestinationCommandHandler>();
            services.AddScoped<RemoveDestinationCommandHandler>();
            services.AddScoped<UpdateDestinationCommandHandler>();
            
            services.AddLogging(x => 
            {
                x.ClearProviders();
                x.SetMinimumLevel(LogLevel.Debug);
                x.AddDebug();
            });
            services.AddDbContext<Context>();//dbcontext yapılanmasını ekledik
            services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<Context>().AddErrorDescriber<CustomIdentityValidator>().AddTokenProvider<DataProtectorTokenProvider<AppUser>>(TokenOptions.DefaultProvider).AddEntityFrameworkStores<Context>();//identity yapılanmasını ekledik
            services.AddControllersWithViews();
            services.ContainerDependencies();
            services.AddHttpClient<VisitorApiController>();

            services.AddAutoMapper(typeof(Startup));
            services.CustomValidator();
            
            services.AddControllersWithViews().AddFluentValidation();
            //Proje seviyesinde authorization kullanıyoruz
            services.AddMvc(config=>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });
            services.AddLocalization(opt =>
            {
                opt.ResourcesPath = "Resources";
            });
            services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix).AddDataAnnotationsLocalization();
            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                //Identity Kütüpahnesinin Giriş Yolunu Ayarladık
                options.LoginPath = "/Login/SignIn";
                options.LogoutPath = "/Default/Index";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.SlidingExpiration = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();

            }
            app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404","?code={0}");
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();
            var supportedCultures = new[] { "en","fr","es","gr","tr","de" };
            var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[4]).AddSupportedCultures(supportedCultures).AddSupportedUICultures(supportedCultures);
            app.UseRequestLocalization(localizationOptions); 
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Default}/{action=Index}/{id?}");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Destination}/{action=Index}/{id?}"
                );
            });
        }
    }
}
