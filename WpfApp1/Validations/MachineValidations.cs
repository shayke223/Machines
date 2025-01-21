using Microsoft.Extensions.DependencyInjection;
using WpfApp1.Exceptions;
using WpfApp1.Misc;
using WpfApp1.Models;

namespace WpfApp1.Validations
{
    internal class MachineValidations
    {
        public static void ValidateName(int machineID, string machineName, List<MachineStatus> allMachines)
        {
            if (string.IsNullOrEmpty(machineName) || machineName.Trim() == "")
                throw new CustomClientException("Machine name is required");

            if (allMachines.Any(m => m.MachineName == machineName.Trim() && m.ID != machineID))
                throw new CustomClientException("Machine name already exists");
        }

        internal static void ValidateStatus(int status)
        {
            var service = App.AppHost.Services.GetRequiredService<IStatusService>();

            if (service == null)
                throw new CustomClientException("Server error, please contact support");

            if (status < 0)
                throw new CustomClientException("A valid status must be selected");

            List<StatusComboBoxOption> list = service.GetStatusOptionsForComboBox();

            if (list.Count == 0)
                throw new CustomClientException("Server error, please contact support");

            // Check if the status is inside the list
            bool isValidStatus = list.Any(option => option.Value == status);

            if (!isValidStatus)
                throw new CustomClientException("Status not found in the list, please select a valid status");
        }
    }
}
