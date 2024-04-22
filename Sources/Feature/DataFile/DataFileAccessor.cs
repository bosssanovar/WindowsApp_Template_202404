using DomainService;

using System.Text.Json;

namespace Feature.DataFile
{
    public class DataFileAccessor(IDataFileAccessor _fileAccessor)
    {
        public void Save(DataPacket packet)
        {
            var jsonString = JsonSerializer.Serialize(packet);

            _fileAccessor.Save(jsonString);
        }

        public bool Load(ref DataPacket packet)
        {
            string content = string.Empty;
            var result = _fileAccessor.Load(ref content);

            if (!result)
            {
                return false;
            }

            var p = JsonSerializer.Deserialize<DataPacket>(content);
            if(p is null)
            {
                return false;
            }

            packet = p;
            return true;
        }
    }
}
