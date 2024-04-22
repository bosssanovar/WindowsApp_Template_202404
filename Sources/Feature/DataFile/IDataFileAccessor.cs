using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feature.DataFile
{
    public interface IDataFileAccessor
    {
        void Save(string content);
    }
}
