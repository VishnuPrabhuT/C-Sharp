using ElectronNET.API;
using ElectronNET.API.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Joker
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                //app.UseBrowserLink();
                //app.UseBrowserLink();
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseWebSockets();
            //app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            //app.UseSpa(spa =>
            //{
            //    spa.Options.SourcePath = "ClientApp";

            //    if (env.IsDevelopment())
            //    {
            //        spa.UseReactDevelopmentServer(npmScript: "build");
            //    }
            //});

            if (HybridSupport.IsElectronActive)
            {
                //ElectronBoot();
            }
            ElectronBoot();
            //// Open the Electron-Window here
            //Task.Run(async () => await Electron.WindowManager.CreateWindowAsync());
        }

        public async void ElectronBoot()
        {
            var prefs = new BrowserWindowOptions
            {
                Width = 1152,
                Height = 864,
                Show = false,
                Icon = @"./icon/icon.ico",
                WebPreferences = new WebPreferences { WebSecurity = true },
                ThickFrame = false
            };
            var browserWindow = await Electron.WindowManager.CreateWindowAsync(prefs);
            //browserWindow.SetKiosk(true);

            var menu = new MenuItem[] {
                 new MenuItem
                    {
                      Label = "Show",
                      Click = () => { browserWindow.Show(); }
                    },
                 new MenuItem
                    {
                      Label = "Exit",
                      Click = () => { browserWindow.Close(); }
                    }
                };
            browserWindow.OnReadyToShow += () =>
            {
                browserWindow.Show();
                //Electron.Tray.Show("/icon/electron.png", menu);
                //Electron.Tray.SetToolTip("MercuryUI");
                //browserWindow.SetClosable(false);
            };
            //browserWindow.OnMinimize += () =>
            //{
            //    browserWindow.Hide();
            //    var notification = Electron.Notification;
            //    notification.Show(new NotificationOptions("MercuryUI", "App is Running!"));
            //};
            //RegisterIpc.Impl.Register();
        }
    }
}
