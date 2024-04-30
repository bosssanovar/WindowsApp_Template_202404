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
    internal class CccDetailViewModel : INotifyPropertyChanged, IDisposable
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

            var count = _model.Entity.Value.Detail.Count;
            for (int i = 0; i < count; i++)
            {
                int index = i;
                var sp = _model.Entity.ToReactivePropertySlimAsSynchronized(
                    x => x.Value,
                    x => x.Detail[index].Value,
                    x =>
                    {
                        var corrected = CCCVO.CurrectValue(x);
                        _model.Entity.Value.Detail[index] = new(corrected);

                        _model.ForceNotify();

                        return _model.Entity.Value;
                    },
                    ReactivePropertyMode.DistinctUntilChanged)
                    .AddTo(_disposable);

                CCCs.Add(sp);
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
