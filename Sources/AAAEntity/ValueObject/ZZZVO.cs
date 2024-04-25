using DomainModelCommon;

namespace AAAEntity.ValueObject
{
    /// <summary>
    /// ZZZ設定の値オブジェクトクラス
    /// </summary>
    /// <param name="Value">設定値</param>
    public record ZZZVO(int Value) : ValueObjectBase<int>(Value), IInputLimit<int>
    {
        /// <summary>
        /// 最小値
        /// </summary>
        private const int MinValue = 1;

        /// <summary>
        /// 最大値
        /// </summary>
        private const int MaxValue = 20;

        /// <inheritdoc/>
        public static int CurrectValue(int value)
        {
            if (!IsValid(value))
            {
                if (value is < MinValue)
                {
                    return MinValue;
                }
                else if (value is > MaxValue)
                {
                    return MaxValue;
                }
            }

            return value;
        }

        /// <inheritdoc/>
        public static bool IsValid(int value)
        {
            if (value is < MinValue or > MaxValue)
            {
                return false;
            }

            return true;
        }

        /// <inheritdoc/>
        protected override void Validate()
        {
            if (!IsValid(Value))
            {
                throw new ArgumentException("Invalid Value", nameof(Value));
            }
        }
    }
}
