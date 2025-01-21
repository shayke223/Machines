using WpfApp1.Misc;

public class StatusTranslationService : IStatusService
{
    private readonly Dictionary<int, StatusOption> _statusDictionary;

    public StatusTranslationService()
    {
        _statusDictionary = new Dictionary<int, StatusOption>
        {
            { 10, new StatusOption("Idle", "Assets/idle.png") },
            { 20, new StatusOption("Offline", "Assets/offline.png") },
            { 30, new StatusOption("Running", "Assets/running.png") },
            { -1, new StatusOption("Unknown", "Assets/unknown.png") }
        };
    }

    public string TranslateStatusToDescription(int statusCode)
    {
     
        return _statusDictionary.ContainsKey(statusCode)
            ? _statusDictionary[statusCode].Description
            : _statusDictionary[-1].Description;  // Default to Unknown
    }

    public string TranslateStatusToImagePath(int statusCode)
    {
      
        return _statusDictionary.ContainsKey(statusCode)
            ? _statusDictionary[statusCode].ImagePath
            : _statusDictionary[-1].ImagePath;  // Default to Unknown image
    }

    public async Task<List<StatusComboBoxOption>> GetStatusOptionsForComboBoxAsync()
    {
        return await Task.Run(() =>
            GetStatusOptionsForComboBox()
        );
    }
    public List<StatusComboBoxOption> GetStatusOptionsForComboBox()
    {

        return _statusDictionary
            .Where(kvp => kvp.Key != -1) // Assuming -1 represents "Unknown"
            .Select(kvp => new StatusComboBoxOption(kvp.Value.Description, kvp.Key))
            .ToList();
    }


    public void AddSelectAllStatus(List<StatusComboBoxOption> options)
    {

        if (!options.Any(option => option.Value == Constants.StatusCodes.SelectAll))
            options.Insert(0, new StatusComboBoxOption("Select All", Constants.StatusCodes.SelectAll));
        
    }

}



