using AAAEntity.ValueObject;

using DomainService;

using Reactive.Bindings;
using Reactive.Bindings.Extensions;

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
        /// XXX設定
        /// </summary>
        public ReactivePropertySlim<XXXType> XXXVal { get; private set; } = new(XXXType.Xxx1);

        /// <summary>
        /// XXX設定の選択肢
        /// </summary>
        public List<ComboBoxItem<XXXType>> XXXComboItems { get; private set; } = [];

        /// <summary>
        /// YYY設定
        /// </summary>
        public ReactivePropertySlim<int> YYYVal { get; private set; } = new(0);

        /// <summary>
        /// ZZZ設定
        /// </summary>
        public ReactivePropertySlim<int> ZZZVal { get; private set; } = new(0);

        /// <summary>
        /// AAA設定
        /// </summary>
        public ReactivePropertySlim<int> AAAVal { get; private set; } = new(0);

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

            XXXVal = _model.AaaEntity.ToReactivePropertySlimAsSynchronized(
                x => x.Value,
                x => x.XXX.Value,
                x =>
                {
                    var value = x;

                    var entity = _model.AaaEntity.Value;
                    entity.XXX = new(value);

                    _model.ForceNotifyAaaEntity();

                    return entity;
                },
                mode: ReactivePropertyMode.DistinctUntilChanged)
                .AddTo(_compositeDisposable);

            XXXComboItems = new List<ComboBoxItem<XXXType>>()
            {
                new(XXXType.Xxx1, XXXType.Xxx1.GetDisplayText()),
                new(XXXType.Xxx2, XXXType.Xxx2.GetDisplayText()),
                new(XXXType.Xxxxxx3, XXXType.Xxxxxx3.GetDisplayText()),
            };

            YYYVal = _model.AaaEntity.ToReactivePropertySlimAsSynchronized(
                x => x.Value,
                x => x.YYY.Value,
                x =>
                {
                    int value = x;
                    if (!YYYVO.IsValid(value))
                    {
                        MessageBox.Show("設定可能な数値ではありません。\n補正します。", "警告", MessageBoxButton.OK, MessageBoxImage.Warning);

                        value = YYYVO.CurrectValue(value);
                    }

                    var entity = _model.AaaEntity.Value;
                    entity.SetYYY(new(value), new YYYChangedEvent(_model.AaaEntity.Value, _model.CccEntity.Value));

                    _model.ForceNotifyAaaEntity();

                    return entity;
                },
                mode: ReactivePropertyMode.DistinctUntilChanged)
                .AddTo(_compositeDisposable);

            ZZZVal = _model.AaaEntity.ToReactivePropertySlimAsSynchronized(
                x => x.Value,
                x => x.ZZZ.Value,
                x =>
                {
                    int value = x;
                    if (!ZZZVO.IsValid(value))
                    {
                        var currected = ZZZVO.CurrectValue(value);
                        MessageBox.Show($"設定範囲外のため、補正します。\n{value} → {currected}", "警告", MessageBoxButton.OK, MessageBoxImage.Warning);

                        value = currected;
                    }

                    var entity = _model.AaaEntity.Value;

                    if (entity.IsHaveToCorrectAAA(value))
                    {
                        if (MessageBox.Show(
                            "ZZZ設定の変更によりAAA設定の設定値が補正され、それに関わる項目も補正される可能性があります。\n\nZZZ設定を変更しますか？",
                            "確認",
                            MessageBoxButton.YesNo,
                            MessageBoxImage.Question,
                            MessageBoxResult.No) == MessageBoxResult.Yes)
                        {
                            entity.SetZZZ(new(value), new AAAChangedEvent(_model.AaaEntity.Value, _model.BbbEntity.Value));
                        }
                    }
                    else
                    {
                        entity.SetZZZ(new(value), new AAAChangedEvent(_model.AaaEntity.Value, _model.BbbEntity.Value));
                    }

                    _model.ForceNotifyAaaEntity();
                    _model.ForceNotifyBbbEntity();

                    return entity;
                },
                mode: ReactivePropertyMode.DistinctUntilChanged)
                .AddTo(_compositeDisposable);

            AAAVal = _model.AaaEntity.ToReactivePropertySlimAsSynchronized(
                x => x.Value,
                x => x.AAA.Value,
                x =>
                {
                    var entity = _model.AaaEntity.Value;

                    if (entity.IsValidAAA(x))
                    {
                        MessageBox.Show("ZZZ設定を超える値を設定できません。");
                    }
                    else
                    {
                        entity.SetAAA(new(x), new AAAChangedEvent(_model.AaaEntity.Value, _model.BbbEntity.Value));
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
