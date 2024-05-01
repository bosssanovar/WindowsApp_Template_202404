namespace AAAEntity.DomainSreviceInterface
{
    /// <summary>
    /// YYYの設定に関連する設定値を補正するインターフェース
    /// </summary>
    public interface IYYYChangedEvent
    {
        /// <summary>
        /// 補正します。
        /// </summary>
        void Execute();
    }
}
