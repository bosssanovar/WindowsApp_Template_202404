using Repository;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usecase
{
    public class CommitSettingsUsecase(IAAARepository _aaaRepository, IBBBRepository _bbbRepository)
    {
        public void CommitAAAEntity(AAAEntity.Entity.AAAEntity entity)
        {
            _aaaRepository.Commit(entity);
        }

        public void CommitBBBEntity(BBBEntity.Entity.BBBEntity entity)
        {
            _bbbRepository.Commit(entity);
        }
    }
}
