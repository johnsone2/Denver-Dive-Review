using System.IO;
using Domain;
using FilePersistence;

namespace BarTabService
{
    public class BarTabFileService : AbstractFilePersistenceService<BarTab>
    {
        private static readonly string _DevBarTabsFilePath = @"./bartabs.filedb";

        private string _filePath;
        public BarTabFileService()
        {
            _filePath = _DevBarTabsFilePath;
        }

        public static BarTabFileService ForTesting(string filePath)
        {
            return new BarTabFileService{ _filePath = filePath};
        }

        public override string FilePath { get { return _filePath; } }
    }
}