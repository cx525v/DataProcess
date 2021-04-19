using System.IO;

namespace DataProcess.FiileMgnt
{
    public class FileStreamReader : IStreamReader
    {
       public  StreamReader GetReader(string path)
        {
            return new StreamReader(path);
        }
    }
}
