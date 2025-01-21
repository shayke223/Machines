using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1.Services.Dialogs
{
    internal class DialogService : IDialogService
    {

        public bool ShowConfirmationDialog(string message, string title = "Confirmation")
        {
            var result = MessageBox.Show(message, title, MessageBoxButton.YesNo, MessageBoxImage.Question);
            return result == MessageBoxResult.Yes;
        }

        public void ShowMessage(string message, string header = "")
        {
            MessageBox.Show(message, header, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public void ShowErrorMessage()
        {
            MessageBox.Show("An Error Occured.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        //Can show another custom window and retreive an output from it.
        public T ShowDialog<T>(Window dialog) where T : class
        {
            dialog.ShowDialog();
            if (dialog is IHaveOutput<T> dialogWithOutput)
            {
                return dialogWithOutput.GetOutput();
            }
            return null;
        }

    }
}
public interface IHaveOutput<T>
{
    T GetOutput();
}
