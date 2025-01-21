using WpfApp1.Misc;

public interface IStatusService
{
    string TranslateStatusToDescription(int statusCode);
    string TranslateStatusToImagePath(int statusCode);
    List<StatusComboBoxOption> GetStatusOptionsForComboBox();
    Task<List<StatusComboBoxOption>> GetStatusOptionsForComboBoxAsync();
    void AddSelectAllStatus(List<StatusComboBoxOption> options);
}



