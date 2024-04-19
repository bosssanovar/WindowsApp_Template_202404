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
        [InlineData(0, "")]
        public void ZZZ設定変更時のAAA設定とその関連設定の補正(int newZZZ, string expectedCorrectedBBB)
        {
            var aaaEntity = new AAAEntity.AAAEntity();
            var bbbEntity = new BBBEntity.BBBEntity();

            // 準備
            aaaEntity.SetZZZ(new(20), new AAAChangedEvent(aaaEntity, bbbEntity));
            aaaEntity.SetAAA(new(10), new AAAChangedEvent(aaaEntity, bbbEntity));
            bbbEntity.SetBBB(new("1234567890"), new BBBLehgthChecker(aaaEntity));

            // 実行
            aaaEntity.SetZZZ(new(newZZZ), new AAAChangedEvent(aaaEntity, bbbEntity));

            // テスト
            Assert.Equal(bbbEntity.BBB.Value, expectedCorrectedBBB);

        }
    }
}