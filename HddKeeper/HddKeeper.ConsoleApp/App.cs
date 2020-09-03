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
        private readonly IFileRepository DriveController;
        private static Timer _timer;
        public App(IFileRepository DriveController)
        {
            this.DriveController = DriveController;
        }

        public void Run()
        {
            var config = ReadAppSettingsJson();

            if (config != null)
            {
                if (config.RefreshTime <= 0)
                    Console.WriteLine("Refresh time must be greater than 0");

            }
            else
                Console.Write("Application settings error");

        }

        private void SimulateTempFile(Config config)
        {
            _timer = new Timer();
            _timer.Interval = config.RefreshTime;

            _timer.Elapsed += (object source, ElapsedEventArgs e) =>
            {
                DriveController.CreateFakeFileInDirectory("D:/");
                DriveController.DeleteFakeFileInDirectory("D:/");
            };

            _timer.AutoReset = true;

            _timer.Enabled = true;
        }

        private void OnSuccessConfigRead(Config config)
        {
            SimulateTempFile(config);
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
