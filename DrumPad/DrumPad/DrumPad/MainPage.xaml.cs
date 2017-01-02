using SimpleAudio;
using System;
using System.IO;
using System.Reflection;
using Xamarin.Forms;

namespace DrumPad
{
    public partial class MainPage : ContentPage
    {
        ISimpleAudioPlayer playTomTom;
        ISimpleAudioPlayer playSnare;
        ISimpleAudioPlayer playBass;
        ISimpleAudioPlayer playHiHat;

        Animation aniTomTom;
        Animation aniSnare;
        Animation aniBass;
        Animation aniHiHat;

        public MainPage()
        {
            InitializeComponent();

            playBass = DrumPad.App.CreateAudioPlayer();
            playSnare = DrumPad.App.CreateAudioPlayer();
            playTomTom = DrumPad.App.CreateAudioPlayer();
            playHiHat = DrumPad.App.CreateAudioPlayer();

            btnPlayBass.Clicked += BtnPlayBass;
            btnPlaySnare.Clicked += BtnPlaySnare;
            btnPlayTom.Clicked += BtnPlayTomTom;
            btnPlayHiHat.Clicked += BtnPlayHiHat;

            aniTomTom = new Animation(v => btnPlayTom.BackgroundColor = Color.FromRgb(1, v, v), 0, 0.9);
            aniSnare = new Animation(v => btnPlaySnare.BackgroundColor = Color.FromRgb(v, 1, v), 0, 0.9);
            aniBass = new Animation(v => btnPlayBass.BackgroundColor = Color.FromRgb(v, v, 1), 0, 0.9);
            aniHiHat = new Animation(v => btnPlayHiHat.BackgroundColor = Color.FromRgb(1, 1, v), 0, 0.9);

            switchDrumSet.Toggled += SwitchDrumSetToggled;
            sliderVolume.ValueChanged += SliderVolumeValueChanged;

            aniTomTom.Commit(this, "anitt");
            aniSnare.Commit(this, "anisd");
            aniBass.Commit(this, "anibd");
            aniHiHat.Commit(this, "anihh");

            LoadSamples(false);
        }

        private void SliderVolumeValueChanged(object sender, ValueChangedEventArgs e)
        {
            playBass.SetVolume(sliderVolume.Value);
            playSnare.SetVolume(sliderVolume.Value);
            playTomTom.SetVolume(sliderVolume.Value);
            playHiHat.SetVolume(sliderVolume.Value);
        }

        private void SwitchDrumSetToggled(object sender, ToggledEventArgs e)
        {
            LoadSamples(switchDrumSet.IsToggled);
        }

        void LoadSamples (bool altSet)
        {
            string set = altSet ? "2" : "1";

            playBass.Load(GetStreamFromFile($"Samples.bd{set}.wav"));
            playSnare.Load(GetStreamFromFile($"Samples.sd{set}.wav"));
            playTomTom.Load(GetStreamFromFile($"Samples.tt{set}.wav"));
            playHiHat.Load(GetStreamFromFile($"Samples.hh{set}.wav"));
        }

        private void BtnPlayBass(object sender, EventArgs e)
        {
            playBass?.Play();
 
            aniBass?.Commit(this, "anibd");
        }
        private void BtnPlaySnare(object sender, EventArgs e)
        {
            playSnare?.Play();

            aniSnare?.Commit(this, "anisd");
        }
        private void BtnPlayTomTom(object sender, EventArgs e)
        {
            playTomTom?.Play();

            aniTomTom?.Commit(this, "anitt");
        }

        private void BtnPlayHiHat(object sender, EventArgs e)
        {
            playHiHat?.Play();

            aniHiHat?.Commit(this, "anihh");
        }

        Stream GetStreamFromFile(string filename)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;

            var stream = assembly.GetManifestResourceStream("DrumPad." + filename);

            return stream;
        }
    }
}