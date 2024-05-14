using AaaEntity.DataPacket;
using AaaEntity.DomainSreviceInterface;
using AaaEntity.ValueObject;

using DomainModelCommon;

namespace AaaEntity.Entity
{
    /// <summary>
    /// AAA Entityクラス
    /// </summary>
    public class AaaEntity : EntityBase<AaaEntity>
    {
        #region Constants -------------------------------------------------------------------------------------

        /// <summary>
        /// WWW設定の初期値
        /// </summary>
        public const bool WwwInitValue = false;

        /// <summary>
        /// XXX設定の初期値
        /// </summary>
        public const XxxType XxxInitValue = XxxType.Xxx2;

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
        public WwwVO Www { get; set; }

        /// <summary>
        /// XXX設定
        /// </summary>
        public XxxVO Xxx { get; set; }

        /// <summary>
        /// YYY設定
        /// </summary>
        public YyyVO Yyy { get; private set; }

        /// <summary>
        /// ZZZ設定
        /// </summary>
        public ZzzVO Zzz { get; private set; }

        /// <summary>
        /// AAA設定
        /// </summary>
        public AaaVO Aaa { get; private set; }

        #endregion --------------------------------------------------------------------------------------------

        #region Events ----------------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Constructor -----------------------------------------------------------------------------------

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public AaaEntity()
        {
            Www = new(WwwInitValue);
            Xxx = new(XxxInitValue);
            Yyy = new(YyyyInitValue);
            Zzz = new(ZzzInitValue);
            Aaa = new(AaaInitValue);
        }

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - public ------------------------------------------------------------------------------

        /// <summary>
        /// ZZZ設定値を設定します。
        /// </summary>
        /// <param name="zzz">ZZZ設定値</param>
        /// <param name="changedEvent">AAA変更イベント</param>
        public void SetZzz(ZzzVO zzz, IAaaChangedEvent changedEvent)
        {
            Zzz = zzz;

            if (IsHaveToCorrectAaa(zzz.Value))
            {
                SetAaa(new(zzz.Value), changedEvent);
            }
        }

        /// <summary>
        /// AAA設定値を補正すべきかを判定します。
        /// </summary>
        /// <param name="zzz">ZZZ設定値</param>
        /// <returns>補正すべき場合はtrue</returns>
        public bool IsHaveToCorrectAaa(int zzz)
        {
            return zzz < Aaa.Value;
        }

        /// <summary>
        /// AAA設定を設定します。
        /// </summary>
        /// <param name="aaa">AAA設定値</param>
        /// <param name="changedEvent">AAA変更イベント</param>
        /// <exception cref="ArgumentOutOfRangeException">AAAが不正値</exception>
        public void SetAaa(AaaVO aaa, IAaaChangedEvent changedEvent)
        {
            if (IsValidAaa(aaa.Value))
            {
                throw new ArgumentOutOfRangeException(nameof(aaa), "範囲外");
            }
            else
            {
                Aaa = aaa;
            }

            changedEvent.Execute();
        }

        /// <summary>
        /// AAAが有効値かを判定します。
        /// </summary>
        /// <param name="aaa">AAA設定値</param>
        /// <returns>有効な場合true</returns>
        public bool IsValidAaa(int aaa)
        {
            return Zzz.Value < aaa;
        }

        /// <summary>
        /// YYY設定を設定します。
        /// </summary>
        /// <param name="yyy">YYY設定値</param>
        /// <param name="changedEvent">YYY変更イベント</param>
        public void SetYyy(YyyVO yyy, IYyyChangedEvent changedEvent)
        {
            Yyy = yyy;

            changedEvent.Execute();
        }

        /// <summary>
        /// 初期化します。
        /// </summary>
        public void Initialize()
        {
            Www = new(WwwInitValue);
            Xxx = new(XxxInitValue);
            Yyy = new(YyyyInitValue);
            Zzz = new(ZzzInitValue);
            Aaa = new(AaaInitValue);
        }

        /// <summary>
        /// 設定データ群を吐き出します。
        /// </summary>
        /// <returns>設定データ群</returns>
        public AaaEntityPacket ExportPacketData()
        {
            return new()
            {
                Aaa = Aaa.Value,
                Www = Www.Value,
                Xxx = Xxx.Value,
                Yyy = Yyy.Value,
                Zzz = Zzz.Value,
            };
        }

        /// <summary>
        /// 設定データ群を取り込みます。
        /// </summary>
        /// <param name="packet">取り込む設定データ群</param>
        /// <param name="aaaChangedEvent">AAA変更時イベント</param>
        /// <param name="yyyChangedEvent">YYY変更時イベント</param>
        public void ImportPacketData(
            AaaEntityPacket packet,
            IAaaChangedEvent aaaChangedEvent,
            IYyyChangedEvent yyyChangedEvent)
        {
            Www = new(packet.Www);
            Xxx = new(packet.Xxx);
            SetYyy(new(packet.Yyy), yyyChangedEvent);
            SetZzz(new(packet.Zzz), aaaChangedEvent);
            SetAaa(new(packet.Aaa), aaaChangedEvent);
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
