using Newtonsoft.Json;

namespace WpfApp1.Models
{
    public class Machine
    {
        [JsonProperty("MachineName")]
        public string Name { get; set; }
    }

}
