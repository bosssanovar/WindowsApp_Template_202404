namespace AaaEntity.DomainSreviceInterface
{
    /// <summary>
    /// AAAの設定に関連する設定値を補正するインターフェース
    /// </summary>
    public interface IAaaChangedEvent
    {
        /// <summary>
        /// 補正します。
        /// </summary>
        void Execute();
    }
}
