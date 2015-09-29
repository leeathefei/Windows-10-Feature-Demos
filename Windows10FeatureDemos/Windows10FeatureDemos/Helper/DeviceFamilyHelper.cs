using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows10FeatureDemos.Helper
{
    public class DeviceFamilyHelper
    {
        private static string _deviceFamily;

        public static string DeviceFamily
        {
            get
            {
                if (_deviceFamily == null)
                {
                    _deviceFamily = Windows
                        .ApplicationModel
                        .Resources
                        .Core
                        .ResourceContext
                        .GetForCurrentView().QualifierValues["DeviceFamily"];
                }
                return _deviceFamily;

                // Results: Desktop, Mobile, ....
            }
        }

        public static bool IsDesktop
        {
            get { return DeviceFamily == "Desktop"; }
        }

        public static bool IsMobile
        {
            get { return DeviceFamily == "Mobile"; }
        }
    }
}
