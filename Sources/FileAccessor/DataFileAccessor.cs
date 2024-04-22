
using Feature.DataFile;

using Microsoft.Win32;

using System.IO;
using System.Windows;

namespace FileAccessor
{
    public class DataFileAccessor : IDataFileAccessor
    {
        public bool Load(ref string content)
        {
            OpenFileDialog openFileDialog = new()
            {
                Filter = "Data file (*.dat)|*.dat"
            };
            if (openFileDialog.ShowDialog() == false)
            {
                return false;
            }

            content = File.ReadAllText(openFileDialog.FileName);

            return true;
        }

        public bool Save(string content)
        {
            SaveFileDialog sfd = new()
            {
                Filter = "Data file (*.dat)|*.dat"
            };
            if (sfd.ShowDialog() == false)
            {
                return false;
            }

            File.WriteAllText(sfd.FileName, content);

            return true;
        }
    }

}
