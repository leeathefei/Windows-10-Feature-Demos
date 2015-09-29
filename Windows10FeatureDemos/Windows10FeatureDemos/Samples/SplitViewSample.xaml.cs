using Windows.UI.Xaml.Controls;
using Windows10FeatureDemos.Helper;

namespace Windows10FeatureDemos.Samples
{

    [Menu(Caption = "Split View", Symbol = Symbol.ZoomOut, Order = 5)]
    public sealed partial class SplitViewSample : UserControl
    {
        public SplitViewSample()
        {
            this.InitializeComponent();
        }

        private void _hamburgerButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            _splitView.IsPaneOpen = !_splitView.IsPaneOpen;
        }

        private void _list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _splitView.IsPaneOpen = false;
        }
    }
}
