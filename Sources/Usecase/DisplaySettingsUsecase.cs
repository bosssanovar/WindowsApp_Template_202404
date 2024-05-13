using Repository;

namespace Usecase
{
    /// <summary>
    /// 設定値を取得するユースケース
    /// </summary>
    /// <param name="_aaaRepository"><see cref="IAaaRepository"/>インスタンス</param>
    /// <param name="_bbbRepository"><see cref="IBbbRepository"/>インスタンス</param>
    /// <param name="_cccRepository"><see cref="ICccRepository"/>インスタンス</param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.NamingRules", "SA1313:Parameter names should begin with lower-case letter", Justification = "<保留中>")]
    public class DisplaySettingsUsecase(
        IAaaRepository _aaaRepository,
        IBbbRepository _bbbRepository,
        ICccRepository _cccRepository)
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
        public AaaEntity.Entity.AaaEntity GetAaaEntity()
        {
            return _aaaRepository.Pull();
        }

        /// <summary>
        /// BBB Entityを取得します。
        /// </summary>
        /// <returns>BBB Entity</returns>
        public BbbEntity.Entity.BbbEntity GetBbbEntity()
        {
            return _bbbRepository.Pull();
        }

        /// <summary>
        /// CCC Entityを取得します。
        /// </summary>
        /// <returns>CCC Entity</returns>
        public CccEntity.Entity.CccEntity GetCccEntity()
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
