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
            var aaaEntity = _aaaRepository.Load();
            aaaEntity.Initialize();
            _aaaRepository.Save(aaaEntity);

            var bbbEntity = _bbbRepository.Load();
            bbbEntity.Initialize();
            _bbbRepository.Save(bbbEntity);

        }
    }
}
