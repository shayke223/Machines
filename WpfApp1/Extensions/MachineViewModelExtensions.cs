using WpfApp1.Models;
using WpfApp1.ViewModels;

namespace WpfApp1.Extensions
{
    public static class MachineViewModelExtensions
    {
        public static MachineStatus ToMachine(this MachineStatusVM machineViewModel)
        {
            return new MachineStatus()
            {
                Description = machineViewModel.Description,
                MachineName = machineViewModel.MachineName,
                ID = machineViewModel.ID,
                Notes = machineViewModel.Notes,
                Status = machineViewModel.Status,
                StatusImage = machineViewModel.StatusImage
            };
        }
    }

}
