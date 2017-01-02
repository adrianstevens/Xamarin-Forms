using SimpleAudio;
using System.IO;
using Windows.UI.Xaml.Controls;
using System;

namespace DrumPad.UWP
{
    class SimpleAudioPlayer : ISimpleAudioPlayer
    {
        MediaElement element;

        public bool Load(Stream audioStream)
        {
            if (element == null)
            {
                element = new MediaElement() { AutoPlay = false };
                element.CurrentStateChanged += ElementCurrentStateChanged;
            }

            element.SetSource(audioStream.AsRandomAccessStream(), "");
            
            return (element == null) ? false : true;
        }

        private void ElementCurrentStateChanged(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if(element.CurrentState == Windows.UI.Xaml.Media.MediaElementState.Stopped && restart == true)
            {
                restart = false;
                element.Play();
            }
        }

        bool restart = false;
        public void Play()
        {
            if (element == null)
                return;

            if (element.CurrentState == Windows.UI.Xaml.Media.MediaElementState.Playing)
            {
                element.Stop();
                restart = true;
            }
            else
            {
                element.Play();
            }
            
        }

        public void Pause()
        {
            element?.Pause();
        }
        public void Stop()
        {
            if(element != null)
            {
                element.Stop();
                element.Position = TimeSpan.Zero;
            }
        }

        public void SetVolume(double volume)
        {
            volume = Math.Max(0, volume);
            volume = Math.Min(1, volume);

            element.Volume = volume;
        }
    }
}