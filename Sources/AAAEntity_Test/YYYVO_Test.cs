using AaaEntity.ValueObject;

namespace AaaEntity_Test
{
    public class YyyVO_Test
    {
        [Theory]
        [InlineData(int.MaxValue, YyyVO.MaxValue)]
        [InlineData(YyyVO.MaxValue + YyyVO.Step + 1, YyyVO.MaxValue)]
        [InlineData(YyyVO.MaxValue + YyyVO.Step, YyyVO.MaxValue)]
        [InlineData(YyyVO.MaxValue + YyyVO.Step - 1, YyyVO.MaxValue)]
        [InlineData(YyyVO.MaxValue + 1, YyyVO.MaxValue)]
        [InlineData(YyyVO.MaxValue, YyyVO.MaxValue)]
        [InlineData(YyyVO.MaxValue - 1, YyyVO.MaxValue - YyyVO.Step)]
        [InlineData(YyyVO.MaxValue - YyyVO.Step + 1, YyyVO.MaxValue - YyyVO.Step)]
        [InlineData(YyyVO.MaxValue - YyyVO.Step, YyyVO.MaxValue - YyyVO.Step)]
        [InlineData(YyyVO.MaxValue - YyyVO.Step - 1, YyyVO.MaxValue - (YyyVO.Step * 2))]
        [InlineData(YyyVO.MinValue + YyyVO.Step + 1, YyyVO.MinValue + YyyVO.Step)]
        [InlineData(YyyVO.MinValue + YyyVO.Step, YyyVO.MinValue + YyyVO.Step)]
        [InlineData(YyyVO.MinValue + YyyVO.Step - 1, YyyVO.MinValue)]
        [InlineData(YyyVO.MinValue + 1, YyyVO.MinValue)]
        [InlineData(YyyVO.MinValue, YyyVO.MinValue)]
        [InlineData(YyyVO.MinValue - 1, YyyVO.MinValue)]
        [InlineData(YyyVO.MinValue - YyyVO.Step + 1, YyyVO.MinValue)]
        [InlineData(YyyVO.MinValue - YyyVO.Step, YyyVO.MinValue)]
        [InlineData(YyyVO.MinValue - YyyVO.Step - 1, YyyVO.MinValue)]
        [InlineData(int.MinValue, YyyVO.MinValue)]
        public void 補正(int input, int expect)
        {
            Assert.Equal(expect, YyyVO.CurrectValue(input));
        }
    }
}
