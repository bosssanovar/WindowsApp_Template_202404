﻿using DomainModelCommon;

namespace AAAEntity.ValueObject
{
    /// <summary>
    /// XXX設定の値オブジェクトクラス
    /// </summary>
    /// <param name="Value">設定値</param>
    public record XXXVO(XXXType Value) : ValueObjectBase<XXXType>(Value), IInputLimit<XXXType>
    {
        #region Constants -------------------------------------------------------------------------------------

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
        public static XXXType CurrectValue(XXXType value)
        {
            if (IsValid(value))
            {
                return XXXType.Xxx1;
            }

            return value;
        }

        /// <inheritdoc/>
        public static bool IsValid(XXXType value)
        {
            return Enum.IsDefined(typeof(XXXType), value);
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
