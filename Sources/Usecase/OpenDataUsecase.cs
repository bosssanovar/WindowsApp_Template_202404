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
    /// <param name="_dataFileAccessor"><see cref="DataFileAccessor"/>インスタンス</param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.NamingRules", "SA1313:Parameter names should begin with lower-case letter", Justification = "<保留中>")]
    public class OpenDataUsecase(IAAARepository _aaaRepository,
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
            // データのDecode中の例外でそのまま処理が追われるように、
            // Commitは最後にまとめて行う
            var aaaEntity = _aaaRepository.Pull();
            aaaEntity.ImportPacketData(packet.AAAEntityPacket);

            var bbbEntity = _bbbRepository.Pull();
            bbbEntity.ImportPacketData(packet.BBBEntityPacket);

            _aaaRepository.Commit(aaaEntity);
            _bbbRepository.Commit(bbbEntity);
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
