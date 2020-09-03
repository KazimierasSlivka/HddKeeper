using System;
using System.IO;
using System.Timers;
using HddKeeper.Contracts.Interfaces;
using HddKeeper.Contracts.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace HddKeeper.ConsoleApp
{
    public class App
    {
        private readonly IDriveController DriveController;
        private static Timer _timer;
        public App(IDriveController DriveController)
        {
            this.DriveController = DriveController;
        }

        public void Run()
        {
            ReadAppSettingsJson();

        }

        private void SimulateTempFile()
        {
            _timer = new Timer();
            _timer.Interval = 10000;

            _timer.Elapsed += (object source, ElapsedEventArgs e) =>
            {
                DriveController.CreateFakeFileInDirectory("D:/");
                DriveController.DeleteFakeFileInDirectory("D:/");
            };

            _timer.AutoReset = true;

            _timer.Enabled = true;
        }

        private void OnSuccessConfigRead()
        {
            SimulateTempFile();
            Console.WriteLine();
            Console.WriteLine("Press the Enter key to exit the program at any time... ");
            Console.ReadLine();
        }

        private Config ReadAppSettingsJson()
        {
            string configJson = File.ReadAllText("appsettings.json");
            var config = JsonConvert.DeserializeObject<Config>(configJson);

            return config;
        }
    }
}
