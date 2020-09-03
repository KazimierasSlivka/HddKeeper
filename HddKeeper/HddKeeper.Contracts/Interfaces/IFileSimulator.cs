using HddKeeper.Contracts.Models;

namespace HddKeeper.Contracts.Interfaces
{
    public interface IFileSimulator
    {
        void TempFileManipulation(Config config);
    }
}
