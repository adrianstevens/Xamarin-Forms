namespace GetDeviceType
{
    public interface IDeviceFamily
    {
        DeviceFamily DeviceFamily { get;  }
        UWPDeviceFamily UWPDeviceFamily { get; }

        AppleDeviceFamily AppleDeviceFamily { get; }

        AndroidDeviceFamily AndroidDeviceFamily { get; }
    }

    public enum DeviceFamily
    {
        UWPDesktop,
        UWPIoT,
        UWPIoTHeadless,
        UWPTeam,
        UWPHolographic,
        UWPMobile,
        UWPXbox,
        UWPUniversal,
        
        AndroidMobile = 100,
        AndroidTV,
        AndroidThings,

        AppleiOS = 200,
        AppletvOS,
        ApplemacOS,

        Unknown = 9999
    }

    public enum UWPDeviceFamily
    {
        Desktop,
        IoT,
        IoTHeadless,
        Team,
        Holographic,
        Mobile,
        Xbox,
        Universal,
        NotUWP = 9999
    }

    public enum AndroidDeviceFamily
    {
        Mobile = 100, //phone, tablet
        TV,
        Things,
        NotAndroid = 9999
    }

    public enum AppleDeviceFamily
    {
        iOS = 200,
        tvOS,
        macOS,
        NotApple = 9999
    }
}