using DomainService;

using System.Text.Json;

namespace Feature.DataFile
{
    /// <summary>
    /// 設定ファイルのアクセサ―クラス
    /// </summary>
    /// <param name="_fileAccessor"><see cref="IDataFileAccessor"/>インスタンス</param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.NamingRules", "SA1313:Parameter names should begin with lower-case letter", Justification = "<保留中>")]
    public class DataFileAccessor(IDataFileAccessor _fileAccessor)
    {
        private readonly JsonSerializerOptions _options = new()
        {
            WriteIndented = true,
        };

        /// <summary>
        /// ファイルに保存します。
        /// </summary>
        /// <param name="packet">設定データ群</param>
        /// <returns>正常終了したらtrue</returns>
        public bool Save(DataPacket packet)
        {
            var jsonString = JsonSerializer.Serialize(packet, _options);

            return _fileAccessor.Save(jsonString);
        }

        /// <summary>
        /// ファイルから読み込みます。
        /// </summary>
        /// <param name="packet">設定データ群</param>
        /// <returns>正常終了したらtrue</returns>
        public bool Load(ref DataPacket packet)
        {
            string content = string.Empty;
            var result = _fileAccessor.Load(ref content);

            if (!result)
            {
                return false;
            }

            var p = JsonSerializer.Deserialize<DataPacket>(content);
            if (p is null)
            {
                return false;
            }

            packet = p;
            return true;
        }
    }
}
