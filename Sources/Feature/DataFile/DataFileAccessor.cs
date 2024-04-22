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
    }
}
