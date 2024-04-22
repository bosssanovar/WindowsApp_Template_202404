
using Feature.DataFile;

using Microsoft.Win32;

using System.IO;

namespace FileAccessor
{
    public class DataFileAccessor : IDataFileAccessor
    {
        public void Save(string content)
        {
            SaveFileDialog sfd = new()
            {
                Filter = "Data file (*.dat)|*.dat"
            };
            if (sfd.ShowDialog() == true)
            {
                File.WriteAllText(sfd.FileName, content);
            }
        }
    }

}
