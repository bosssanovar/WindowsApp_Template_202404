using Repository;

namespace Usecase
{
    /// <summary>
    /// 設定値を初期化するユースケース
    /// </summary>
    /// <param name="_aaaRepository"><see cref="IAAARepository"/>インスタンス</param>
    /// <param name="_bbbRepository"><see cref="IBBBRepository"/>インスタンス</param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.NamingRules", "SA1313:Parameter names should begin with lower-case letter", Justification = "<保留中>")]
    public class InitializeUsecase(IAAARepository _aaaRepository, IBBBRepository _bbbRepository)
    {
        /// <summary>
        /// 全てのEntityを初期化します。
        /// </summary>
        public void Execute()
        {
            var aaaEntity = _aaaRepository.Pull();
            aaaEntity.Initialize();
            _aaaRepository.Commit(aaaEntity);

            var bbbEntity = _bbbRepository.Pull();
            bbbEntity.Initialize();
            _bbbRepository.Commit(bbbEntity);
        }
    }
}
