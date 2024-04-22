using DomainService;

using Feature.DataFile;

using Repository;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usecase
{
    public class OpenDataUsecase(IAAARepository _aaaRepository,
                                 IBBBRepository _bbbRepository,
                                 DataFileAccessor _dataFileAccessor)
    {
        public bool Execute()
        {
            DataPacket packet = new DataPacket();
            var result = _dataFileAccessor.Load(ref packet);

            if (!result)
            {
                return false;
            }

            var aaaEntity = _aaaRepository.Pull();
            aaaEntity.ImportPacketData(packet.AAAEntityPacket);
            _aaaRepository.Commit(aaaEntity);

            var bbbEntity = _bbbRepository.Pull();
            bbbEntity.ImportPacketData(packet.BBBEntityPacket);
            _bbbRepository.Commit(bbbEntity);

            return true;
        }
    }
}
