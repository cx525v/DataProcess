using DataProcess.FiileMgnt;
using Newtonsoft.Json;

namespace DataProcess.DataAccess
{
   public class JsonObjectReader<T> : IJsonObjectReader<T>
    {
        private readonly IFileMgr _fileMgr;
        public JsonObjectReader(IFileMgr fileMgr)
        {
            this._fileMgr = fileMgr;
        }
        public T GetData(string path)
        {
            string json = this._fileMgr.GetContent(path);
            T o = JsonConvert.DeserializeObject<T>(json);

            return o;
        }
    }
}
