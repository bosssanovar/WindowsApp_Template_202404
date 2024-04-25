﻿using BBBEntity.ValueObject;

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
        private BbbPageModel? _model;

        /// <summary>
        /// AAA設定値
        /// </summary>
        public ReadOnlyReactivePropertySlim<int>? AAAVal { get; private set; }

        /// <summary>
        /// BBB設定値
        /// </summary>
        public ReactivePropertySlim<string> BBBVal { get; private set; } = new(string.Empty);

        /// <summary>
        /// BBB2設定値
        /// </summary>
        public ReactivePropertySlim<string> BBB2Val { get; private set; } = new(string.Empty);

        private void BbbPageViewModel(BbbPageModel model)
        {
            _model = model;

            AAAVal = _model.AaaEntity.Select(x => x.AAA.Value)
                .ToReadOnlyReactivePropertySlim()
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
