using System.Reactive.Disposables;

namespace UiParts.UiWindow
{
    /// <summary>
    /// WindowのベースModelクラス
    /// </summary>
    public abstract class WindowModelBase : IDisposable
    {
        /// <summary>
        /// 破棄予約リスト
        /// </summary>
#pragma warning disable SA1401 // Fields should be private
#pragma warning disable CA1051 // 参照可能なインスタンス フィールドを宣言しません
        protected readonly CompositeDisposable _compositeDisposable = [];
#pragma warning restore CA1051 // 参照可能なインスタンス フィールドを宣言しません
#pragma warning restore SA1401 // Fields should be private

        /// <summary>
        /// 破棄します。
        /// </summary>
        public void Dispose()
        {
            _compositeDisposable.Dispose();
        }
    }
}
