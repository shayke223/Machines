using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1.Services.Dialogs
{
    public interface IDialogService
    {
        T ShowDialog<T>(Window dialog) where T : class;
        void ShowErrorMessage(string message);
        void ShowErrorMessage();
        bool ShowConfirmationDialog(string message, string title = "Confirmation");
        void ShowMessage(string message, string header = "");
    }

}
