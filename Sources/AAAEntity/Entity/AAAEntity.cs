using AAAEntity.DataPacket;
using AAAEntity.DomainSreviceInterface;
using AAAEntity.ValueObject;

using DomainModelCommon;

namespace AAAEntity.Entity
{
    /// <summary>
    /// AAA Entityクラス
    /// </summary>
    public class AAAEntity : EntityBase<AAAEntity>
    {
        #region Constants -------------------------------------------------------------------------------------

        /// <summary>
        /// WWW設定の初期値
        /// </summary>
        public const bool WwwInitValue = false;

        /// <summary>
        /// XXX設定の初期値
        /// </summary>
        public const XXXType XxxInitValue = XXXType.Xxx2;

        /// <summary>
        /// YYY設定の初期値
        /// </summary>
        public const int YyyyInitValue = 100;

        /// <summary>
        /// ZZZ設定の初期値
        /// </summary>
        public const int ZzzInitValue = 20;

        /// <summary>
        /// AAA設定の初期値
        /// </summary>
        public const int AaaInitValue = 10;

        #endregion --------------------------------------------------------------------------------------------

        #region Fields ----------------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Properties ------------------------------------------------------------------------------------

        /// <summary>
        /// WWW設定
        /// </summary>
        public WWWVO WWW { get; set; }
        // TODO : パスカル形式

        /// <summary>
        /// XXX設定
        /// </summary>
        public XXXVO XXX { get; set; }

        /// <summary>
        /// YYY設定
        /// </summary>
        public YYYVO YYY { get; private set; }

        /// <summary>
        /// ZZZ設定
        /// </summary>
        public ZZZVO ZZZ { get; private set; }

        /// <summary>
        /// AAA設定
        /// </summary>
        public AAAVO AAA { get; private set; }

        #endregion --------------------------------------------------------------------------------------------

        #region Events ----------------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Constructor -----------------------------------------------------------------------------------

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public AAAEntity()
        {
            WWW = new(WwwInitValue);
            XXX = new(XxxInitValue);
            YYY = new(YyyyInitValue);
            ZZZ = new(ZzzInitValue);
            AAA = new(AaaInitValue);
        }

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - public ------------------------------------------------------------------------------

        /// <summary>
        /// ZZZ設定値を設定します。
        /// </summary>
        /// <param name="zzz">ZZZ設定値</param>
        /// <param name="changedEvent">AAA変更イベント</param>
        public void SetZZZ(ZZZVO zzz, IAAAChangedEvent changedEvent)
        {
            ZZZ = zzz;

            if (IsHaveToCorrectAAA(zzz.Value))
            {
                SetAAA(new(zzz.Value), changedEvent);
            }
        }

        /// <summary>
        /// AAA設定値を補正すべきかを判定します。
        /// </summary>
        /// <param name="zzz">ZZZ設定値</param>
        /// <returns>補正すべき場合はtrue</returns>
        public bool IsHaveToCorrectAAA(int zzz)
        {
            return zzz < AAA.Value;
        }

        /// <summary>
        /// AAA設定を設定します。
        /// </summary>
        /// <param name="aaa">AAA設定値</param>
        /// <param name="changedEvent">AAA変更イベント</param>
        /// <exception cref="ArgumentOutOfRangeException">AAAが不正値</exception>
        public void SetAAA(AAAVO aaa, IAAAChangedEvent changedEvent)
        {
            if (IsValidAAA(aaa.Value))
            {
                throw new ArgumentOutOfRangeException(nameof(aaa), "範囲外");
            }
            else
            {
                AAA = aaa;
            }

            changedEvent.Execute();
        }

        /// <summary>
        /// AAAが有効値かを判定します。
        /// </summary>
        /// <param name="aaa">AAA設定値</param>
        /// <returns>有効な場合true</returns>
        public bool IsValidAAA(int aaa)
        {
            return ZZZ.Value < aaa;
        }

        /// <summary>
        /// YYY設定を設定します。
        /// </summary>
        /// <param name="yyy">YYY設定値</param>
        /// <param name="changedEvent">YYY変更イベント</param>
        public void SetYYY(YYYVO yyy, IYYYChangedEvent changedEvent)
        {
            YYY = yyy;

            changedEvent.Execute();
        }

        /// <summary>
        /// 初期化します。
        /// </summary>
        public void Initialize()
        {
            WWW = new(WwwInitValue);
            XXX = new(XxxInitValue);
            YYY = new(YyyyInitValue);
            ZZZ = new(ZzzInitValue);
            AAA = new(AaaInitValue);
        }

        /// <summary>
        /// 設定データ群を吐き出します。
        /// </summary>
        /// <returns>設定データ群</returns>
        public AAAEntityPacket ExportPacketData()
        {
            return new()
            {
                AAA = AAA.Value,
                WWW = WWW.Value,
                XXX = XXX.Value,
                YYY = YYY.Value,
                ZZZ = ZZZ.Value,
            };
        }

        /// <summary>
        /// 設定データ群を取り込みます。
        /// </summary>
        /// <param name="packet">取り込む設定データ群</param>
        /// <param name="aaaChangedEvent">AAA変更時イベント</param>
        /// <param name="yyyChangedEvent">YYY変更時イベント</param>
        public void ImportPacketData(
            AAAEntityPacket packet,
            IAAAChangedEvent aaaChangedEvent,
            IYYYChangedEvent yyyChangedEvent)
        {
            WWW = new(packet.WWW);
            XXX = new(packet.XXX);
            SetYYY(new(packet.YYY), yyyChangedEvent);
            SetZZZ(new(packet.ZZZ), aaaChangedEvent);
            SetAAA(new(packet.AAA), aaaChangedEvent);
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
