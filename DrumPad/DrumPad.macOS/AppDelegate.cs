using AppKit;
using Foundation;
using Xamarin.Forms;
using Xamarin.Forms.Platform.MacOS;
using DrumPad;

namespace DrumPad.macOS
{
    [Register("AppDelegate")]
    public class AppDelegate : FormsApplicationDelegate
    {
        NSWindow window;

        public override NSWindow MainWindow
        {
            get
            {
                return window;
            }
        }

        public AppDelegate()
        {
            var style = NSWindowStyle.Closable | NSWindowStyle.Resizable | NSWindowStyle.Titled;

            var rect = new CoreGraphics.CGRect(100, 100, 1024, 768);
            window = new NSWindow(rect, style, NSBackingStore.Buffered, false);
            window.Title = "DrumPad";
            window.TitleVisibility = NSWindowTitleVisibility.Hidden;

        }


        public override void DidFinishLaunching(NSNotification notification)
        {
            Forms.Init();
			DrumPad.App.CreateAudioPlayer = () => new DrumPad.macOS.SimpleAudioPlayer();

			LoadApplication(new App());
            base.DidFinishLaunching(notification);
        }

        public override void WillTerminate(NSNotification notification)
        {
            // Insert code here to tear down your application
        }
    }
}
