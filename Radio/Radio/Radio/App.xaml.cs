using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.SimpleAudioPlayer;
using System.IO;
using System.Reflection;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace Radio
{
    public partial class App : Application
    {
        public static GameManager GameMan = new GameManager();

        public static Plugin.SimpleAudioPlayer.Abstractions.ISimpleAudioPlayer ButtonPlayer;

        public App()
        {
            InitializeComponent();
		
			MainPage = new NavigationPage(new HomePage());

            DependencyService.Register<NavigationService>();

            ButtonPlayer = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            var audioStream = GetStreamFromFile("Audio.click.mp3");
            ButtonPlayer.Load(audioStream);
        }

        protected override void OnStart()
        {
           
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        Stream GetStreamFromFile(string filename)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;

            var stream = assembly.GetManifestResourceStream("Radio." + filename);
            return stream;
        }
    }
}