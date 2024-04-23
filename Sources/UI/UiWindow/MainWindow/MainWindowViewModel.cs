using AAAEntity.ValueObject;

using BBBEntity.ValueObject;

using DomainService;

using Reactive.Bindings;
using Reactive.Bindings.Extensions;

using System.Text;
using System.Windows;


namespace UiParts.UiWindow.MainWindow
{
    public partial class MainWindowView
    {
        private Model? _model;

        public ReactivePropertySlim<int> YYYVal { get; private set; } = new(0);

        public ReactivePropertySlim<int> ZZZVal { get; private set; } = new(0);

        public ReactivePropertySlim<int> AAAVal { get; private set; } = new(0);

        public ReactivePropertySlim<string> BBBVal { get; private set; } = new(string.Empty);

        public ReactivePropertySlim<string> BBB2Val { get; private set; } = new(string.Empty);

        public ReactiveCommand InitializeCommand { get; } = new();

        public ReactiveCommand SaveCommand { get; } = new();

        public ReactiveCommand OpenCommand { get; } = new();

        private void MainWindowViewModel(Model model)
        {
            _model = model;

            YYYVal = _model.AaaEntity.ToReactivePropertySlimAsSynchronized(
                x => x.Value,
                x => x.YYY.Value,
                x =>
                {
                    var entity = _model.AaaEntity.Value;
                    entity.YYY = new(x);

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
                        MessageBox.Show("設定範囲超過のため、20に補正します。", "警告", MessageBoxButton.OK, MessageBoxImage.Warning);

                        value = ZZZVO.CurrectValue(value);
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

                    if (entity.IsOverZZZ(x))
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
                    StringBuilder message = new StringBuilder();

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

            InitializeCommand.Subscribe(() =>
            {
                if (MessageBox.Show(
                            "初期化を実行しますか？",
                            "確認",
                            MessageBoxButton.YesNo,
                            MessageBoxImage.Question,
                            MessageBoxResult.No) == MessageBoxResult.Yes)
                {
                    _model.Initialize();
                }
            })
                .AddTo(_compositeDisposable);

            SaveCommand.Subscribe(() =>
            {
                var result = _model.SaveDataFile();

                if (result)
                {
                    MessageBox.Show("データを保存しました。", "情報");
                }
            })
                .AddTo(_compositeDisposable);

            OpenCommand.Subscribe(() =>
            {
                var result = _model.OpenDataFile();

                switch (result)
                {
                    case Usecase.OpenDataUsecase.OpenResult.Completed:
                        MessageBox.Show("データを開きました。", "情報");
                        break;
                    case Usecase.OpenDataUsecase.OpenResult.Canceled:
                        MessageBox.Show("キャンセルしました。", "情報");
                        break;
                    case Usecase.OpenDataUsecase.OpenResult.Error_InvalidData:
                        MessageBox.Show(
                            "データが不正のため、処理を中断しました。",
                            "情報",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);
                        break;
                }
            })
                .AddTo(_compositeDisposable);
        }
    }
}
