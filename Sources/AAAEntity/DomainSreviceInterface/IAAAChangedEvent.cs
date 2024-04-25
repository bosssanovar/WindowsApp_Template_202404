namespace AAAEntity.DomainSreviceInterface
{
    /// <summary>
    /// AAAEntityの設定に関連する設定値を補正するインターフェース
    /// </summary>
    public interface IAAAChangedEvent
    {
        /// <summary>
        /// 補正します。
        /// </summary>
        void Execute();
    }
}
