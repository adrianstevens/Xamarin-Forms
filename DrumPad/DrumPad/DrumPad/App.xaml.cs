using SimpleAudio;
using System;
using Xamarin.Forms;

namespace DrumPad
{
    public partial class App : Application
    {
        public static Func<ISimpleAudioPlayer> CreateAudioPlayer { get; set; }

        public App()
        {
            InitializeComponent();

            MainPage = new DrumPad.MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}