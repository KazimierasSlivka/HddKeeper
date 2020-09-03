using HddKeeper.Contracts.Models;
using HddKeeper.Contracts.Interfaces;
using System.Timers;

namespace HddKeeper.BusinessLogic
{
    public class FileSimulator : IFileSimulator
    {
        private readonly IFileRepository _fileRepository;
        private static Timer _timer;
        public FileSimulator(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public void TempFileManipulation(Config config)
        {
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
