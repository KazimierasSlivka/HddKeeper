using System;
using System.IO;
using HddKeeper.Contracts.Interfaces;
using HddKeeper.Contracts.Models;
using Microsoft.Extensions.Configuration;


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
            _fileSimulator.TempFileManipulation();
            Console.WriteLine("Press the Enter key to exit the program at any time... ");
            Console.ReadLine();
        }
    }
}
