using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using WpfApp1.ViewModels;
using static WpfApp1.App;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for EditPopup.xaml
    /// </summary>
    public partial class EditPopup : Window, IHaveOutput<MachineStatusVM>
    {
        private readonly MachineManagementVM _editMachineViewModel;


        public EditPopup(int machineId)
        {
            InitializeComponent();

            var editMachineViewModelFactory = App.AppHost.Services.GetRequiredService<EditMachineViewModelFactory>();

            _editMachineViewModel = editMachineViewModelFactory(machineId);

            this.DataContext = _editMachineViewModel;
        }

        public MachineStatusVM GetOutput()
        {
            return MachineManagementVM.ToReturn;
        }
    }

}

