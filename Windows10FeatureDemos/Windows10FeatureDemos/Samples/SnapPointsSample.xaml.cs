using Windows.Foundation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows10FeatureDemos.Helper;

namespace Windows10FeatureDemos.Samples
{
    [Menu(Caption = "Snap Points", Symbol = Symbol.Add)]
    public sealed partial class SnapPointsSample : UserControl
    {
        public SnapPointsSample()
        {
            this.InitializeComponent();

            ApplicationView.GetForCurrentView().SetPreferredMinSize(
                new Size() {
                    Width = 320,
                    Height = 320
                }
                );
        }
    }
}
