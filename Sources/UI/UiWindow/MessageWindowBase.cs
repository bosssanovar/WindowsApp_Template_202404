﻿using Reactive.Bindings;

using System.Windows;

namespace UiParts.UiWindow
{
    /// <summary>
    /// Message Windowのベースクラス
    /// </summary>
    public abstract class MessageWindowBase : Window
    {
        #region Constants -------------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Fields ----------------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Properties ------------------------------------------------------------------------------------

        /// <summary>
        /// ウィンドウを閉じるコマンド
        /// </summary>
        public ReactiveCommand WindowCloseCommand { get; } = new();

        #endregion --------------------------------------------------------------------------------------------

        #region Events ----------------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Constructor -----------------------------------------------------------------------------------

        static MessageWindowBase()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MessageWindowBase), new FrameworkPropertyMetadata(typeof(MessageWindowBase)));
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MessageWindowBase()
        {
            WindowCloseCommand.Subscribe(
                () =>
                {
                    Window.GetWindow(this).Close();
                });
        }

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - public ------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - internal ----------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - protected ---------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - private -----------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - override ----------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Inner Class/Enum/etc. -------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------
    }
}
