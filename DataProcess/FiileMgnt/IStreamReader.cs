using System.IO;

namespace DataProcess.FiileMgnt
{
    public interface IStreamReader
    {
        StreamReader GetReader(string path);
    }
}
