using Repository;

namespace Usecase
{
    /// <summary>
    /// 設定値を確定するユースケース
    /// </summary>
    /// <param name="_aaaRepository"><see cref="IAAARepository"/>インスタンス</param>
    /// <param name="_bbbRepository"><see cref="IBBBRepository"/>インスタンス</param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.NamingRules", "SA1313:Parameter names should begin with lower-case letter", Justification = "<保留中>")]
    public class CommitSettingsUsecase(IAAARepository _aaaRepository, IBBBRepository _bbbRepository)
    {
        /// <summary>
        /// AAA Entityを確定します。
        /// </summary>
        /// <param name="entity">AAA Entity</param>
        public void CommitAAAEntity(AAAEntity.Entity.AAAEntity entity)
        {
            _aaaRepository.Commit(entity);
        }

        /// <summary>
        /// BBB Entityを確定しますl
        /// </summary>
        /// <param name="entity">BBB Entity</param>
        public void CommitBBBEntity(BBBEntity.Entity.BBBEntity entity)
        {
            _bbbRepository.Commit(entity);
        }
    }
}
