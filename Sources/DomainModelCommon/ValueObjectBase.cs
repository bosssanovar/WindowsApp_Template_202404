namespace DomainModelCommon
{
    /// <summary>
    /// 設定値Value Objectのベースクラス
    /// </summary>
    /// <typeparam name="T">設定値の型</typeparam>
    /// <param name="Value">設定値</param>
    public abstract record ValueObjectBase<T>(T Value) : RecordWithValidation
    {
    }
}
