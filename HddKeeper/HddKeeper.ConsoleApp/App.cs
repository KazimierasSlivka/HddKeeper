using System;
using System.IO;
using HddKeeper.Contracts.Interfaces;
using HddKeeper.Contracts.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace HddKeeper.ConsoleApp
{
    public class App
    {
        private readonly IFileSimulator _fileSimulator;
        public App(IFileSimulator fileSimulator)
        {
            _fileSimulator = fileSimulator;
        }

        public void Run()
        {
            OnSuccessConfigRead(ReadAppSettingsJson());
        }

        private void OnSuccessConfigRead(Config config)
        {
            _fileSimulator.TempFileManipulation(config);
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
