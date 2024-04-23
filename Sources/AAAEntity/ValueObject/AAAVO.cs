using DomainModelCommon;

namespace AAAEntity.ValueObject
{
    public record AAAVO(int Value) : ValueObjectBase<int>(Value), IInputLimit<int>
    {
        private const int MixValue = 0;
        private const int MaxValue = 20;

        public static int CurrectValue(int value)
        {
            if(!IsValid(value))
            {
                if (value is < 0)
                {
                    return 0;
                }
                else if (value is > 20)
                {
                    return 20;
                }
            }

            return value;
        }

        public static bool IsValid(int value)
        {
            if(value is <0 or > 20)
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
