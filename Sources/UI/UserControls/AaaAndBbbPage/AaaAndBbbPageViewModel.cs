using AAAEntity.ValueObject;

using BBBEntity.ValueObject;

using DomainService;

using Reactive.Bindings;
using Reactive.Bindings.Extensions;

using System.Text;
using System.Windows;

namespace UiParts.UserControls.AaaAndBbbPage
{
    /// <summary>
    /// AAA and BBBページの疑似ViewModel
    /// </summary>
    public partial class AaaAndBbbPageView
    {
        private AaaAndBbbPageModel? _model;

        /// <summary>
        /// YYY設定値
        /// </summary>
        public ReactivePropertySlim<int> YYYVal { get; private set; } = new(0);

        /// <summary>
        /// ZZZ設定値
        /// </summary>
        public ReactivePropertySlim<int> ZZZVal { get; private set; } = new(0);

        /// <summary>
        /// AAA設定値
        /// </summary>
        public ReactivePropertySlim<int> AAAVal { get; private set; } = new(0);

        /// <summary>
        /// BBB設定値
        /// </summary>
        public ReactivePropertySlim<string> BBBVal { get; private set; } = new(string.Empty);

        /// <summary>
        /// BBB2設定値
        /// </summary>
        public ReactivePropertySlim<string> BBB2Val { get; private set; } = new(string.Empty);

        private void AaaAndBbbPageViewModel(AaaAndBbbPageModel model)
        {
            _model = model;

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
                    entity.YYY = new(value);

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

            BBBVal = _model.BbbEntity.ToReactivePropertySlimAsSynchronized(
                x => x.Value,
                x => x.BBB.Value,
                x =>
                {
                    var text = x;

                    var lengthChecker = new BBBLehgthChecker(_model.AaaEntity.Value);
                    if (!lengthChecker.IsValid(text))
                    {
                        MessageBox.Show(
                            "AAA設定指定の文字数に丸め込みます。",
                            "確認");

                        text = lengthChecker.Substring(text);
                    }

                    var entity = _model.BbbEntity.Value;
                    entity.SetBBB(new(text), lengthChecker);

                    _model.ForceNotifyBbbEntity();

                    return entity;
                },
                mode: ReactivePropertyMode.DistinctUntilChanged)
                .AddTo(_compositeDisposable);

            BBB2Val = _model.BbbEntity.ToReactivePropertySlimAsSynchronized(
                x => x.Value,
                x => x.BBB2.Value,
                x =>
                {
                    var text = x;
                    var message = new StringBuilder();

                    if (!BBB2VO.IsValid(text))
                    {
                        text = BBB2VO.CurrectValue(text);

                        message.AppendLine("半角英数字以外は削除されます。");
                    }

                    var lengthChecker = new BBBLehgthChecker(_model.AaaEntity.Value);
                    if (!lengthChecker.IsValid(text))
                    {
                        text = lengthChecker.Substring(text);

                        message.AppendLine("AAA設定指定の文字数に丸め込みます。");
                    }

                    if (message.Length > 0)
                    {
                        MessageBox.Show(message.ToString(), "確認");
                    }

                    var entity = _model.BbbEntity.Value;
                    entity.SetBBB2(new(text), lengthChecker);

                    _model.ForceNotifyBbbEntity();

                    return entity;
                },
                mode: ReactivePropertyMode.DistinctUntilChanged)
                .AddTo(_compositeDisposable);
        }
    }
}
