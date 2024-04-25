using Feature.DataFile;

using Microsoft.Win32;

using System.IO;

namespace FileAccessor
{
    /// <summary>
    /// 設定ファイルへのアクセスクラス
    /// </summary>
    public class DataFileAccessor : IDataFileAccessor
    {
        /// <inheritdoc/>
        public bool Load(ref string content)
        {
            OpenFileDialog openFileDialog = new()
            {
                Filter = "Data file (*.dat)|*.dat",
            };
            if (openFileDialog.ShowDialog() == false)
            {
                return false;
            }

            content = File.ReadAllText(openFileDialog.FileName);

            return true;
        }

        /// <inheritdoc/>
        public bool Save(string content)
        {
            SaveFileDialog sfd = new()
            {
                Filter = "Data file (*.dat)|*.dat",
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
