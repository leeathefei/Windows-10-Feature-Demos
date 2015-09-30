using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows10FeatureDemos.Dialogs;
using Windows10FeatureDemos.Helper;

namespace Windows10FeatureDemos.Samples
{
    [Menu(Caption = "Content Dialog"
        , Symbol = Symbol.AlignCenter, Order = 10)]
    public sealed partial class ContentDialogSample : UserControl
    {
        public ContentDialogSample()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            AboutDialog aboutDialog = new AboutDialog();
            ContentDialogResult result = await aboutDialog.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                // Close pressed
            }
            else if (result == ContentDialogResult.Secondary)
            {
                // Cancel Pressed 
            }
        }

        private async void Button_Fullscreen_Click(object sender, RoutedEventArgs e)
        {
            AboutDialog aboutDialog = new AboutDialog();
            aboutDialog.FullSizeDesired = true;
            ContentDialogResult result = await aboutDialog.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                // Close pressed
            }
            else if (result == ContentDialogResult.Secondary)
            {
                // Cancel Pressed 
            }

        }
    }
}
