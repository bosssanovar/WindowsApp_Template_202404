using Repository;

namespace Usecase
{
    /// <summary>
    /// 設定値を初期化するユースケース
    /// </summary>
    /// <param name="_aaaRepository"><see cref="IAaaRepository"/>インスタンス</param>
    /// <param name="_bbbRepository"><see cref="IBbbRepository"/>インスタンス</param>
    /// <param name="_cccRepository"><see cref="ICccRepository"/>インスタンス</param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.NamingRules", "SA1313:Parameter names should begin with lower-case letter", Justification = "<保留中>")]
    public class InitializeUsecase(
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
        /// 全てのEntityを初期化します。
        /// </summary>
        public void Execute()
        {
            InitAaaEntity();
            InitBbbEntity();
            InitCccEntity();
        }

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - internal ----------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - protected ---------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - private -----------------------------------------------------------------------------

        private void InitAaaEntity()
        {
            var aaaEntity = _aaaRepository.Pull();
            aaaEntity.Initialize();
            _aaaRepository.Commit(aaaEntity);
        }

        private void InitBbbEntity()
        {
            var bbbEntity = _bbbRepository.Pull();
            bbbEntity.Initialize();
            _bbbRepository.Commit(bbbEntity);
        }

        private void InitCccEntity()
        {
            var cccEntity = _cccRepository.Pull();
            cccEntity.Initialize();
            _cccRepository.Commit(cccEntity);
        }

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - override ----------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Inner Class/Enum/etc. -------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------
    }
}
