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
            }

            element.SetSource(audioStream.AsRandomAccessStream(), "");
            
            return (element == null) ? false : true;
        }

        public void Play()
        {
            if (element == null)
                return;

            if (element.CurrentState == Windows.UI.Xaml.Media.MediaElementState.Playing)
            {
                element.Stop();
                element.Play();
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