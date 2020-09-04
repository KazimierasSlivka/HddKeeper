using HddKeeper.Contracts.Models;
using HddKeeper.Contracts.Interfaces;
using System.Timers;

namespace HddKeeper.BusinessLogic
{
    public class FileSimulator : IFileSimulator
    {
        private readonly IFileRepository _fileRepository;
        private readonly IConfigurationReader _configurationReader;
        private static Timer _timer;
        public FileSimulator(IFileRepository fileRepository, IConfigurationReader configurationReader)
        {
            _fileRepository = fileRepository;
            _configurationReader = configurationReader;
        }

        public void TempFileManipulation()
        {
            var config = _configurationReader.ReadConfigurationsJson();
            _timer = new Timer();
            _timer.Interval = config.RefreshTime;

            _timer.Elapsed += (object source, ElapsedEventArgs e) =>
            {
                foreach (var path in config.FakeFilePaths)
                {
                    _fileRepository.CreateFakeFileInDirectory(path);
                    _fileRepository.DeleteFakeFileInDirectory(path);
                }
            };

            _timer.AutoReset = true;

            _timer.Enabled = true;
        }
    }
}
