using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using WpfApp1.Extensions;
using WpfApp1.Models;
using WpfApp1.Services.Dialogs;
using WpfApp1.Services.ExternalMachines;
using WpfApp1.Services.MachinesStatus;
using WpfApp1.ViewModels;

namespace WpfApp1
{
    public partial class App : Application
    {
        public static IHost? AppHost { get; private set; }

        public delegate MachineManagementVM EditMachineViewModelFactory(int machineId);


        public App()
        {

            AppHost = Host.CreateDefaultBuilder().ConfigureServices((hostContext, services) =>
            {
                // Register Services
                services.AddServices();

                // Register ViewModels
                services.AddViewModels();

                // Register Windows
                services.AddWindows();

                Console.WriteLine("Services have been registered.");
            }).Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var startupForm = AppHost.Services.GetRequiredService<MainWindow>();
            startupForm.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
        }
    }
}
