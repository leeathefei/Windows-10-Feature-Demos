using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows10FeatureDemos.Dialogs;
using Windows10FeatureDemos.Helper;

namespace Windows10FeatureDemos.Samples
{
    [Menu(Caption = "Content Dialog", Symbol = Symbol.Directions)]
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
    }
}
