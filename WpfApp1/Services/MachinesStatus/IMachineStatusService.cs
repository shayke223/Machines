using WpfApp1.Models;
using WpfApp1.ViewModels;

namespace WpfApp1.Services.MachinesStatus
{
    public interface IMachineStatusService
    {
        Task<List<MachineStatus>> GetMachineStatuses(MachineFilter filter);
        MachineStatus GetMachineStatusById(int id);
        Task AddMachineStatus(MachineStatusVM machineViewModel);
        Task UpdateMachineStatus(MachineStatusVM machine);
        Task RemoveMachineStatus(object machineId);
    }
}