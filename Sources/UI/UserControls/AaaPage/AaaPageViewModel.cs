using AaaEntity.ValueObject;

using DomainService;

using Reactive.Bindings;
using Reactive.Bindings.Extensions;

using System.Reactive.Linq;
using System.Windows;

namespace UiParts.UserControls.AaaPage
{
    /// <summary>
    /// AAAページの疑似ViewModel
    /// </summary>
    public partial class AaaPageView
    {
        #region Constants -------------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Fields ----------------------------------------------------------------------------------------

        private AaaPageModel? _model;

        #endregion --------------------------------------------------------------------------------------------

        #region Properties ------------------------------------------------------------------------------------

        /// <summary>
        /// WWW設定
        /// </summary>
        public ReactivePropertySlim<bool> WwwVal { get; private set; } = new(false);

        /// <summary>
        /// XXX設定
        /// </summary>
        public ReactivePropertySlim<XxxType> XxxVal { get; private set; } = new(XxxType.Xxx1);

        /// <summary>
        /// XXX設定の選択肢
        /// </summary>
        public List<ComboBoxItem<XxxType>> XxxComboItems { get; private set; } = [];

        /// <summary>
        /// XXX設定の有効無効
        /// </summary>
        public ReadOnlyReactivePropertySlim<bool> XxxEnabled { get; private set; }

        /// <summary>
        /// YYY設定
        /// </summary>
        public ReactivePropertySlim<int> YyyVal { get; private set; } = new(0);

        /// <summary>
        /// ZZZ設定
        /// </summary>
        public ReactivePropertySlim<int> ZzzVal { get; private set; } = new(0);

        /// <summary>
        /// AAA設定
        /// </summary>
        public ReactivePropertySlim<int> AaaVal { get; private set; } = new(0);

        #endregion --------------------------------------------------------------------------------------------

        #region Events ----------------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Constructor -----------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - public ------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - internal ----------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - protected ---------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - private -----------------------------------------------------------------------------

        private void AaaPageViewModel(AaaPageModel model)
        {
            _model = model;

            WwwVal = _model.AaaEntity.ToReactivePropertySlimAsSynchronized(
                x => x.Value,
                x => x.Www.Value,
                x =>
                {
                    var value = x;

                    var entity = _model.AaaEntity.Value;
                    entity.Www = new(value);

                    _model.ForceNotifyAaaEntity();

                    return entity;
                },
                mode: ReactivePropertyMode.DistinctUntilChanged)
                .AddTo(_compositeDisposable);

            XxxVal = _model.AaaEntity.ToReactivePropertySlimAsSynchronized(
                x => x.Value,
                x => x.Xxx.Value,
                x =>
                {
                    var value = x;

                    var entity = _model.AaaEntity.Value;
                    entity.Xxx = new(value);

                    _model.ForceNotifyAaaEntity();

                    return entity;
                },
                mode: ReactivePropertyMode.DistinctUntilChanged)
                .AddTo(_compositeDisposable);

            XxxComboItems =
            [
                new(XxxType.Xxx1, XxxType.Xxx1.GetDisplayText()),
                new(XxxType.Xxx2, XxxType.Xxx2.GetDisplayText()),
                new(XxxType.Xxxxxx3, XxxType.Xxxxxx3.GetDisplayText()),
            ];

            XxxEnabled = _model.AaaEntity
                .Select(x => x.Www.Value)
                .ToReadOnlyReactivePropertySlim()
                .AddTo(_compositeDisposable);

            YyyVal = _model.AaaEntity.ToReactivePropertySlimAsSynchronized(
                x => x.Value,
                x => x.Yyy.Value,
                x =>
                {
                    int value = x;
                    if (!YyyVO.IsValid(value))
                    {
                        MessageBox.Show("設定可能な数値ではありません。\n補正します。", "警告", MessageBoxButton.OK, MessageBoxImage.Warning);

                        value = YyyVO.CurrectValue(value);
                    }

                    var entity = _model.AaaEntity.Value;
                    entity.SetYyy(new(value), new YyyChangedEvent(_model.AaaEntity.Value, _model.CccEntity.Value));

                    _model.ForceNotifyAaaEntity();

                    return entity;
                },
                mode: ReactivePropertyMode.DistinctUntilChanged)
                .AddTo(_compositeDisposable);

            ZzzVal = _model.AaaEntity.ToReactivePropertySlimAsSynchronized(
                x => x.Value,
                x => x.Zzz.Value,
                x =>
                {
                    int value = x;
                    if (!ZzzVO.IsValid(value))
                    {
                        var currected = ZzzVO.CurrectValue(value);
                        MessageBox.Show($"設定範囲外のため、補正します。\n{value} → {currected}", "警告", MessageBoxButton.OK, MessageBoxImage.Warning);

                        value = currected;
                    }

                    var entity = _model.AaaEntity.Value;

                    if (entity.IsHaveToCorrectAaa(value))
                    {
                        if (MessageBox.Show(
                            "ZZZ設定の変更によりAAA設定の設定値が補正され、それに関わる項目も補正される可能性があります。\n\nZZZ設定を変更しますか？",
                            "確認",
                            MessageBoxButton.YesNo,
                            MessageBoxImage.Question,
                            MessageBoxResult.No) == MessageBoxResult.Yes)
                        {
                            entity.SetZzz(new(value), new AaaChangedEvent(_model.AaaEntity.Value, _model.BbbEntity.Value));
                        }
                    }
                    else
                    {
                        entity.SetZzz(new(value), new AaaChangedEvent(_model.AaaEntity.Value, _model.BbbEntity.Value));
                    }

                    _model.ForceNotifyAaaEntity();
                    _model.ForceNotifyBbbEntity();

                    return entity;
                },
                mode: ReactivePropertyMode.DistinctUntilChanged)
                .AddTo(_compositeDisposable);

            AaaVal = _model.AaaEntity.ToReactivePropertySlimAsSynchronized(
                x => x.Value,
                x => x.Aaa.Value,
                x =>
                {
                    var entity = _model.AaaEntity.Value;

                    if (entity.IsValidAaa(x))
                    {
                        MessageBox.Show("ZZZ設定を超える値を設定できません。");
                    }
                    else
                    {
                        entity.SetAaa(new(x), new AaaChangedEvent(_model.AaaEntity.Value, _model.BbbEntity.Value));
                    }

                    _model.ForceNotifyAaaEntity();
                    _model.ForceNotifyBbbEntity();

                    return entity;
                },
                mode: ReactivePropertyMode.DistinctUntilChanged)
                .AddTo(_compositeDisposable);
        }

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - override ----------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Inner Class/Enum/etc. -------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------
    }
}
