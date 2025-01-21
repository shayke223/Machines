using System.Collections.ObjectModel;
using WpfApp1.Exceptions;
using WpfApp1.Misc;
using WpfApp1.Models;
using WpfApp1.Services.Dialogs;
using WpfApp1.Services.MachinesStatus;
using WpfApp1.ViewModels.Commands;

namespace WpfApp1.ViewModels
{
    public class MachineListVM: ObserveableObject
    {
        public List<StatusComboBoxOption> Statuses { get; set; }
        private int _statusFilter = -1;
        public int StatusFilter
        {
            get { return _statusFilter; }
            set
            {
                _statusFilter = value;
                //Auto pulling when changing status
                GetMachinesCommand.Execute(null); 
            }
        }
        public ObservableCollection<MachineStatusVM> Machines { get; } = new ObservableCollection<MachineStatusVM>();


        private IMachineStatusService MachineService { get; set; }
        private IStatusService StatusService { get; }
        private IDialogService DialogService { get; }

        public RelayCommand GetMachinesCommand { get; private set; }
        public RelayCommand AddMachinesCommand { get; private set; }
        public RelayCommand RemoveMachineCommand { get; private set; }
        public RelayCommand EditMachineCommand { get; private set; }

        public MachineListVM(IMachineStatusService MachineService, IStatusService StatusService, IDialogService DialogService)
        {

            this.MachineService = MachineService;
            this.StatusService = StatusService;
            this.DialogService = DialogService;

            GetMachinesCommand = new RelayCommand(LoadMachineStatuses, CanGetMachineStatuses);
            AddMachinesCommand = new RelayCommand(AddMachineStatus);
            RemoveMachineCommand = new RelayCommand(RemoveMachineStatus);
            EditMachineCommand = new RelayCommand(EditMachineStatus);
    
            InitializeOperatorStatusFilter();
        }


        private void InitializeOperatorStatusFilter()
        {
            Statuses = StatusService.GetStatusOptionsForComboBox();
            StatusService.AddSelectAllStatus(Statuses);

            //Default Value
            StatusFilter = Constants.StatusCodes.SelectAll;
        }

        //------------------- Main Commands -----------------------------
        public async void AddMachineStatus(object machine)
        {
            try
            {
                var editPopup = new EditPopup(-1);
                var newMachineViewModel = DialogService.ShowDialog<MachineStatusVM>(editPopup);

                if (newMachineViewModel == null || !newMachineViewModel.IsConfirmed)
                    return;

                await MachineService.AddMachineStatus(newMachineViewModel);
                Machines.Add(newMachineViewModel);
                DialogService.ShowMessage("Machine Status inserted successfully.");
            }
            catch (CustomClientException ex)
            {
                DialogService.ShowErrorMessage(ex.Message);            
            }
            catch (Exception)
            {
                DialogService.ShowErrorMessage();            
            }
        }


        public async void LoadMachineStatuses(object message)
        {
            try
            {
                Machines.Clear();

                MachineFilter currentFilter = new MachineFilter(StatusFilter);
                var machines = await MachineService.GetMachineStatuses(currentFilter);

                foreach (var machine in machines)
                    Machines.Add(new MachineStatusVM(machine));
            }
            catch (CustomClientException ex)
            {
                DialogService.ShowErrorMessage(ex.Message);
            }
            catch (Exception)
            {
                DialogService.ShowErrorMessage();
            }

        }
        public async void RemoveMachineStatus(object parameter)
        {
            try
            {
                var machineViewModel = parameter as MachineStatusVM;

                if (machineViewModel == null)
                    return;
      
                bool isConfirmed = DialogService.ShowConfirmationDialog(
                    "Are you sure you want to remove this machine?",
                    "Confirm Removal"
                );

                if (!isConfirmed)
                    return;

             
                await MachineService.RemoveMachineStatus(machineViewModel.ID);
                Machines.Remove(machineViewModel);
                

            }
            catch (CustomClientException ex)
            {
                DialogService.ShowErrorMessage(ex.Message);
            }
            catch (Exception)
            {
                DialogService.ShowErrorMessage();
            }
        }

        public void EditMachineStatus(object parameter)
        {

            try
            {
                // Retrieve the factory from DI
                var chosenMachineVM = (MachineStatusVM)parameter;


                var editPopup = new EditPopup(chosenMachineVM.ID);
                editPopup.ShowDialog();

                MachineStatusVM newMachineViewModel = editPopup.GetOutput();

                if (!newMachineViewModel.IsConfirmed)
                    return;

                MachineService.UpdateMachineStatus(newMachineViewModel);
                UpdateMachineViewModel(chosenMachineVM, newMachineViewModel);
      
            }
            catch (CustomClientException ex)
            {
                DialogService.ShowErrorMessage(ex.Message);
            }
            catch (Exception)
            {
                DialogService.ShowErrorMessage();
            }

        }

        //------------------- Sub Commands -----------------------------


        private void UpdateMachineViewModel(MachineStatusVM originalViewModel, MachineStatusVM updatedViewModel)
        {
            originalViewModel.Description = updatedViewModel.Description;
            originalViewModel.Notes = updatedViewModel.Notes;
            originalViewModel.Status = updatedViewModel.Status;
            originalViewModel.StatusText = updatedViewModel.StatusText;
            originalViewModel.StatusImage = updatedViewModel.StatusImage;
        }

        //just predicator
        public bool CanGetMachineStatuses(object statement)
        {
            return true;
        }
    }
}
