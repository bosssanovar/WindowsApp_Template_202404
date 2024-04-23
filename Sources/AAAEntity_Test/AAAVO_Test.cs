using AAAEntity.ValueObject;

namespace AAAEntity_Test
{
    public class AAAVO_Test
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
                var _ = new AAAVO(value);
            });
        }

        [Theory]
        [InlineData(int.MaxValue, AAAVO.MaxValue)]
        [InlineData(AAAVO.MaxValue + 1, AAAVO.MaxValue)]
        [InlineData(AAAVO.MaxValue, AAAVO.MaxValue)]
        [InlineData(AAAVO.MaxValue - 1, AAAVO.MaxValue - 1)]
        [InlineData(AAAVO.MinValue + 1, AAAVO.MinValue + 1)]
        [InlineData(AAAVO.MinValue, AAAVO.MinValue)]
        [InlineData(AAAVO.MinValue - 1, AAAVO.MinValue)]
        [InlineData(int.MinValue, AAAVO.MinValue)]
        public void 補正(int input, int expect)
        {
            Assert.Equal(expect, AAAVO.CurrectValue(input));
        }
    }
}
