﻿using DomainModelCommon;

namespace AAAEntity.ValueObject
{
    public record AAAVO(int Value) : ValueObjectBase<int>(Value), IInputLimit<int>
    {
        public const int MinValue = 0;
        public const int MaxValue = 20;

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

        public static bool IsValid(int value)
        {
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
