using DomainService;

using Feature.DataFile;

using Repository;

namespace Usecase
{
    /// <summary>
    /// 設定をファイルに保存するユースケース
    /// </summary>
    /// <param name="_aaaRepository"><see cref="IAAARepository"/>インスタンス</param>
    /// <param name="_bbbRepository"><see cref="IBBBRepository"/>インスタンス</param>
    /// <param name="_dataFileAccessor"><see cref="DataFileAccessor"/>インスタンス</param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.NamingRules", "SA1313:Parameter names should begin with lower-case letter", Justification = "<保留中>")]
    public class SaveDataUsecase(IAAARepository _aaaRepository,
                                 IBBBRepository _bbbRepository,
                                 DataFileAccessor _dataFileAccessor)
    {
        // TODO K.I : 要対応
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

            var packet = new DataPacket()
            {
                AAAEntityPacket = aaaEntityPacket,
                BBBEntityPacket = bbbEntityPacket,
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
