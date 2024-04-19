namespace AAAEntity
{
    public class AAAEntity
    {
        public const int YYY_InitValue = 100;
        public const int ZZZ_InitValue = 20;
        public const int AAA_InitValue = 10;

        public YYYVO YYY { get; set; }

        public ZZZVO ZZZ { get; private set; }

        public AAAVO AAA { get; private set; }

        public AAAEntity()
        {
            YYY = new(YYY_InitValue);
            ZZZ = new(ZZZ_InitValue);
            AAA = new(AAA_InitValue);
        }

        public void SetZZZ(ZZZVO zzz, IAAAChangedEvent changedEvent)
        {
            ZZZ = zzz;

            if (IsHaveToCorrectAAA(zzz.Value))
            {
                SetAAA(new(zzz.Value), changedEvent);
            }
        }

        public bool IsHaveToCorrectAAA(int zzz)
        {
            return zzz < AAA.Value;
        }

        public void SetAAA(AAAVO aaa, IAAAChangedEvent changedEvent)
        {
            if (IsOverZZZ(aaa.Value))
            {
                throw new ArgumentOutOfRangeException(nameof(aaa), "範囲外");
            }
            else
            {
                AAA = aaa;
            }

            changedEvent.Execute();
        }

        public bool IsOverZZZ(int aaa)
        {
            return ZZZ.Value < aaa;
        }

        public AAAEntity Clone()
        {
            return (AAAEntity)MemberwiseClone();
        }
    }
}
