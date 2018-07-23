using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using WhatsOnTap.Models;

namespace WhatsOnTap
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddEnvironmentVariables()
                .AddJsonFile("appsettings.json");
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddEntityFrameworkMySql()
                    .AddDbContext<WhatsOnTapContext>(options => options.UseMySql(Configuration["ConnectionStrings:DefaultConnection"]));
            
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<WhatsOnTapContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;

                // Lockout settings
                // options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                // options.Lockout.MaxFailedAccessAttempts = 10;

                // Cookie settings
                // options.Cookies.ApplicationCookie.ExpireTimeSpan = TimeSpan.FromDays(150);
                // options.Cookies.ApplicationCookie.LoginPath = "/Account/Login";

                // User settings
                options.User.RequireUniqueEmail = true;
            });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();
            app.UseDeveloperExceptionPage();
            app.UseIdentity();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Invalid path or request. Please try again.");
            });
        }
    }
}
