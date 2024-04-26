using Repository;

namespace Usecase
{
    /// <summary>
    /// 設定値を取得するユースケース
    /// </summary>
    /// <param name="_aaaRepository"><see cref="IAAARepository"/>インスタンス</param>
    /// <param name="_bbbRepository"><see cref="IBBBRepository"/>インスタンス</param>
    /// <param name="_cccRepository"><see cref="ICCCRepository"/>インスタンス</param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.NamingRules", "SA1313:Parameter names should begin with lower-case letter", Justification = "<保留中>")]
    public class DisplaySettingsUsecase(
        IAAARepository _aaaRepository,
        IBBBRepository _bbbRepository,
        ICCCRepository _cccRepository)
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

        /// <summary>
        /// AAA Entityを取得します。
        /// </summary>
        /// <returns>AAA Entity</returns>
        public AAAEntity.Entity.AAAEntity GetAAAEntity()
        {
            return _aaaRepository.Pull();
        }

        /// <summary>
        /// BBB Entityを取得します。
        /// </summary>
        /// <returns>BBB Entity</returns>
        public BBBEntity.Entity.BBBEntity GetBBBEntity()
        {
            return _bbbRepository.Pull();
        }

        /// <summary>
        /// CCC Entityを取得します。
        /// </summary>
        /// <returns>CCC Entity</returns>
        public CCCEntity.Entity.CCCEntity GetCCCEntity()
        {
            return _cccRepository.Pull();
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
