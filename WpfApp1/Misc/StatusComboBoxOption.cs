namespace WpfApp1.Misc
{
    public class StatusComboBoxOption
    {
        public string DisplayName { get; set; }
        public int Value { get; set; }

        public StatusComboBoxOption(string displayName, int value)
        {
            DisplayName = displayName;
            Value = value;
        }
    }

}
