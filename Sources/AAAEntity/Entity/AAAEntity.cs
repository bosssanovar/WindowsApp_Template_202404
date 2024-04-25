using AAAEntity.DataPacket;
using AAAEntity.DomainSreviceInterface;
using AAAEntity.ValueObject;

namespace AAAEntity.Entity
{
    /// <summary>
    /// AAA Entityクラス
    /// </summary>
    public class AAAEntity
    {
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

        /// <summary>
        /// YYY設定
        /// </summary>
        public YYYVO YYY { get; set; }

        /// <summary>
        /// ZZZ設定
        /// </summary>
        public ZZZVO ZZZ { get; private set; }

        /// <summary>
        /// AAA設定
        /// </summary>
        public AAAVO AAA { get; private set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public AAAEntity()
        {
            YYY = new(YyyyInitValue);
            ZZZ = new(ZzzInitValue);
            AAA = new(AaaInitValue);
        }

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
        /// AAA Entityを複製します。
        /// </summary>
        /// <returns>複製されたインスタンス</returns>
        public AAAEntity Clone()
        {
            return (AAAEntity)MemberwiseClone();
        }

        /// <summary>
        /// 初期化します。
        /// </summary>
        public void Initialize()
        {
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
                YYY = YYY.Value,
                ZZZ = ZZZ.Value,
            };
        }

        /// <summary>
        /// 設定データ群を取り込みます。
        /// </summary>
        /// <param name="packet">取り込む設定データ群</param>
        public void ImportPacketData(AAAEntityPacket packet)
        {
            YYY = new(packet.YYY);
            ZZZ = new(packet.ZZZ);
            AAA = new(packet.AAA);
        }
    }
}
