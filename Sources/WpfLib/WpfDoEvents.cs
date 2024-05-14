using System.Windows.Threading;

namespace WpfLib
{
    /// <summary>
    /// DoEvents
    /// </summary>
    public class WpfDoEvents
    {
        /// <summary>
        /// UIキューに溜まっているタスクを全て処理します。
        /// </summary>
        public static void Execute()
        {
            DispatcherFrame frame = new DispatcherFrame();
            var callback = new DispatcherOperationCallback(obj =>
            {
                ((DispatcherFrame)obj).Continue = false;
                return null;
            });
            Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background, callback, frame);
            Dispatcher.PushFrame(frame);
        }
    }
}
