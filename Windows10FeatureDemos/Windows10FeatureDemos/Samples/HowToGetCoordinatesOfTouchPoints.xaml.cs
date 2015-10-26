using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows10FeatureDemos.Helper;

namespace Windows10FeatureDemos.Samples
{
    [Menu(Caption = "How to get Coordinates of Touch Point", Symbol = Symbol.Audio, Order = 100)]
    public sealed partial class HowToGetCoordinatesOfTouchPoints : UserControl
    {
        public HowToGetCoordinatesOfTouchPoints()
        {
            this.InitializeComponent();
        }

        private void _theCanvas_Tapped(object sender, TappedRoutedEventArgs e)
        {
            _pointerDeviceType.Text = e.PointerDeviceType.ToString();
            var position = e.GetPosition(_root);
            _x.Text = position.X.ToString();
            _y.Text = position.Y.ToString();
        }
    }
}
