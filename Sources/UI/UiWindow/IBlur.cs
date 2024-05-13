using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UiParts.UiWindow
{
    /// <summary>
    /// 画面ぼかし機能
    /// </summary>
    public interface IBlur
    {
        /// <summary>
        /// ぼかし機能ON
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task BlurOnAsync();

        /// <summary>
        /// ぼかし機能OFF
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task BlurOffAsync();
    }
}
