namespace Feature.DataFile
{
    public interface IDataFileAccessor
    {
        bool Save(string content);

        bool Load(ref string content);
    }
}
