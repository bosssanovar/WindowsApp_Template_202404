using AAAEntity.ValueObject;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        [InlineData(int.MaxValue, 20)]
        [InlineData(21, 20)]
        [InlineData(20, 20)]
        [InlineData(19, 19)]
        [InlineData(1, 1)]
        [InlineData(0, 0)]
        [InlineData(-1, 0)]
        [InlineData(int.MinValue, 0)]
        public void 補正(int input, int expect)
        {
            Assert.Equal(AAAVO.CurrectValue(input), expect);
        }
    }
}
