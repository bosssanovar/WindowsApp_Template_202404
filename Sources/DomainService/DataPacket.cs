using AAAEntity.DataPacket;

using BBBEntity.DataPacket;

namespace DomainService
{
    public class DataPacket
    {
        public AAAEntityPacket AAAEntityPacket { get; set; } = new();
        public BBBEntityPacket BBBEntityPacket { get; set; } = new();
    }
}
