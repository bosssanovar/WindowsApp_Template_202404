using DomainService;

using Feature.DataFile;

using Repository;

namespace Usecase
{
    /// <summary>
    /// 設定をファイルから読み込むユースケース
    /// </summary>
    /// <param name="_aaaRepository"><see cref="IAaaRepository"/>インスタンス</param>
    /// <param name="_bbbRepository"><see cref="IBbbRepository"/>インスタンス</param>
    /// <param name="_cccRepository"><see cref="ICccRepository"/>インスタンス</param>
    /// <param name="_dataFileAccessor"><see cref="DataFileAccessor"/>インスタンス</param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.NamingRules", "SA1313:Parameter names should begin with lower-case letter", Justification = "<保留中>")]
    public class OpenDataUsecase(IAaaRepository _aaaRepository,
                                 IBbbRepository _bbbRepository,
                                 ICccRepository _cccRepository,
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
        /// <param name="filePath">ファイルパス</param>
        /// <returns>読み込み結果</returns>
        public OpenResult Execute(string filePath)
        {
            try
            {
                var packet = new DataPacket();
                var result = _dataFileAccessor.Load(filePath, ref packet);

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
            var aaaEntity = new AaaEntity.Entity.AaaEntity();
            var bbbEntity = new BbbEntity.Entity.BbbEntity();
            var cccEntity = new CccEntity.Entity.CccEntity();

            aaaEntity.ImportPacketData(
                packet.AaaEntityPacket,
                new AaaChangedEvent(aaaEntity, bbbEntity),
                new YyyChangedEvent(aaaEntity, cccEntity));
            bbbEntity.ImportPacketData(packet.BbbEntityPacket, new BbbLehgthChecker(aaaEntity));
            cccEntity.ImportDataPacket(packet.CccEntityPacket);

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
