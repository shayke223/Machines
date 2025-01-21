using Microsoft.Extensions.DependencyInjection;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    public class MachineStatusVM: ObserveableObject
    {
        private readonly IStatusService statusService;
        private readonly MachineStatus _machine;

        public MachineStatusVM(MachineStatus machine)
        {
            statusService =  App.AppHost.Services.GetRequiredService<IStatusService>();
            _machine = machine;
            IsConfirmed = false;
        }

        public int ID
        {
            get { return _machine.ID; }
            set { _machine.ID = value; OnPropertyChanged(nameof(ID)); }
        }
        public string MachineName
        {
            get { return _machine.MachineName; }
            set { _machine.MachineName = value; OnPropertyChanged(nameof(MachineName));  }
        }
        public string Description
        {
            get { return _machine.Description; }
            set { _machine.Description = value; OnPropertyChanged(nameof(Description)); }
        }
        public int Status
        {
            get { return _machine.Status; }
            set
            {
                if (_machine.Status != value)
                {
                    _machine.Status = value;
                    OnPropertyChanged(nameof(Status));
                    OnPropertyChanged(nameof(StatusText));
                    OnPropertyChanged(nameof(StatusImage));
                }
            }
        }
        public string Notes
        {
            get { return _machine.Notes; }
            set { _machine.Notes = value; OnPropertyChanged(nameof(Notes)); }
        }
        public string StatusImage
        {
            set
            {
                OnPropertyChanged(nameof(StatusImage));
            }
            get
            {
                return statusService.TranslateStatusToImagePath(Status);
            }
        }
        public string StatusText
        {
            set
            {
                OnPropertyChanged(nameof(StatusText));             
            }
            get
            {
                return statusService.TranslateStatusToDescription(Status);
            }
        }

        //After Edit, we can know if the user Confirmed or quit
        private bool _isConfirmed = false;
        public bool IsConfirmed
        {
            get { return _isConfirmed; }
            set
            {
                if (_isConfirmed != value)
                {
                    _isConfirmed = value;
                    OnPropertyChanged(nameof(IsConfirmed));
                }
            }
        }
    }
}
