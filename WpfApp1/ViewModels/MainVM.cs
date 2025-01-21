namespace WpfApp1.ViewModels
{
    public class MainVM
    {
        public MainVM(MachineListVM machineListViewModel)
        {
            MachineListVM = machineListViewModel;
        }

        public MachineListVM MachineListVM { get; }
    }
}
