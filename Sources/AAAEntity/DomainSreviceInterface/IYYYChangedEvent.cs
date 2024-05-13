namespace AaaEntity.DomainSreviceInterface
{
    /// <summary>
    /// YYYの設定に関連する設定値を補正するインターフェース
    /// </summary>
    public interface IYyyChangedEvent
    {
        /// <summary>
        /// 補正します。
        /// </summary>
        void Execute();
    }
}
