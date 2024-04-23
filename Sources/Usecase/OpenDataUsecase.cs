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
        public enum OpenResult
        {
            Completed,
            Canceled,
            Error_InvalidData,
        }

        public OpenResult Execute()
        {
            try
            {
                DataPacket packet = new DataPacket();
                var result = _dataFileAccessor.Load(ref packet);

                if (!result)
                {
                    return OpenResult.Canceled;
                }

                var aaaEntity = _aaaRepository.Pull();
                aaaEntity.ImportPacketData(packet.AAAEntityPacket);

                var bbbEntity = _bbbRepository.Pull();
                bbbEntity.ImportPacketData(packet.BBBEntityPacket);

                _aaaRepository.Commit(aaaEntity);
                _bbbRepository.Commit(bbbEntity);

                return OpenResult.Completed;
            }
            catch
            {
                return OpenResult.Error_InvalidData;
            }
        }
    }
}
