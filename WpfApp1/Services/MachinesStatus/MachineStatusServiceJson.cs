using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WpfApp1.Exceptions;
using WpfApp1.Misc;
using WpfApp1.Models;
using WpfApp1.Validations;
using WpfApp1.ViewModels;

namespace WpfApp1.Services.MachinesStatus
{
    class MachineStatusServiceJson : IMachineStatusService
    {
        private string _filePath = "DataBase/MachineStatuses.json";

        public async Task<List<MachineStatus>> GetMachineStatuses(MachineFilter filter)
        {
            var machineList = await ReadMachineDataFromFileAsync();

            // Simulate delay for async call
            await Task.Delay(10);

            if (filter == null || filter.status == Constants.StatusCodes.SelectAll)
                return machineList;

            return machineList.Where(m => m.Status == filter.status).ToList();
        }

        public MachineStatus GetMachineStatusById(int id)
        {
            var machineList = ReadMachineDataFromFile();

            var machine = machineList.FirstOrDefault(m => m.ID == id);
            if (machine == null)
                throw new CustomClientException("Machine not found.");

            return machine;
        }

        public async Task RemoveMachineStatus(object machineId)
        {
            int id = (int)machineId;
            var machineList = await ReadMachineDataFromFileAsync();

            var machine = machineList.FirstOrDefault(m => m.ID == id);
            if (machine == null)
                throw new CustomClientException("Machine not found.");

            machineList.Remove(machine);
            await WriteMachineDataToFileAsync(machineList);  // Save to file
        }

        public async Task AddMachineStatus(MachineStatusVM machineViewModel)
        {
            var machineList = await ReadMachineDataFromFileAsync();

            int newID = (machineList == null || machineList.Count == 0) ? 0 :  machineList.Max(m => m.ID) + 1;

            MachineValidations.ValidateName(newID, machineViewModel.MachineName, machineList);
            MachineValidations.ValidateStatus(machineViewModel.Status);
            machineViewModel.ID = newID;

            var machine = new MachineStatus()
            {
                ID = newID,
                Description = machineViewModel.Description,
                Notes = machineViewModel.Notes,
                MachineName = machineViewModel.MachineName,
                Status = machineViewModel.Status,
                StatusImage = machineViewModel.StatusImage
            };

            machineList.Add(machine);
            await WriteMachineDataToFileAsync(machineList);  // Save to file
        }

        public async Task UpdateMachineStatus(MachineStatusVM machineToUpdate)
        {
            var machineList = await ReadMachineDataFromFileAsync();

            MachineValidations.ValidateName(machineToUpdate.ID, machineToUpdate.MachineName, machineList);
            MachineValidations.ValidateStatus(machineToUpdate.Status);

            var machine = machineList.FirstOrDefault(m => m.ID == machineToUpdate.ID);

            if (machine == null)
                throw new CustomClientException("Machine not found.");

            machine.Status = machineToUpdate.Status;
            await WriteMachineDataToFileAsync(machineList);  // Save to file
        }


        // Helper method to read machine data from the file
        // Helper method to read machine data from the file
        private async Task<List<MachineStatus>> ReadMachineDataFromFileAsync()
        {
            if (!File.Exists(_filePath))
            {
                // If the file doesn't exist, return an empty list
                return new List<MachineStatus>();
            }

            try
            {
                // Read the content of the file
                string jsonString = await File.ReadAllTextAsync(_filePath, Encoding.UTF8);

                // Deserialize the JSON content
                return JsonSerializer.Deserialize<List<MachineStatus>>(jsonString) ?? new List<MachineStatus>();
            }
            catch (JsonException ex)
            {
                // Handle JSON parsing issues specifically
                throw new CustomClientException("The database file is corrupted. Failed to parse JSON.", ex);
            }
            catch (IOException ex)
            {
                // Handle file I/O issues specifically
                throw new CustomClientException("An error occurred while accessing the database file.", ex);
            }
            catch (UnauthorizedAccessException ex)
            {
                // Handle permission issues specifically
                throw new CustomClientException("Access to the database file is denied.", ex);
            }
            catch (Exception ex)
            {
                // Handle any other unexpected errors
                throw new CustomClientException("An unexpected error occurred while reading the database.", ex);
            }
        }
        private List<MachineStatus> ReadMachineDataFromFile()
        {
            if (!File.Exists(_filePath))
            {
                // If the file doesn't exist, return an empty list
                return new List<MachineStatus>();
            }

            try
            {
                // Read the content of the file
                string jsonString = File.ReadAllText(_filePath, Encoding.UTF8);

                // Deserialize the JSON content
                return JsonSerializer.Deserialize<List<MachineStatus>>(jsonString) ?? new List<MachineStatus>();
            }
            catch (JsonException ex)
            {
                // Handle JSON parsing issues specifically
                throw new CustomClientException("The database file is corrupted. Failed to parse JSON.", ex);
            }
            catch (IOException ex)
            {
                // Handle file I/O issues specifically
                throw new CustomClientException("An error occurred while accessing the database file.", ex);
            }
            catch (UnauthorizedAccessException ex)
            {
                // Handle permission issues specifically
                throw new CustomClientException("Access to the database file is denied.", ex);
            }
            catch (Exception ex)
            {
                // Handle any other unexpected errors
                throw new CustomClientException("An unexpected error occurred while reading the database.", ex);
            }
        }


        // Helper method to write machine data to the file
        private async Task WriteMachineDataToFileAsync(List<MachineStatus> machineList)
        {
            string jsonString = JsonSerializer.Serialize(machineList, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(_filePath, jsonString);
        }
    }
}
