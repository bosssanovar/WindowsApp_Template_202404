using AAAEntity.DataPacket;

using BBBEntity.DataPacket;

namespace DomainService
{
    /// <summary>
    /// 設定データ群
    /// </summary>
    public class DataPacket
    {
        /// <summary>
        /// AAA Entityの設定データ群
        /// </summary>
        public AAAEntityPacket AAAEntityPacket { get; set; } = new();

        /// <summary>
        /// BBB Entityの設定データ群
        /// </summary>
        public BBBEntityPacket BBBEntityPacket { get; set; } = new();
    }
}
