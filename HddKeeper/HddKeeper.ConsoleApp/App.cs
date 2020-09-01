using System;
using System.Timers;
using HddKeeper.Contracts.Interfaces;

namespace HddKeeper.ConsoleApp
{
    public class App
    {
        private readonly IDriveController _driveController;
        private static Timer _timer;
        public App(IDriveController driveController)
        {
            _driveController = driveController;
        }

        public void Run()
        {
            SimulateTempFile();
            Console.WriteLine("Press the Enter key to exit the program at any time... ");
            Console.ReadLine();
        }

        private void SimulateTempFile()
        {
            _timer = new Timer();
            _timer.Interval = 10000;

            _timer.Elapsed += (object source, ElapsedEventArgs e) =>
            {
                _driveController.CreateFakeFileInDirectory("D:/");
                _driveController.DeleteFakeFileInDirectory("D:/");
            };

            _timer.AutoReset = true;

            _timer.Enabled = true;
        }
    }
}
