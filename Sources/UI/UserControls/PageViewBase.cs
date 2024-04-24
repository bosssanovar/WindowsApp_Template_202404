using System.ComponentModel;
using System.Reactive.Disposables;
using System.Windows.Controls;

namespace UiParts.UserControls
{
    public abstract class PageViewBase : UserControl, INotifyPropertyChanged
    {
#pragma warning disable CS0067 // イベント 'MainWindowView.PropertyChanged' は使用されていません
        public event PropertyChangedEventHandler? PropertyChanged;
#pragma warning restore CS0067 // イベント 'MainWindowView.PropertyChanged' は使用されていません

        private readonly PageModelBase _modelBase;

        protected readonly CompositeDisposable _compositeDisposable = [];

        public PageViewBase(PageModelBase modelBase)
        {
            _modelBase = modelBase;

            this.Loaded += PageViewBase_Loaded;
            this.Unloaded += PageViewBase_Unloaded;
        }

        public void Update()
        {
            _modelBase.UpdateEntities();
        }

        public void Commit()
        {
            _modelBase.CommitEntities();
        }

        private void PageViewBase_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            _modelBase.UpdateEntities();
        }

        private void PageViewBase_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            Commit();

            _modelBase.Dispose();
            _compositeDisposable.Dispose();
        }
    }
}
