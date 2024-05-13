using BbbEntity.ValueObject;

using DomainService;

using Reactive.Bindings;
using Reactive.Bindings.Extensions;

using System.Reactive.Linq;
using System.Text;
using System.Windows;

namespace UiParts.UserControls.BbbPage
{
    /// <summary>
    /// BBBページの疑似ViewModel
    /// </summary>
    public partial class BbbPageView
    {
        #region Constants -------------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Fields ----------------------------------------------------------------------------------------

        private BbbPageModel? _model;

        #endregion --------------------------------------------------------------------------------------------

        #region Properties ------------------------------------------------------------------------------------

        /// <summary>
        /// AAA設定値
        /// </summary>
        public ReadOnlyReactivePropertySlim<int>? AaaVal { get; private set; }

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

        private void BbbPageViewModel(BbbPageModel model)
        {
            _model = model;

            AaaVal = _model.AaaEntity.Select(x => x.Aaa.Value)
                .ToReadOnlyReactivePropertySlim()
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
                        MessageBox.Show(
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
                        MessageBox.Show(message.ToString(), "確認");
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
