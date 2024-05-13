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
        public void ZZZ設定変更時のAAA設定とその関連設定の補正(int newZzz, string expectedCorrectedBbb)
        {
            var aaaEntity = new AaaEntity.Entity.AaaEntity();
            var bbbEntity = new BbbEntity.Entity.BbbEntity();

            // 準備
            aaaEntity.SetZzz(new(20), new AaaChangedEvent(aaaEntity, bbbEntity));
            aaaEntity.SetAaa(new(10), new AaaChangedEvent(aaaEntity, bbbEntity));
            bbbEntity.SetBbb(new("1234567890"), new BbbLehgthChecker(aaaEntity));

            // 実行
            aaaEntity.SetZzz(new(newZzz), new AaaChangedEvent(aaaEntity, bbbEntity));

            // テスト
            Assert.Equal(bbbEntity.Bbb.Value, expectedCorrectedBbb);

        }
    }
}