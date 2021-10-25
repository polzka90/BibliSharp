using BibliSharp.DbModels;
using BibliSharp.Security;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BibliSharp
{
    public class Startup
    {
        public Startup()
        {
            var builder = new ConfigurationBuilder()
.SetBasePath(AppContext.BaseDirectory)
.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration["ConexaoSqlite:SqliteConnectionString"];

            services.AddDbContext<BibliotecaContexto>(options =>
                options.UseSqlite(connection)
            );

            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddControllersWithViews();
            services.AddHttpContextAccessor();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.EventsType = typeof(CustomCookieAuthenticationEvents);
                    options.AccessDeniedPath = @"/Home/AccessDenied";
                    options.LoginPath = @"/Home/Login";
                    options.LogoutPath = @"/Home/Logout";
                });

            services.AddScoped<CustomCookieAuthenticationEvents>();

            services.AddAuthorization(options =>
            {
                //options.AddPolicy("Admin",
                //    policy => policy.AddRequirements(new BeAdminRequirement("Admin"))
                //);
                //options.AddPolicy("User",
                //    policy => policy.AddRequirements(new BeUserRequirement("Admin"))
                //);
                options.AddPolicy("IsAdmin", policy => policy.RequireClaim(ClaimTypes.Role, "Admin"));

                options.AddPolicy("IsUser", policy =>
                         policy.RequireAssertion(context =>
                            context.User.HasClaim(c =>
                                (c.Type == ClaimTypes.Role) &&
                                 c.Value != "Admin")));
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
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Login}/{id?}");
            });
        }
    }
}
