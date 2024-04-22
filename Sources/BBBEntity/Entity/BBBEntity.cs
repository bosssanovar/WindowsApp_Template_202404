using BBBEntity.DataPacket;
using BBBEntity.DomainSreviceInterface;
using BBBEntity.ValueObject;

namespace BBBEntity.Entity
{
    public class BBBEntity
    {
        public const string BBB_InitValue = "InitValue";
        public const string BBB2_InitValue = "InitValue";

        public BBBVO BBB { get; private set; }
        public BBB2VO BBB2 { get; private set; }

        public BBBEntity()
        {
            BBB = new(BBB_InitValue);
            BBB2 = new(BBB2_InitValue);
        }

        public void SetBBB(BBBVO bbb, IBBBLehgthChecker checker)
        {
            if (!checker.IsValid(bbb.Value))
            {
                throw new ArgumentOutOfRangeException(nameof(bbb), "範囲外");
            }

            BBB = bbb;
        }

        public void SetBBB2(BBB2VO bbb2, IBBBLehgthChecker checker)
        {
            if (!checker.IsValid(bbb2.Value))
            {
                throw new ArgumentOutOfRangeException(nameof(bbb2), "範囲外");
            }

            BBB2 = bbb2;
        }

        public BBBEntity Clone()
        {
            return (BBBEntity)MemberwiseClone();
        }

        public void Initialize()
        {
            BBB = new(BBB_InitValue);
            BBB2 = new(BBB2_InitValue);
        }

        public BBBEntityPacket ExportPacketData()
        {
            return new()
            {
                BBB = BBB.Value,
                BBB2 = BBB2.Value,
            };
        }

        public void ImportPacketData(BBBEntityPacket packet)
        {
            BBB = new(packet.BBB);
            BBB2 = new(packet.BBB2);
        }
    }
}
