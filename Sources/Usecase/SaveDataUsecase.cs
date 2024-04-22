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
    public class SaveDataUsecase(IAAARepository _aaaRepository,
                                 IBBBRepository _bbbRepository,
                                 DataFileAccessor _dataFileAccessor)
    {
        public void Execute()
        {
            var aaaEntity = _aaaRepository.Load();
            var aaaEntityPacket = aaaEntity.ExportPacketData();

            var bbbEntity = _bbbRepository.Load();
            var bbbEntityPacket = bbbEntity.ExportPacketData();

            var packet = new DataPacket()
            {
                AAAEntityPacket = aaaEntityPacket,
                BBBEntityPacket = bbbEntityPacket,
            };

            _dataFileAccessor.Save(packet);
        }
    }
}
