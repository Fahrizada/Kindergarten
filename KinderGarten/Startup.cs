using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using KinderGarten.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using KinderGarten.Interfaces;
using KinderGarten.Services;
using KinderGarten.Hubs;
using Microsoft.AspNetCore.Authorization;
using KinderGarten.Models;

namespace KinderGarten
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
            services.AddDbContext<KinderGartenContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("cs1")), ServiceLifetime.Transient);
            services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<KinderGartenContext>();
            services.AddAuthorization(options =>
            {
                options.FallbackPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
            });

            services.AddAuthorization(options => {
                options.AddPolicy("TwoFactorEnabled", x => x.RequireClaim("amr", "mfa"));
                options.AddPolicy("Admin", x => x.RequireClaim("Role", "Admin"));
                options.AddPolicy("Zaposlenik", x => x.RequireClaim("Role", "Zaposlenik"));
                options.AddPolicy("Roditelj", x => x.RequireClaim("Role", "Roditelj"));
                options.AddPolicy("AdminOrZaposlenik", x => x.RequireClaim("Role", new List<string> { "Admin", "Zaposlenik" } ));
                options.AddPolicy("AdminOrRoditelj", x => x.RequireClaim("Role", new List<string> { "Admin", "Roditelj" }));

            });

            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddSignalR();
            services.AddScoped<IGradInterface, GradService>();
            services.AddScoped<IDrzavaInterface, DrzavaService>();
            services.AddScoped<IDjecaInterface, DjecaService>();
            services.AddScoped<IGrupaInterface, GrupeServices>();
            services.AddScoped<IZaposlenikInterface, ZaposlenikServices>();
            services.AddScoped<IStrucnaSpremaInterface, StrucnaSpremaServices>();
            services.AddScoped<IZanimanjeInterface, ZanimanjeServices>();
            services.AddScoped<IOvlastenaOsobaInterface, OvlastenaOsobaServices>();
            services.AddScoped<IRadniListInterface, RadniListServices>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IEvidencijeService, EvidencijeService>();
            services.AddScoped<IUserInterface, UserService>();
            services.AddScoped<IIzletInterface, IzletService>();
            services.AddScoped<IRoditeljInterface, RoditeljService>();
            services.AddScoped<IDijeteIzletInterface, DijeteIzletService>();
            services.AddScoped<ISeminarInterface, SeminarService>();
            services.AddScoped<IAktivnostInterface, AktivnostService>();
            services.AddScoped<IZaposlenikAktivnostInterface, ZaposlenikAktivnostService>();
            services.AddScoped<IDijeteAktivnostInterface, DijeteAktivnostService>();
            services.AddScoped<IIzletZaposleniciInterface, IzletZaposleniciServis>();
            services.AddScoped<IZaposlenikSeminarInterface, ZaposlenikSeminarService>();
            services.AddScoped<IUplataInterface, UplataService>();
            services.AddScoped<IVrstaInterface, VrstaUplateService>();





        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<NotificationHub>("/notification");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Session}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
