using System;
using Windows.UI.Xaml.Controls;
using Windows10FeatureDemos.Helper;

namespace Windows10FeatureDemos.Samples
{
    [Menu(Caption = "Device Family", Symbol = Symbol.AllApps)]
    public sealed partial class DeviceFamilySample : UserControl
    {
        public DeviceFamilySample()
        {
            this.InitializeComponent();

            GetDeviceFamily();
        }

        private void GetDeviceFamily()
        {
            var d = Windows
                .ApplicationModel
                .Resources
                .Core
                .ResourceContext
                .GetForCurrentView()
                .QualifierValues["DeviceFamily"];
            _deviceFamily.Text = d;
        }
    }
}
