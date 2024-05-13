﻿using AaaEntity.DomainSreviceInterface;

namespace DomainService
{
    /// <summary>
    /// YYY設定に関連する設定値を補正するクラス
    /// </summary>
    /// <param name="_aaaEntity"><see cref="AaaEntity.Entity.AaaEntity"/>インスタンス</param>
    /// <param name="_ccceEntity"><see cref="CccEntity.Entity.CccEntity"/>インスタンス</param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.NamingRules", "SA1313:Parameter names should begin with lower-case letter", Justification = "<保留中>")]
    public class YyyChangedEvent(AaaEntity.Entity.AaaEntity _aaaEntity, CccEntity.Entity.CccEntity _ccceEntity) : IYyyChangedEvent
    {
        #region Constants -------------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Fields ----------------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Properties ------------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Events ----------------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Constructor -----------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - public ------------------------------------------------------------------------------

        /// <inheritdoc/>
        public void Execute()
        {
            _ccceEntity.ChangeCount(_aaaEntity.Yyy.Value);
        }

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
