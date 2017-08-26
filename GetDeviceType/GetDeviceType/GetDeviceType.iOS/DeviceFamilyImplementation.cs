using Foundation;
using UIKit;

namespace GetDeviceType.iOS
{
    class DeviceFamilyImplementation : IDeviceFamily
    {
        public DeviceFamily DeviceFamily => GetFamily();

        public UWPDeviceFamily UWPDeviceFamily => UWPDeviceFamily.NotUWP;

        public AndroidDeviceFamily AndroidDeviceFamily => AndroidDeviceFamily.NotAndroid;

        public AppleDeviceFamily AppleDeviceFamily => GetAppleFamily();

        DeviceFamily GetFamily()
        {
            return (DeviceFamily)GetAppleFamily();
        }

        AppleDeviceFamily GetAppleFamily ()
        {
            return AppleDeviceFamily.iOS;
        }
    }
}