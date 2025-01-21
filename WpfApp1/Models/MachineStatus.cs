namespace WpfApp1.Models
{

    public class MachineStatus
    {
        public MachineStatus()
        {
                
        }
        public MachineStatus(int ID,string machineName, string description, int status, string notes)
        {
            this.ID = ID;
            MachineName = machineName;
            Description = description;
            Status = status;
            Notes = notes;
        }

        public int ID { get; set; }
        public string MachineName { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public string Notes { get; set; }
        public string StatusImage { get; set; } 


    }
}
