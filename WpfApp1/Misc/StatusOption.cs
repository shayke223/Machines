namespace WpfApp1.Misc
{
    public class StatusOption
    {
        public string Description { get; set; }
        public string ImagePath { get; set; }

        public StatusOption(string description, string imagePath)
        {
            Description = description;
            ImagePath = imagePath;
        }
    }

}
