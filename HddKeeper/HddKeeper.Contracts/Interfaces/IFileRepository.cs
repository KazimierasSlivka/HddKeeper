using System;
using System.Collections.Generic;
using System.Text;

namespace HddKeeper.Contracts.Interfaces
{
    public interface IDriveController
    {
        void CreateFakeFileInDirectory(string dir);
        void DeleteFakeFileInDirectory(string dir);
    }
}
