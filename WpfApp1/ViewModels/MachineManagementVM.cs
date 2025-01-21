using WpfApp1.Models;
using WpfApp1.ViewModels.Commands;
using System.Windows.Input;
using System.Windows;
using WpfApp1.Misc;
using WpfApp1.Exceptions;
using WpfApp1.Services.ExternalMachines;
using WpfApp1.Services.MachinesStatus;

namespace WpfApp1.ViewModels
{
    public class MachineManagementVM
    {

        public List<string> MachineNames { get; set; } = new List<string>();
        public string MachineName { get; set; }
        public string Description { get; set; }
        public List<StatusComboBoxOption> Statuses { get; set; }
        public int Status { get; set; }
        public string Notes { get; set; }

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        private readonly IStatusService StatusService;
        private readonly IMachineStatusService MachineStatusService;
        private readonly IMachineService MachineNamesService;
        public static MachineStatusVM ToReturn { get; private set; }

        public MachineManagementVM(int machineId,IStatusService statusService,IMachineStatusService machineService,IMachineService machineNameService)
        {
            StatusService = statusService;
            MachineStatusService = machineService;
            MachineNamesService = machineNameService;

            SaveCommand = new RelayCommand(SaveReferenceNewValues);
            CancelCommand = new RelayCommand(CancelEditing);

            ToReturn = InitializeOutputForUser(machineId);

            LoadCurrnetMachineData(ToReturn);
            LoadMachineNamesComboBox(ToReturn);
            LoadStatusNamesComboBox();
        }

        private  MachineStatusVM InitializeOutputForUser(int machineId)
        {
            //New Machine
            if (machineId == Constants.StatusCodes.Unknown)
                return new MachineStatusVM(new MachineStatus());

         
            var theMachine = MachineStatusService.GetMachineStatusById(machineId);
            MachineStatus m = null;

            if (theMachine != null)
            {
                m = new MachineStatus
                {
                    MachineName = theMachine.MachineName,
                    Description = theMachine.Description,
                    Status = theMachine.Status,
                    Notes = theMachine.Notes,
                    ID = theMachine.ID,
                    StatusImage = theMachine.StatusImage,
                };
            }

           return new MachineStatusVM(m);
            
        }

        private void LoadCurrnetMachineData(MachineStatusVM currentMachine)
        {
            if(currentMachine == null)
                throw new CustomClientException("Could not load machine's data");

            MachineName = currentMachine.MachineName;
            Description = currentMachine.Description;
            Status = currentMachine.Status;
            Notes = currentMachine.Notes;
        }

        private void SaveReferenceNewValues(object obj)
        {
            if (ToReturn == null)
                throw new CustomClientException("Could not load machine's data");

            ToReturn.IsConfirmed = true;
            ToReturn.Description = Description;
            ToReturn.Status = Status;
            ToReturn.Notes = Notes;
            ToReturn.MachineName = MachineName;

            ((Window)obj).Close();

        }

        private void CancelEditing(object obj)
        {
            ToReturn.IsConfirmed = false;
            ((Window)obj).Close();
        }

        private void LoadStatusNamesComboBox()
        {
            Statuses = StatusService.GetStatusOptionsForComboBox();
        }

        private void LoadMachineNamesComboBox(MachineStatusVM currentMachine)
        {

            if (!string.IsNullOrEmpty(currentMachine.MachineName))
                MachineNames.Add(currentMachine.MachineName);
            else
                MachineNames = MachineNamesService.GetMachineNames();
        }


    }
}

