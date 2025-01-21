using Microsoft.Extensions.DependencyInjection;
using WpfApp1.Services.Dialogs;
using WpfApp1.Services.ExternalMachines;
using WpfApp1.Services.MachinesStatus;
using static WpfApp1.App;
using WpfApp1.ViewModels;

namespace WpfApp1.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            // Register your services here
            services.AddSingleton<IDialogService, DialogService>();
            services.AddSingleton<IMachineService, MachinesService>();
            services.AddSingleton<IStatusService, StatusTranslationService>();
            services.AddSingleton<IMachineStatusService, MachineStatusServiceJson>();

            Console.WriteLine("Services have been registered.");
        }
        public static void AddViewModels(this IServiceCollection services)
        {
            // Register your ViewModels here
            services.AddTransient<EditMachineViewModelFactory>(provider => machineId =>
            {
                var statusService = provider.GetRequiredService<IStatusService>();
                var machineService = provider.GetRequiredService<IMachineStatusService>();
                var machineNameService = provider.GetRequiredService<IMachineService>();

                return new MachineManagementVM(machineId, statusService, machineService, machineNameService);
            });

            services.AddTransient<MachineManagementVM>();
            services.AddSingleton<MachineListVM>();
            services.AddTransient<MachineStatusVM>();
            services.AddTransient<MainVM>();

            Console.WriteLine("ViewModels have been registered.");
        }

        public static void AddWindows(this IServiceCollection services)
        {
            // Register your Windows here
            services.AddSingleton<MainWindow>();

            Console.WriteLine("Windows have been registered.");
        }
    }

}
