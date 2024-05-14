using AaaEntity.ValueObject;

using BbbEntity.ValueObject;

using DomainService;

using Reactive.Bindings;
using Reactive.Bindings.Extensions;

using System.Text;
using System.Windows;

using UiParts.UiWindow.Message;

namespace UiParts.UserControls.AaaAndBbbPage
{
    /// <summary>
    /// AAA and BBBページの疑似ViewModel
    /// </summary>
    public partial class AaaAndBbbPageView
    {
        #region Constants -------------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Fields ----------------------------------------------------------------------------------------

        private AaaAndBbbPageModel? _model;

        #endregion --------------------------------------------------------------------------------------------

        #region Properties ------------------------------------------------------------------------------------

        /// <summary>
        /// YYY設定値
        /// </summary>
        public ReactivePropertySlim<int> YyyVal { get; private set; } = new(0);

        /// <summary>
        /// ZZZ設定値
        /// </summary>
        public ReactivePropertySlim<int> ZzzVal { get; private set; } = new(0);

        /// <summary>
        /// AAA設定値
        /// </summary>
        public ReactivePropertySlim<int> AaaVal { get; private set; } = new(0);

        /// <summary>
        /// BBB設定値
        /// </summary>
        public ReactivePropertySlim<string> BbbVal { get; private set; } = new(string.Empty);

        /// <summary>
        /// BBB2設定値
        /// </summary>
        public ReactivePropertySlim<string> Bbb2Val { get; private set; } = new(string.Empty);

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

        private void AaaAndBbbPageViewModel(AaaAndBbbPageModel model)
        {
            _model = model;

            YyyVal = _model.AaaEntity.ToReactivePropertySlimAsSynchronized(
                x => x.Value,
                x => x.Yyy.Value,
                x =>
                {
                    int value = x;
                    if (!YyyVO.IsValid(value))
                    {
                        MessageWindow.Show("設定可能な数値ではありません。\n補正します。", "警告", MessageBoxButton.OK, MessageBoxImage.Warning);

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
                        MessageWindow.Show($"設定範囲外のため、補正します。\n{value} → {currected}", "警告", MessageBoxButton.OK, MessageBoxImage.Warning);

                        value = currected;
                    }

                    var entity = _model.AaaEntity.Value;

                    if (entity.IsHaveToCorrectAaa(value))
                    {
                        if (MessageWindow.Show(
                            "ZZZ設定の変更によりAAA設定の設定値が補正され、それに関わる項目も補正される可能性があります。\n\nZZZ設定を変更しますか？",
                            "確認",
                            MessageBoxButton.YesNo,
                            MessageBoxImage.Question) == MessageBoxResult.Yes)
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
                        MessageWindow.Show("ZZZ設定を超える値を設定できません。", string.Empty);
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

            BbbVal = _model.BbbEntity.ToReactivePropertySlimAsSynchronized(
                x => x.Value,
                x => x.Bbb.Value,
                x =>
                {
                    var text = x;

                    var lengthChecker = new BbbLehgthChecker(_model.AaaEntity.Value);
                    if (!lengthChecker.IsValid(text))
                    {
                        MessageWindow.Show(
                            "AAA設定指定の文字数に丸め込みます。",
                            "確認");

                        text = lengthChecker.Substring(text);
                    }

                    var entity = _model.BbbEntity.Value;
                    entity.SetBbb(new(text), lengthChecker);

                    _model.ForceNotifyBbbEntity();

                    return entity;
                },
                mode: ReactivePropertyMode.DistinctUntilChanged)
                .AddTo(_compositeDisposable);

            Bbb2Val = _model.BbbEntity.ToReactivePropertySlimAsSynchronized(
                x => x.Value,
                x => x.Bbb2.Value,
                x =>
                {
                    var text = x;
                    var message = new StringBuilder();

                    if (!Bbb2VO.IsValid(text))
                    {
                        text = Bbb2VO.CurrectValue(text);

                        message.AppendLine("半角英数字以外は削除されます。");
                    }

                    var lengthChecker = new BbbLehgthChecker(_model.AaaEntity.Value);
                    if (!lengthChecker.IsValid(text))
                    {
                        text = lengthChecker.Substring(text);

                        message.AppendLine("AAA設定指定の文字数に丸め込みます。");
                    }

                    if (message.Length > 0)
                    {
                        MessageWindow.Show(message.ToString(), "確認");
                    }

                    var entity = _model.BbbEntity.Value;
                    entity.SetBbb2(new(text), lengthChecker);

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
