using WpfApp1.Exceptions;
using WpfApp1.Misc;
using WpfApp1.Models;
using WpfApp1.Validations;
using WpfApp1.ViewModels;

namespace WpfApp1.Services.MachinesStatus
{
    class MachineStatusServiceMock : IMachineStatusService
    {
        private List<MachineStatus> _machine;
        public MachineStatusServiceMock()
        {
            _machine = new List<MachineStatus>()
            {

                        new MachineStatus(0,"Example Machine A","Description 1",10,"Notes"),
                        new MachineStatus(1,"Example Machine B","Description 2",20,"Notes"),
                        new MachineStatus(2,"Example Machine C","Description 3",30,"Notes"),
                        new MachineStatus(3,"Example Machine D","Description 4",3,"Notes Notes Notes\nNotes Notes Notes\nNotes Notes Notes\nNotes Notes Notes\nNotes Notes Notes\nNotes Notes Notes\nNotes Notes Notes\n"),
            };
        }

        public async Task<List<MachineStatus>> GetMachineStatuses(MachineFilter filter)
        {

            //להראות ללקוח שקרה משהו אם זה מהיר מדי
            await Task.Delay(10);

            if (filter == null || filter.status == Constants.StatusCodes.SelectAll)
                return _machine;

            return _machine.Where(m => m.Status == filter.status).ToList();
        }


        public MachineStatus GetMachineStatusById(int id)
        {
            var machine = _machine.FirstOrDefault(m => m.ID == id);

            if (machine == null)
                throw new CustomClientException("Machine not found.");
            return machine;
        }

        public async Task RemoveMachineStatus(object machineId)
        {

            int id = (int)machineId;
            var machine = _machine.FirstOrDefault(m => m.ID == id);

            if (machine == null)
                throw new CustomClientException("Machine not found.");

            _machine.Remove(machine);

        }

        public async Task AddMachineStatus(MachineStatusVM machineViewModel)
        {
            int newID = (_machine == null || _machine.Count == 0) ? 0:  _machine.Max(m => m.ID)+1;
            MachineValidations.ValidateName(newID, machineViewModel.MachineName, _machine);
            MachineValidations.ValidateStatus(machineViewModel.Status);
            machineViewModel.ID = newID;

            MachineStatus machine = new MachineStatus()
            {
                ID = newID,
                Description = machineViewModel.Description,
                Notes = machineViewModel.Notes,
                MachineName = machineViewModel.MachineName,
                Status = machineViewModel.Status,
                StatusImage = machineViewModel.StatusImage
            };

            _machine.Add(machine);

        }

        public async Task UpdateMachineStatus(MachineStatusVM machineToUpdate)
        {
            MachineValidations.ValidateName(machineToUpdate.ID, machineToUpdate.MachineName, _machine);
            MachineValidations.ValidateStatus(machineToUpdate.Status);

            int id = machineToUpdate.ID;
            var machine = _machine.FirstOrDefault(m => m.ID == id);

            if (machine == null)
                throw new CustomClientException("Machine not found.");

            machine.Status = machineToUpdate.Status;


        }
    }


}
