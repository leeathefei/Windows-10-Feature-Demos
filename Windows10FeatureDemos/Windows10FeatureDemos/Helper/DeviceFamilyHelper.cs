﻿namespace Windows10FeatureDemos.Helper
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
                    _deviceFamily = Windows.ApplicationModel.Resources.Core
                        .ResourceContext
                        .GetForCurrentView()
                        .QualifierValues["DeviceFamily"];
                }
                return _deviceFamily;
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
