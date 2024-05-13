using AaaEntity.ValueObject;

namespace AaaEntity_Test
{
    public class AaaVO_Test
    {
        [Theory]
        [InlineData(int.MaxValue)]
        [InlineData(21)]
        [InlineData(-1)]
        [InlineData(int.MinValue)]
        public void コンストラクタ＿例外(int value)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var _ = new AaaVO(value);
            });
        }

        [Theory]
        [InlineData(int.MaxValue, AaaVO.MaxValue)]
        [InlineData(AaaVO.MaxValue + 1, AaaVO.MaxValue)]
        [InlineData(AaaVO.MaxValue, AaaVO.MaxValue)]
        [InlineData(AaaVO.MaxValue - 1, AaaVO.MaxValue - 1)]
        [InlineData(AaaVO.MinValue + 1, AaaVO.MinValue + 1)]
        [InlineData(AaaVO.MinValue, AaaVO.MinValue)]
        [InlineData(AaaVO.MinValue - 1, AaaVO.MinValue)]
        [InlineData(int.MinValue, AaaVO.MinValue)]
        public void 補正(int input, int expect)
        {
            Assert.Equal(expect, AaaVO.CurrectValue(input));
        }
    }
}
