using AaaEntity.DomainSreviceInterface;

namespace DomainService
{
    /// <summary>
    /// AAA設定に関連する設定値を補正するクラス
    /// </summary>
    /// <param name="_aaaEntity">AAA Entity</param>
    /// <param name="_bbbEntity">BBB Entity</param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.NamingRules", "SA1313:Parameter names should begin with lower-case letter", Justification = "<保留中>")]
    public class AaaChangedEvent(AaaEntity.Entity.AaaEntity _aaaEntity, BbbEntity.Entity.BbbEntity _bbbEntity) : IAaaChangedEvent
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
        public void Execute()
        {
            var maxLength = _aaaEntity.Aaa.Value;

            var bbb = _bbbEntity.Bbb.Value;
            if (bbb.Length > maxLength)
            {
                var substring = bbb[0..maxLength];
                _bbbEntity.SetBbb(new(substring), new BbbLehgthChecker(_aaaEntity));
            }

            var bbb2 = _bbbEntity.Bbb2.Value;
            if (bbb2.Length > maxLength)
            {
                var substring = bbb2[0..maxLength];
                _bbbEntity.SetBbb2(new(substring), new BbbLehgthChecker(_aaaEntity));
            }
        }

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - internal ----------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - protected ---------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - private -----------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - override ----------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Inner Class/Enum/etc. -------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------
    }
}
