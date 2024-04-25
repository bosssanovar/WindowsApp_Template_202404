using Repository;

namespace Usecase
{
    /// <summary>
    /// 設定値を取得するユースケース
    /// </summary>
    /// <param name="_aaaRepository"><see cref="IAAARepository"/>インスタンス</param>
    /// <param name="_bbbRepository"><see cref="IBBBRepository"/>インスタンス</param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.NamingRules", "SA1313:Parameter names should begin with lower-case letter", Justification = "<保留中>")]
    public class DisplaySettingsUsecase(IAAARepository _aaaRepository, IBBBRepository _bbbRepository)
    {
        /// <summary>
        /// AAA Entityを取得します。
        /// </summary>
        /// <returns>AAA Entity</returns>
        public AAAEntity.Entity.AAAEntity GetAAAEntity()
        {
            return _aaaRepository.Pull();
        }

        /// <summary>
        /// BBB Entityを取得します。
        /// </summary>
        /// <returns>BBB Entity</returns>
        public BBBEntity.Entity.BBBEntity GetBBBEntity()
        {
            return _bbbRepository.Pull();
        }
    }
}
