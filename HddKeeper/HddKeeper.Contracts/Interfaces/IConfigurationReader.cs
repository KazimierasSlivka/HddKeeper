using HddKeeper.Contracts.Models;

namespace HddKeeper.Contracts.Interfaces
{
    public interface IConfigurationReader
    {
        Config ReadConfigurationsJson();
    }
}
