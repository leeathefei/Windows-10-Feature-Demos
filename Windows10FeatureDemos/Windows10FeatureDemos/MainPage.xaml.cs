using Windows.Foundation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows10FeatureDemos.Helper;
using Windows10FeatureDemos.Views;

namespace Windows10FeatureDemos
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.Loaded += (s, e) =>
            {
                App.MainViewModel.RootFrame = _rootFrame;
                _rootFrame.Navigate(typeof(StartPage));
            };

            ApplicationView.GetForCurrentView().SetPreferredMinSize(
                new Size()
                {
                    Width = 320,
                    Height = 320
                }
                );
        }

        private void _hamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            _splitView.IsPaneOpen = !_splitView.IsPaneOpen;
        }

        private void _mainMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            App.MainViewModel.ShowSample(_mainMenu.SelectedItem as SampleDefinition);
            _splitView.IsPaneOpen = false;
        }

        private void _backButton_Click(object sender, RoutedEventArgs e)
        {
            App.MainViewModel.GoBack();
        }
    }
}
