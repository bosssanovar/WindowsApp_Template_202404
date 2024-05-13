using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace WpfLib
{
    /// <summary>
    /// <see cref="Storyboard"/>の拡張
    /// </summary>
    public static class StoryboardExtensions
    {
        /// <summary>
        /// アニメーションを開始します。
        /// </summary>
        /// <param name="storyboard">ストーリーボード</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public static Task BeginAsync(this Storyboard storyboard)
        {
            System.Threading.Tasks.TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
            if (storyboard == null)
            {
                tcs.SetException(new ArgumentNullException());
            }
            else
            {
                EventHandler? onComplete = null;
                onComplete = (s, e) =>
                {
                    storyboard.Completed -= onComplete;
                    tcs.SetResult(true);
                };
                storyboard.Completed += onComplete;
                storyboard.Begin();
            }

            return tcs.Task;
        }
    }
}
