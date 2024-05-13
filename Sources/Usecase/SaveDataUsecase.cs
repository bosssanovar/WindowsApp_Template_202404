using DomainService;

using Feature.DataFile;

using Repository;

namespace Usecase
{
    /// <summary>
    /// 設定をファイルに保存するユースケース
    /// </summary>
    /// <param name="_aaaRepository"><see cref="IAaaRepository"/>インスタンス</param>
    /// <param name="_bbbRepository"><see cref="IBbbRepository"/>インスタンス</param>
    /// <param name="_cccReporitory"><see cref="ICccRepository"/>インスタンス</param>
    /// <param name="_dataFileAccessor"><see cref="DataFileAccessor"/>インスタンス</param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.NamingRules", "SA1313:Parameter names should begin with lower-case letter", Justification = "<保留中>")]
    public class SaveDataUsecase(IAaaRepository _aaaRepository,
                                 IBbbRepository _bbbRepository,
                                 ICccRepository _cccReporitory,
                                 DataFileAccessor _dataFileAccessor)
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
        /// 保存します。
        /// </summary>
        /// <returns>保存が正常終了したらtrue</returns>
        public bool Execute()
        {
            DataPacket packet = GetDataPacket();

            return _dataFileAccessor.Save(packet);
        }

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - internal ----------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - protected ---------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - private -----------------------------------------------------------------------------

        private DataPacket GetDataPacket()
        {
            var aaaEntity = _aaaRepository.Pull();
            var aaaEntityPacket = aaaEntity.ExportPacketData();

            var bbbEntity = _bbbRepository.Pull();
            var bbbEntityPacket = bbbEntity.ExportPacketData();

            var cccEntity = _cccReporitory.Pull();
            var cccEntityPacket = cccEntity.ExportDataPacket();

            var packet = new DataPacket()
            {
                AaaEntityPacket = aaaEntityPacket,
                BbbEntityPacket = bbbEntityPacket,
                CccEntityPacket = cccEntityPacket,
            };

            return packet;
        }

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - override ----------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Inner Class/Enum/etc. -------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------
    }
}
