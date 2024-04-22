using Repository;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usecase
{
    public class InitializeUsecase(IAAARepository _aaaRepository, IBBBRepository _bbbRepository)
    {
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
