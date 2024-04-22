using BBBEntity.DataPacket;
using BBBEntity.DomainSreviceInterface;
using BBBEntity.ValueObject;

namespace BBBEntity.Entity
{
    public class BBBEntity
    {
        public const string BBB_InitValue = "init value";

        public BBBVO BBB { get; private set; }

        public BBBEntity()
        {
            BBB = new(BBB_InitValue);
        }

        public void SetBBB(BBBVO bbb, IBBBLehgthChecker checker)
        {
            if (!checker.IsValid(bbb.Value))
            {
                throw new ArgumentOutOfRangeException(nameof(bbb), "範囲外");
            }

            BBB = bbb;
        }

        public BBBEntity Clone()
        {
            return (BBBEntity)MemberwiseClone();
        }

        public void Initialize()
        {
            BBB = new(BBB_InitValue);
        }

        public BBBEntityPacket ExportPacketData()
        {
            return new()
            {
                BBB = BBB.Value
            };
        }
    }
}
