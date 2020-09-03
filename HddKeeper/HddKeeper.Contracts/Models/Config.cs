using System.Collections.Generic;

namespace HddKeeper.Contracts.Models
{
    public class Config
    {
        public int RefreshTime { get; set; }
        public IList<string> FakeFilePaths { get; set; }
    }
}
