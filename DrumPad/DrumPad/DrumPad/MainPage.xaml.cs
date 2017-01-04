using SimpleAudio;
using System;
using System.IO;
using System.Reflection;
using Xamarin.Forms;

namespace DrumPad
{
    public partial class MainPage : ContentPage
    {
        enum DrumType
        {
            TomTom,
            Snare,
            Bass,
            HiHat,
            count
        }

        ISimpleAudioPlayer[] players = new ISimpleAudioPlayer[(int)DrumType.count];
        Animation[] animations = new Animation[(int)DrumType.count];

        public MainPage()
        {
            InitializeComponent();

            imgLogo.Source = ImageSource.FromResource("DrumPad.logo.png");

            Color colorButton = btnPlayBass.BackgroundColor;
            Color colorHighlight = Color.FromHex("#EF5A56");

            for (int i = 0; i < (int)DrumType.count; i++)
                players[i] = DrumPad.App.CreateAudioPlayer();

            animations[(int)DrumType.Bass]   = new Animation(v => btnPlayBass.BackgroundColor   = GetBlendedColor(colorButton, colorHighlight, v), 0, 1);
            animations[(int)DrumType.HiHat]  = new Animation(v => btnPlayHiHat.BackgroundColor  = GetBlendedColor(colorButton, colorHighlight, v), 0, 1);
            animations[(int)DrumType.Snare]  = new Animation(v => btnPlaySnare.BackgroundColor  = GetBlendedColor(colorButton, colorHighlight, v), 0, 1);
            animations[(int)DrumType.TomTom] = new Animation(v => btnPlayTomTom.BackgroundColor = GetBlendedColor(colorButton, colorHighlight, v), 0, 1);

            btnPlayBass.Clicked   += (s, e) => OnDrumButton(DrumType.Bass);
            btnPlaySnare.Clicked  += (s, e) => OnDrumButton(DrumType.Snare);
            btnPlayTomTom.Clicked += (s, e) => OnDrumButton(DrumType.TomTom);
            btnPlayHiHat.Clicked  += (s, e) => OnDrumButton(DrumType.HiHat);

            pickerKits.SelectedIndexChanged += (s, e) => LoadSamples(pickerKits.SelectedIndex + 1);

            LoadSamples(1);
        }

        void OnDrumButton(DrumType drumType)
        {
            players[(int)drumType]?.Play();
            animations[(int)drumType]?.Commit(this, drumType.ToString());
        }

        void LoadSamples(int index)
        {
            if (index < 1 || index > 2)
                return;

            players[(int)DrumType.Bass].Load(GetStreamFromFile($"Audio.bd{index}.wav"));
            players[(int)DrumType.Snare].Load(GetStreamFromFile($"Audio.sd{index}.wav"));
            players[(int)DrumType.TomTom].Load(GetStreamFromFile($"Audio.tt{index}.wav"));
            players[(int)DrumType.HiHat].Load(GetStreamFromFile($"Audio.hh{index}.wav"));
        }
      
        Stream GetStreamFromFile(string filename)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream("DrumPad." + filename);

            return stream;
        }

        Color GetBlendedColor(Color color1, Color color2, double percentage)
        {
            return new Color(percentage * color1.R + (1 - percentage) * color2.R,
                             percentage * color1.G + (1 - percentage) * color2.G,
                             percentage * color1.B + (1 - percentage) * color2.B);
        }
    }
}