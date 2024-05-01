using DomainService;

using Feature.DataFile;

using Repository;

using System.Net.Sockets;

namespace Usecase
{
    /// <summary>
    /// 設定をファイルから読み込むユースケース
    /// </summary>
    /// <param name="_aaaRepository"><see cref="IAAARepository"/>インスタンス</param>
    /// <param name="_bbbRepository"><see cref="IBBBRepository"/>インスタンス</param>
    /// <param name="_cccRepository"><see cref="ICCCRepository"/>インスタンス</param>
    /// <param name="_dataFileAccessor"><see cref="DataFileAccessor"/>インスタンス</param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.NamingRules", "SA1313:Parameter names should begin with lower-case letter", Justification = "<保留中>")]
    public class OpenDataUsecase(IAAARepository _aaaRepository,
                                 IBBBRepository _bbbRepository,
                                 ICCCRepository _cccRepository,
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
        /// 読み込みます。
        /// </summary>
        /// <returns>読み込み結果</returns>
        public OpenResult Execute()
        {
            try
            {
                var packet = new DataPacket();
                var result = _dataFileAccessor.Load(ref packet);

                if (!result)
                {
                    return OpenResult.Canceled;
                }

                ImportData(packet);

                return OpenResult.Completed;
            }
            catch
            {
                return OpenResult.Error_InvalidData;
            }
        }

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - internal ----------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - protected ---------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - private -----------------------------------------------------------------------------

        private void ImportData(DataPacket packet)
        {
            var aaaEntity = _aaaRepository.Pull();
            var bbbEntity = _bbbRepository.Pull();
            var cccEntity = _cccRepository.Pull();

            aaaEntity.ImportPacketData(packet.AAAEntityPacket, new AAAChangedEvent(aaaEntity, bbbEntity));
            bbbEntity.ImportPacketData(packet.BBBEntityPacket, new BBBLehgthChecker(aaaEntity));
            cccEntity.ImportDataPacket(packet.CCCEntityPacket);

            // データのImport中の例外でそのまま処理を抜けて副作用がないように、
            // Commitは最後にまとめて行う
            _aaaRepository.Commit(aaaEntity);
            _bbbRepository.Commit(bbbEntity);
            _cccRepository.Commit(cccEntity);
        }

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - override ----------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Inner Class/Enum/etc. -------------------------------------------------------------------------

        /// <summary>
        /// 読み込み結果の列挙
        /// </summary>
        public enum OpenResult
        {
            /// <summary>
            /// 正常完了
            /// </summary>
            Completed,

            /// <summary>
            /// キャンセル中断
            /// </summary>
            Canceled,

            /// <summary>
            /// データ不正エラー
            /// </summary>
            Error_InvalidData,
        }

        #endregion --------------------------------------------------------------------------------------------
    }
}
