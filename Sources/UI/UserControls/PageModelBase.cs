﻿using System.Reactive.Disposables;

namespace UiParts.UserControls
{
    /// <summary>
    /// ページのModelのベースクラス
    /// </summary>
    public abstract class PageModelBase : IDisposable
    {
        /// <summary>
        /// 破棄予約リスト
        /// </summary>
#pragma warning disable CA1051 // 参照可能なインスタンス フィールドを宣言しません
#pragma warning disable SA1401 // Fields should be private
        protected readonly CompositeDisposable _compositeDisposable = [];
#pragma warning restore SA1401 // Fields should be private
#pragma warning restore CA1051 // 参照可能なインスタンス フィールドを宣言しません

        /// <summary>
        /// 全てのEntityを更新します。
        /// </summary>
        public abstract void UpdateEntities();

        /// <summary>
        /// 全てのEntityの設定を確定します。
        /// </summary>
        public abstract void CommitEntities();

        /// <summary>
        /// 破棄します。
        /// </summary>
        public void Dispose()
        {
            _compositeDisposable.Dispose();
        }
    }
}
