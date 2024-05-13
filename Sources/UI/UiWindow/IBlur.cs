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
        void BlurOn();

        /// <summary>
        /// ぼかし機能OFF
        /// </summary>
        void BlurOff();
    }
}
