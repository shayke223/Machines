using Newtonsoft.Json;
using System.IO;
using WpfApp1.Models;

namespace WpfApp1.Services.ExternalMachines
{
    public class MachinesService : IMachineService
    {
        private readonly string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataBase", "MachinesDB.json");

        public List<string> GetMachineNames()
        {
            try
            {
                var jsonData = File.ReadAllText(_filePath);
                var machineNamesList = JsonConvert.DeserializeObject<MachineNamesList>(jsonData);
                return machineNamesList?.MachineNames.Select(m => m.Name).ToList() ?? new List<string>();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading machine names: " + ex.Message);
                return new List<string>();
            }
        }
    }

    // Class to represent the structure of the JSON file
    public class MachineNamesList
    {
        [JsonProperty("Machines")]
        public List<Machine> MachineNames { get; set; }
    }
}
