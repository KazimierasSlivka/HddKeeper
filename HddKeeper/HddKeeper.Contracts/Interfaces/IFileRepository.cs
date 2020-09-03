using System;
using System.Collections.Generic;
using System.Text;

namespace HddKeeper.Contracts.Interfaces
{
    public interface IFileRepository
    {
        void CreateFakeFileInDirectory(string dir);
        void DeleteFakeFileInDirectory(string dir);
    }
}
