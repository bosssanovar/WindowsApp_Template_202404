using DomainService;

namespace AaaEntity_Test
{
    public class AaaEntity_Test
    {
        [Theory]
        [InlineData(20, "1234567890")]
        [InlineData(10, "1234567890")]
        [InlineData(9, "123456789")]
        [InlineData(8, "12345678")]
        [InlineData(1, "1")]
        public void ZZZ�ݒ�ύX����AAA�ݒ�Ƃ��̊֘A�ݒ�̕␳(int newZzz, string expectedCorrectedBbb)
        {
            var aaaEntity = new AaaEntity.Entity.AaaEntity();
            var bbbEntity = new BbbEntity.Entity.BbbEntity();

            // ����
            aaaEntity.SetZzz(new(20), new AaaChangedEvent(aaaEntity, bbbEntity));
            aaaEntity.SetAaa(new(10), new AaaChangedEvent(aaaEntity, bbbEntity));
            bbbEntity.SetBbb(new("1234567890"), new BbbLehgthChecker(aaaEntity));

            // ���s
            aaaEntity.SetZzz(new(newZzz), new AaaChangedEvent(aaaEntity, bbbEntity));

            // �e�X�g
            Assert.Equal(bbbEntity.Bbb.Value, expectedCorrectedBbb);

        }
    }
}