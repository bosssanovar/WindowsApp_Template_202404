namespace DomainModelCommon
{
    /// <summary>
    /// インスタンス生成時に不正値が設定できないようにするためのベースクラス
    /// </summary>
    public abstract record RecordWithValidation
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        protected RecordWithValidation()
        {
            Validate();
        }

        /// <summary>
        /// 不正値を判定します。
        /// </summary>
        protected abstract void Validate();
    }
}
