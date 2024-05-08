using BBBEntity.ValueObject;

using DomainService;

using Reactive.Bindings;
using Reactive.Bindings.Extensions;

using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace UiParts.UserControls.CccPage
{
    /// <summary>
    /// 行ヘッダのデータクラス
    /// </summary>
    public record RowHeader(string Number, string SwName, string Type, string EL)
    {
    }
}
