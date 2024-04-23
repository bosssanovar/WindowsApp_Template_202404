using DomainModelCommon;

namespace AAAEntity.ValueObject
{
    public record YYYVO(int Value) : ValueObjectBase<int>(Value), IInputLimit<int>
    {
        public const int MinValue = 5;
        public const int MaxValue = 100;
        public const int Step = 5;

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

        protected override void Validate()
        {
            if (!IsValid(Value))
            {
                throw new ArgumentException("Invalid Value", nameof(Value));
            }
        }
    }
}
