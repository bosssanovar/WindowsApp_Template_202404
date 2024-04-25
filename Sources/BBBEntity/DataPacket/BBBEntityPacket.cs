namespace BBBEntity.DataPacket
{
    /// <summary>
    /// BBB Entityの設定データ群
    /// </summary>
    public class BBBEntityPacket
    {
        /// <summary>
        /// BBB設定
        /// </summary>
        public string BBB { get; set; } = string.Empty;

        /// <summary>
        /// BBB2設定
        /// </summary>
        public string BBB2 { get; set; } = string.Empty;
    }
}
