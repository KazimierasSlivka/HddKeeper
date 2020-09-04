using HddKeeper.Contracts.Models;
using HddKeeper.Contracts.Interfaces;
using Newtonsoft.Json;
using System.IO;

namespace HddKeeper.BusinessLogic
{
    public class ConfigurationReader : IConfigurationReader
    {
        public Config ReadConfigurationsJson()
        {
            return JsonConvert.DeserializeObject<Config>(File.ReadAllText("appsettings.json"));
        }
    }
}
