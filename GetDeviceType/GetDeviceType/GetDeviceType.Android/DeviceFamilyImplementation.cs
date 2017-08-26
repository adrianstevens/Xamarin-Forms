using Android.Content.PM;

namespace GetDeviceType.Droid
{
    class DeviceFamilyImplementation : IDeviceFamily
    {
        public DeviceFamily DeviceFamily => GetFamily();

        public UWPDeviceFamily UWPDeviceFamily => UWPDeviceFamily.NotUWP;

        public AndroidDeviceFamily AndroidDeviceFamily => GetAndroidFamily();

        public AppleDeviceFamily AppleDeviceFamily => AppleDeviceFamily.NotApple;

        DeviceFamily GetFamily ()
        {
            return (DeviceFamily)GetAndroidFamily();
        }

        AndroidDeviceFamily GetAndroidFamily()
        {
            return AndroidDeviceFamily.Mobile;
        }
    }
}