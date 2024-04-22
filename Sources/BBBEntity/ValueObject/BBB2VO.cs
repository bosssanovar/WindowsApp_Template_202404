using DomainModelCommon;

namespace BBBEntity.ValueObject
{
    public record BBB2VO(string Value) : ValueObjectBase<string>(Value), IInputLimit<string>
    {
        private const TextFormatType Type = TextFormatType.HalfWidthAlphanumeric;

        public static string CurrectValue(string value)
        {
            string ret = value;

            if (!IsValid(value))
            {
                if (!value.IsFormatValid(Type))
                {
                    ret = ret.ExtractOnlyAbailableCharacters(Type);
                }
            }
            return ret;
        }

        public static bool IsValid(string value)
        {
            if (!value.IsFormatValid(Type))
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
