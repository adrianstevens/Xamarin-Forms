using System;

namespace GetDeviceType.UWP
{
    class DeviceFamilyImplementation : IDeviceFamily
    {
        public DeviceFamily DeviceFamily { get => GetFamily(); }
        public UWPDeviceFamily UWPDeviceFamily { get => GetUWPFamily(); }
        public AndroidDeviceFamily AndroidDeviceFamily { get => AndroidDeviceFamily.NotAndroid; }
        public AppleDeviceFamily AppleDeviceFamily { get => AppleDeviceFamily.NotApple; }
   
        DeviceFamily GetFamily ()
        {
            return (DeviceFamily)GetUWPFamily();
        }

        UWPDeviceFamily GetUWPFamily()
        {
            switch (Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily)
            {
                case "Windows.Mobile":
                    return UWPDeviceFamily.Mobile;
                case "Windows.Desktop":
                    return UWPDeviceFamily.Desktop;
                case "Windows.IoT":
                    return UWPDeviceFamily.IoT;
                case "Windows.IoTHeadless":
                    return UWPDeviceFamily.IoTHeadless;
                case "Windows.Team":
                    return UWPDeviceFamily.Team;
                case "Windows.Xbox":
                    return UWPDeviceFamily.Xbox;
                case "Windows.Holographic":
                    return UWPDeviceFamily.Holographic;
                default:
                    return UWPDeviceFamily.Universal;
            }
        }
    }
}
