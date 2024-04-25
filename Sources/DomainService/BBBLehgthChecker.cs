using BBBEntity.DomainSreviceInterface;

namespace DomainService
{
    /// <summary>
    /// BBB設定の文字列長を確認するクラス。
    /// </summary>
    /// <param name="_aaaEntity">AAA Entity</param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.NamingRules", "SA1313:Parameter names should begin with lower-case letter", Justification = "<保留中>")]
    public class BBBLehgthChecker(AAAEntity.Entity.AAAEntity _aaaEntity) : IBBBLehgthChecker
    {
        /// <inheritdoc/>
        public bool IsValid(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return true;
            }

            return value.Length <= _aaaEntity.AAA.Value;
        }

        /// <summary>
        /// 有効長に切り出した文字列を取得します。
        /// </summary>
        /// <param name="value">文字列</param>
        /// <returns>有効長に切り出した文字列</returns>
        public string Substring(string value)
        {
            return value[.._aaaEntity.AAA.Value];
        }
    }
}
