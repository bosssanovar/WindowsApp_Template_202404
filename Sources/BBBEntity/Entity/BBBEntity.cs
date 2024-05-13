using BbbEntity.DataPacket;
using BbbEntity.DomainSreviceInterface;
using BbbEntity.ValueObject;

using DomainModelCommon;

namespace BbbEntity.Entity
{
    /// <summary>
    /// BBB Entityクラス
    /// </summary>
    public class BbbEntity : EntityBase<BbbEntity>
    {
        #region Constants -------------------------------------------------------------------------------------

        /// <summary>
        /// BBB設定の初期値
        /// </summary>
        public const string BbbInitValue = "InitValue";

        /// <summary>
        /// BBB2設定の初期値
        /// </summary>
        public const string Bbb2InitValue = "InitValue";

        #endregion --------------------------------------------------------------------------------------------

        #region Fields ----------------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Properties ------------------------------------------------------------------------------------

        /// <summary>
        /// BBB設定値
        /// </summary>
        public BbbVO Bbb { get; private set; }

        /// <summary>
        /// BBB2設定値
        /// </summary>
        public Bbb2VO Bbb2 { get; private set; }

        #endregion --------------------------------------------------------------------------------------------

        #region Events ----------------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Constructor -----------------------------------------------------------------------------------

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public BbbEntity()
        {
            Bbb = new(BbbInitValue);
            Bbb2 = new(Bbb2InitValue);
        }

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - public ------------------------------------------------------------------------------

        /// <summary>
        /// BBBを設定します。
        /// </summary>
        /// <param name="bbb">BBB設定値</param>
        /// <param name="checker">BBB設定値有効チェッカ</param>
        /// <exception cref="ArgumentOutOfRangeException">有効文字列長範囲外</exception>
        public void SetBbb(BbbVO bbb, IBbbLehgthChecker checker)
        {
            if (!checker.IsValid(bbb.Value))
            {
                throw new ArgumentOutOfRangeException(nameof(bbb), "範囲外");
            }

            Bbb = bbb;
        }

        /// <summary>
        /// BBB2を設定します。
        /// </summary>
        /// <param name="bbb2">BBB2設定値</param>
        /// <param name="checker">BBB2設定値有効チェッカ</param>
        /// <exception cref="ArgumentOutOfRangeException">有効文字列長範囲外</exception>
        public void SetBbb2(Bbb2VO bbb2, IBbbLehgthChecker checker)
        {
            if (!checker.IsValid(bbb2.Value))
            {
                throw new ArgumentOutOfRangeException(nameof(bbb2), "範囲外");
            }

            Bbb2 = bbb2;
        }

        /// <summary>
        /// 初期化します。
        /// </summary>
        public void Initialize()
        {
            Bbb = new(BbbInitValue);
            Bbb2 = new(Bbb2InitValue);
        }

        /// <summary>
        /// 設定データ群を吐き出します。
        /// </summary>
        /// <returns>設定データ群</returns>
        public BbbEntityPacket ExportPacketData()
        {
            return new()
            {
                Bbb = Bbb.Value,
                Bbb2 = Bbb2.Value,
            };
        }

        /// <summary>
        /// 設定データ群を取り込みます。
        /// </summary>
        /// <param name="packet">設定データ群</param>
        /// <param name="checker">BBB文字長チェッカー</param>
        public void ImportPacketData(BbbEntityPacket packet, IBbbLehgthChecker checker)
        {
            SetBbb(new(packet.Bbb), checker);
            SetBbb2(new(packet.Bbb2), checker);
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
