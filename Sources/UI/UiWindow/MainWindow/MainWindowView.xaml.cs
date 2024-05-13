﻿using System.Windows;
using System.Windows.Media.Animation;

using WpfLib;

namespace UiParts.UiWindow.MainWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindowView : MainWindowBase, IBlur
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="model">モデル</param>
        public MainWindowView(MainWindowModel model)
            : base(model)
        {
            MainWindowViewModel(model);

            InitializeComponent();
        }

        /// <inheritdoc/>
        public void BlurOff()
        {
            var sb = blurBorder.FindResource("CloseAnimation") as Storyboard;
            if (sb is not null)
            {
                sb.Completed += (sender, e) =>
                {
                    IsBlur.Value = false;
                    blurBorder.Visibility = Visibility.Collapsed;
                };

                sb.Begin();
            }
            else
            {
                IsBlur.Value = false;
                blurBorder.Visibility = Visibility.Collapsed;
            }
        }

        /// <inheritdoc/>
        public void BlurOn()
        {
            blurBorder.Visibility = Visibility.Visible;
            IsBlur.Value = true;

            var sb = blurBorder.FindResource("OpenAnimation") as Storyboard;
            if (sb is not null)
            {
                sb.Begin();
            }
        }
    }
}