using System;
using System.IO;
using HddKeeper.Contracts.Interfaces;

namespace HddKeeper.BusinessLogic
{
    public class FileRepository : IFileRepository
    {
        private readonly string _tempFileName = "temp.txt";
        public void CreateFakeFileInDirectory(string dir)
        {
            using var tmp = File.Create(dir + _tempFileName);
        }

        public void DeleteFakeFileInDirectory(string dir)
        {
            File.Delete(dir + _tempFileName);
        }
    }
}
