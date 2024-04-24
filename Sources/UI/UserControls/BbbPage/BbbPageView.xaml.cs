using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UiParts.UserControls.AaaAndBbbPage;

namespace UiParts.UserControls.BbbPage
{
    /// <summary>
    /// AaaAndBbbPageView.xaml の相互作用ロジック
    /// </summary>
    public partial class BbbPageView : PageViewBase
    {
        public BbbPageView(BbbPageModel model)
            : base(model)
        {
            BbbPageViewModel(model);

            InitializeComponent();
        }
    }
}
