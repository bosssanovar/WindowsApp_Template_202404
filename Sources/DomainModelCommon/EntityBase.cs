namespace DomainModelCommon
{
    /// <summary>
    /// 設定値群Entityのベースクラス
    /// </summary>
    /// <typeparam name="T">実装クラスの型</typeparam>
    public abstract class EntityBase<T>
    {
        /// <summary>
        /// インスタンスをディープクローンします。
        /// </summary>
        /// <returns>ディープクローンされたインスタンス</returns>
        public virtual T Clone()
        {
            return (T)MemberwiseClone();
        }
    }
}
