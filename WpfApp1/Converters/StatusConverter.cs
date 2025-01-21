using Microsoft.Extensions.DependencyInjection;
using System;
using System.Globalization;
using System.Windows.Data;
using WpfApp1.Factories;
using WpfApp1.Services;

namespace WpfApp1.Converters
{
    public class StatusConverter : IValueConverter
    {
        private readonly IStatusService _statusService;

        public StatusConverter()
        {
            // This could be injected via DI or created through a factory
            _statusService =  App.AppHost.Services.GetRequiredService<IStatusService>();
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int status)
            {
                return _statusService.TranslateStatusToDescription(status);
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
