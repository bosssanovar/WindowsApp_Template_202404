using DomainModelCommon;

namespace AaaEntity.ValueObject
{
    /// <summary>
    /// YYY設定の値オブジェクトクラス
    /// </summary>
    /// <param name="Value">設定値</param>
    public record YyyVO(int Value) : ValueObjectBase<int>(Value), IInputLimit<int>
    {
        #region Constants -------------------------------------------------------------------------------------

        /// <summary>
        /// 最小値
        /// </summary>
        public const int MinValue = 5;

        /// <summary>
        /// 最大値
        /// </summary>
        public const int MaxValue = 700;

        /// <summary>
        /// ステップ
        /// </summary>
        public const int Step = 5;

        #endregion --------------------------------------------------------------------------------------------

        #region Fields ----------------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Properties ------------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Events ----------------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Constructor -----------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - public ------------------------------------------------------------------------------

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

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - internal ----------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - protected ---------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - private -----------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - override ----------------------------------------------------------------------------

        /// <inheritdoc/>
        protected override void Validate()
        {
            if (!IsValid(Value))
            {
                throw new ArgumentException("Invalid Value", nameof(Value));
            }
        }

        #endregion --------------------------------------------------------------------------------------------

        #region Inner Class/Enum/etc. -------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------
    }
}
