using Repository;

namespace Usecase
{
    /// <summary>
    /// 設定値を確定するユースケース
    /// </summary>
    /// <param name="_aaaRepository"><see cref="IAaaRepository"/>インスタンス</param>
    /// <param name="_bbbRepository"><see cref="IBbbRepository"/>インスタンス</param>
    /// <param name="_cccRepository"><see cref="ICccRepository"/>インスタンス</param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.NamingRules", "SA1313:Parameter names should begin with lower-case letter", Justification = "<保留中>")]
    public class CommitSettingsUsecase(
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
        /// AAA Entityを確定します。
        /// </summary>
        /// <param name="entity">AAA Entity</param>
        public void CommitAaaEntity(AaaEntity.Entity.AaaEntity entity)
        {
            _aaaRepository.Commit(entity);
        }

        /// <summary>
        /// BBB Entityを確定しますl
        /// </summary>
        /// <param name="entity">BBB Entity</param>
        public void CommitBbbEntity(BbbEntity.Entity.BbbEntity entity)
        {
            _bbbRepository.Commit(entity);
        }

        /// <summary>
        /// CCC Entityを確定しますl
        /// </summary>
        /// <param name="entity">CCC Entity</param>
        public void CommitCccEntity(CccEntity.Entity.CccEntity entity)
        {
            _cccRepository.Commit(entity);
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
