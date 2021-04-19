namespace DataProcess.DataAccess
{
    public interface IJsonObjectReader<T>
    {
        T GetData(string path);
    }
}
