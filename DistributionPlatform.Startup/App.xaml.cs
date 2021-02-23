using DistributionPlatform.Core.Interfaces;
using DistributionPlatform.Core.Services;
using DistributionPlatform.Infrastructure.Context;
using DistributionPlatform.Infrastructure.Providers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows;

namespace DistributionPlatform.Startup
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;
        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    ConfigureServices(context.Configuration, services);
                })
                .Build();
        }

        private void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            services.AddDbContext<DistributionPlatformContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")), contextLifetime: ServiceLifetime.Singleton);
            
            services.AddSingleton<IApplicationsProvider, ApplicationsProvider>();
            services.AddSingleton<IApplicationService, ApplicationService>();

            services.AddSingleton<Views.ImportView>();
            services.AddSingleton<Views.ApplicationsListView>();
            services.AddSingleton<MainWindow>();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await _host.StartAsync();
            _host.Services.GetRequiredService<MainWindow>().Show();
            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            using (_host)
            {
                await _host.StopAsync(TimeSpan.FromSeconds(5));
            }
            base.OnExit(e);
        }
    }
}
