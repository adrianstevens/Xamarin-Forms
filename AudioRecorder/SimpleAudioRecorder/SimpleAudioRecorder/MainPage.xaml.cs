using Plugin.SimpleAudioPlayer.Abstractions;
using System;
using Xamarin.Forms;

namespace SimpleAudioRecorder
{
	public partial class MainPage : ContentPage
	{
        ISimpleAudioPlayer player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;

		public MainPage()
		{
			InitializeComponent();

            btnRecord.Clicked += OnRecord;
            btnStop.Clicked += OnStop;
            btnPlay.Clicked += OnPlay;
            btnToText.Clicked += OnSpeechToText;
		}

        async void OnRecord(object sender, EventArgs e)
        {
            try
            {
                await App.AudioRecorder.RecordAsync();
            }
            catch
            {

            }
        }

        async void OnStop(object sender, EventArgs e)
        {
            recording = await App.AudioRecorder.StopAsync();
        }

        AudioRecording recording;

        void OnPlay(object sender, EventArgs e)
        {
            var stream = recording.GetAudioStream();

            player.Load(stream);

            player.Play();
        }

        async void OnSpeechToText(object sender, EventArgs e)
        {
            var speechToText = new BingSpeechToText(Constants.BingSpeechApiKey);

            var result = await speechToText.RecognizeSpeechAsync(recording.GetFilePath());

            if(result != null && !string.IsNullOrWhiteSpace(result.DisplayText))
                lblText.Text = result.DisplayText;

        }
	}
}
