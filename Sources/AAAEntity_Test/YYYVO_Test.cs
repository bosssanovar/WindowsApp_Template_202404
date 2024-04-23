using AAAEntity.ValueObject;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAAEntity_Test
{
    public class YYYVO_Test
    {
        [Theory]
        [InlineData(int.MaxValue, YYYVO.MaxValue)]
        [InlineData(YYYVO.MaxValue + YYYVO.Step + 1, YYYVO.MaxValue)]
        [InlineData(YYYVO.MaxValue + YYYVO.Step, YYYVO.MaxValue)]
        [InlineData(YYYVO.MaxValue + YYYVO.Step - 1, YYYVO.MaxValue)]
        [InlineData(YYYVO.MaxValue + 1, YYYVO.MaxValue)]
        [InlineData(YYYVO.MaxValue, YYYVO.MaxValue)]
        [InlineData(YYYVO.MaxValue - 1, YYYVO.MaxValue - YYYVO.Step)]
        [InlineData(YYYVO.MaxValue - YYYVO.Step + 1, YYYVO.MaxValue - YYYVO.Step)]
        [InlineData(YYYVO.MaxValue - YYYVO.Step, YYYVO.MaxValue - YYYVO.Step)]
        [InlineData(YYYVO.MaxValue - YYYVO.Step - 1, YYYVO.MaxValue - (YYYVO.Step * 2))]
        [InlineData(YYYVO.MinValue + YYYVO.Step + 1, YYYVO.MinValue + YYYVO.Step)]
        [InlineData(YYYVO.MinValue + YYYVO.Step, YYYVO.MinValue + YYYVO.Step)]
        [InlineData(YYYVO.MinValue + YYYVO.Step - 1, YYYVO.MinValue)]
        [InlineData(YYYVO.MinValue + 1, YYYVO.MinValue)]
        [InlineData(YYYVO.MinValue, YYYVO.MinValue)]
        [InlineData(YYYVO.MinValue - 1, YYYVO.MinValue)]
        [InlineData(YYYVO.MinValue - YYYVO.Step + 1, YYYVO.MinValue)]
        [InlineData(YYYVO.MinValue - YYYVO.Step, YYYVO.MinValue)]
        [InlineData(YYYVO.MinValue - YYYVO.Step - 1, YYYVO.MinValue)]
        [InlineData(int.MinValue, YYYVO.MinValue)]
        public void 補正(int input, int expect)
        {
            Assert.Equal(expect, YYYVO.CurrectValue(input));
        }
    }
}
