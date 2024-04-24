using DomainService;

namespace AAAEntity_Test
{
    public class AAAEntity_Test
    {
        [Theory]
        [InlineData(20, "1234567890")]
        [InlineData(10, "1234567890")]
        [InlineData(9, "123456789")]
        [InlineData(8, "12345678")]
        [InlineData(1, "1")]
        public void ZZZ�ݒ�ύX����AAA�ݒ�Ƃ��̊֘A�ݒ�̕␳(int newZZZ, string expectedCorrectedBBB)
        {
            var aaaEntity = new AAAEntity.Entity.AAAEntity();
            var bbbEntity = new BBBEntity.Entity.BBBEntity();

            // ����
            aaaEntity.SetZZZ(new(20), new AAAChangedEvent(aaaEntity, bbbEntity));
            aaaEntity.SetAAA(new(10), new AAAChangedEvent(aaaEntity, bbbEntity));
            bbbEntity.SetBBB(new("1234567890"), new BBBLehgthChecker(aaaEntity));

            // ���s
            aaaEntity.SetZZZ(new(newZZZ), new AAAChangedEvent(aaaEntity, bbbEntity));

            // �e�X�g
            Assert.Equal(bbbEntity.BBB.Value, expectedCorrectedBBB);

        }
    }
}