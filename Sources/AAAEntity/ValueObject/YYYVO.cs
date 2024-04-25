using DomainModelCommon;

namespace AAAEntity.ValueObject
{
    /// <summary>
    /// YYY設定の値オブジェクトクラス
    /// </summary>
    /// <param name="Value">設定値</param>
    public record YYYVO(int Value) : ValueObjectBase<int>(Value), IInputLimit<int>
    {
        /// <summary>
        /// 最小値
        /// </summary>
        public const int MinValue = 5;

        /// <summary>
        /// 最大値
        /// </summary>
        public const int MaxValue = 100;

        /// <summary>
        /// ステップ
        /// </summary>
        public const int Step = 5;

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

                if (value % Step != 0)
                {
                    // Step単位に切り捨てる
                    return Step * (value / Step);
                }
            }

            return value;
        }

        /// <inheritdoc/>
        public static bool IsValid(int value)
        {
            if (value % Step != 0)
            {
                return false;
            }

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
