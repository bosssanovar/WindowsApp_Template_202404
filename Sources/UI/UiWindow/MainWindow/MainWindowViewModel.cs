using DomainService;

using Reactive.Bindings;
using Reactive.Bindings.Extensions;

using System.ComponentModel;
using System.Reactive.Disposables;
using System.Windows;


namespace UiParts.UiWindow.MainWindow
{
    public partial class MainWindowView : INotifyPropertyChanged
    {
#pragma warning disable CS0067 // イベント 'MainWindowView.PropertyChanged' は使用されていません
        public event PropertyChangedEventHandler? PropertyChanged;
#pragma warning restore CS0067 // イベント 'MainWindowView.PropertyChanged' は使用されていません

        private Model? _model;

        public ReactivePropertySlim<int> YYYVal { get; private set; } = new(0);

        public ReactivePropertySlim<int> ZZZVal { get; private set; } = new(0);

        public ReactivePropertySlim<int> AAAVal { get; private set; } = new(0);

        public ReactivePropertySlim<string> BBBVal { get; private set; } = new(string.Empty);

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
                    var entity = _model.AaaEntity.Value;

                    if (entity.IsHaveToCorrectAAA(x))
                    {
                        if (MessageBox.Show(
                            "ZZZ設定の変更によりAAA設定の設定値が補正され、それに関わる項目も補正される可能性があります。\n\nZZZ設定を変更しますか？",
                            "確認",
                            MessageBoxButton.YesNo,
                            MessageBoxImage.Question,
                            MessageBoxResult.No) == MessageBoxResult.Yes)
                        {
                            entity.SetZZZ(new(x), new AAAChangedEvent(_model.AaaEntity.Value, _model.BbbEntity.Value));
                        }
                    }
                    else
                    {
                        entity.SetZZZ(new(x), new AAAChangedEvent(_model.AaaEntity.Value, _model.BbbEntity.Value));
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
                        text = lengthChecker.Substring(text);
                    }

                    var entity = _model.BbbEntity.Value;
                    entity.SetBBB(new(text), lengthChecker);

                    _model.ForceNotifyBbbEntity();

                    return entity;
                },
                mode: ReactivePropertyMode.DistinctUntilChanged)
                .AddTo(_compositeDisposable);
        }
    }
}
