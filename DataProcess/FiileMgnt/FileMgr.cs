using System.IO;

namespace DataProcess.FiileMgnt
{
    public class FileMgr : IFileMgr
    {
        private readonly IStreamReader _fileReader;
        public FileMgr()
        {

        }
        public FileMgr(IStreamReader fileReader)
        {
            this._fileReader = fileReader;
        }

        public string GetContent(string path)
        {
            using StreamReader reader = _fileReader.GetReader(path);
            return reader.ReadToEnd();
        }
    }
}
