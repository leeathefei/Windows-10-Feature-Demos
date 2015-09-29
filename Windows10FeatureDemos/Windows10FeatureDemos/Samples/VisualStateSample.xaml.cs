using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows10FeatureDemos.Helper;

namespace Windows10FeatureDemos.Samples
{
    [Menu(Caption = "Visual State", Symbol = Symbol.Accept, Order = 7)]
    public sealed partial class VisualStateSample : UserControl
    {
        public VisualStateSample()
        {
            this.InitializeComponent();

            this.SizeChanged += VisualStateSample_SizeChanged;
        }

        private void VisualStateSample_SizeChanged(object sender, Windows.UI.Xaml.SizeChangedEventArgs e)
        {
            var state = "OneColumnsState";
            if (e.NewSize.Width > 500)
            {
                state = "TwoColumnsState";
            }
            if (e.NewSize.Width > 800)
            {
                state = "ThreeColumnsState";
            }
            VisualStateManager.GoToState(this, state, true);

        }
    }
}
