using DomainModelCommon;

namespace BBBEntity.ValueObject
{
    /// <summary>
    /// BBB2設定の値オブジェクトクラス
    /// </summary>
    /// <param name="Value">設定値</param>
    public record BBB2VO(string Value) : ValueObjectBase<string>(Value), IInputLimit<string>
    {
        private const TextFormatType Type = TextFormatType.HalfWidthAlphanumeric;

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public static bool IsValid(string value)
        {
            if (!value.IsFormatValid(Type))
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
