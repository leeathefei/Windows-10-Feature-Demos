using System;
using System.Reflection;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows10FeatureDemos.Helper;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Windows10FeatureDemos.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SamplePage : Page
    {
        public SamplePage()
        {
            this.InitializeComponent();
        }

        public SampleDefinition Sample { get; private set; }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.Sample = e.Parameter as SampleDefinition;
            this.DataContext = this.Sample;
            var fe = (FrameworkElement)Activator.CreateInstance(this.Sample.SampleType);

            _placeHolder.Child = fe;

            base.OnNavigatedTo(e);
        }
    }
}
