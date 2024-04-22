using AAAEntity.DataPacket;

using BBBEntity.DataPacket;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainService
{
    public class DataPacket
    {
        public AAAEntityPacket AAAEntityPacket { get; set; } = new();
        public BBBEntityPacket BBBEntityPacket { get; set; } = new();
    }
}
