using CCCEntity.ValueObject;

using Reactive.Bindings;
using Reactive.Bindings.Extensions;

using System.ComponentModel;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace UiParts.UserControls.CccPage
{
    /// <summary>
    /// CCC Detail ViewModelクラス
    /// </summary>
    public class CccDetailViewModel : INotifyPropertyChanged, IDisposable
    {
        #region Constants -------------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Fields ----------------------------------------------------------------------------------------

        private readonly CccDetailModel _model;

        private readonly CompositeDisposable _disposable = [];

        #endregion --------------------------------------------------------------------------------------------

        #region Properties ------------------------------------------------------------------------------------

        /// <summary>
        /// Ccc設定
        /// </summary>
        public List<ReactivePropertySlim<bool>> CCCs { get; } = [];

        #endregion --------------------------------------------------------------------------------------------

        #region Events ----------------------------------------------------------------------------------------

        /// <summary>
        /// 変更通知イベント（ReactiveProperty採用時のメモリリーク対策）
        /// </summary>
#pragma warning disable CS0067 // イベント 'DetailViewModel.PropertyChanged' は使用されていません
        public event PropertyChangedEventHandler? PropertyChanged;
#pragma warning restore CS0067 // イベント 'DetailViewModel.PropertyChanged' は使用されていません

        #endregion --------------------------------------------------------------------------------------------

        #region Constructor -----------------------------------------------------------------------------------

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="model">コレクション型のModel</param>
        public CccDetailViewModel(CccDetailModel model)
        {
            _model = model;

            var count = _model.Detail.Value.CCCs.Count;
            for (int i = 0; i < count; i++)
            {
                int index = i;
                var ccc = new ReactivePropertySlim<bool>(_model.Detail.Value.CCCs[index].Value);
                ccc.Subscribe(
                    x =>
                    {
                        var correct = new CCCVO(x);
                        _model.Detail.Value.CCCs[index] = correct;
                    })
                    .AddTo(_disposable);

                CCCs.Add(ccc);
            }
        }

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - public ------------------------------------------------------------------------------

        /// <summary>
        /// オブジェクトの後始末
        /// </summary>
        public void Dispose()
        {
            _disposable.Dispose();
        }

        /// <summary>
        /// 設定値を反転します。
        /// </summary>
        /// <param name="index">要素インデックス</param>
        internal void Invert(int index)
        {
            CCCs[index].Value = !CCCs[index].Value;
        }

        /// <summary>
        /// 一括設定します。
        /// </summary>
        /// <param name="v">設定値</param>
        internal void SetAll(bool v)
        {
            CCCs.ForEach(x => x.Value = v);
        }

        /// <summary>
        /// 設定をＯＮします。
        /// </summary>
        /// <param name="index">インデックス</param>
        internal void SetOn(int index)
        {
            CCCs[index].Value = true;
        }

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - internal ----------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - protected ---------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - private -----------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - override ----------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Inner Class/Enum ------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------
    }
}
