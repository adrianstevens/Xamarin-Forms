using SimpleAudio;
using System;
using System.IO;
using Uri = Android.Net.Uri;

namespace DrumPad.Droid
{
    class SimpleAudioPlayer : ISimpleAudioPlayer
    {
        Android.Media.MediaPlayer player;

        static int index = 0;

        System.Collections.Generic.Dictionary<int, string> cacheFiles = new System.Collections.Generic.Dictionary<int, string>();

        string path;
        public bool Load(Stream audioStream)
        {
            //cache to the file system
            path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), $"cache{index++}.wav");
            var fileStream = File.Create(path);
            audioStream.CopyTo(fileStream);
            fileStream.Close();
            audioStream.Close();

            return Load(path);
        }

        bool Load (string path)
        {
            var context = Android.App.Application.Context;

            //load the cached audio into MediaPlayer
            player?.Dispose();
            player = new Android.Media.MediaPlayer();

            try
            {
                player.SetDataSource(path);
            }
            catch
            {
                try
                {
                    player?.SetDataSource(context, Uri.Parse(Uri.Encode(path)));
                }
                catch
                {
                    return false;
                }
            }

            player.Prepare();

            player.Completion += OnPlaybackEnded;

            return true;
        }

        void OnPlaybackEnded(object sender, EventArgs e)
        {
            player.SeekTo(0);
            player.Stop();
            player.Prepare();
        }

        public void Play()
        {
            if (player == null && string.IsNullOrWhiteSpace(path) == false)
                player.SetDataSource(path);

            if (player.IsPlaying)
            {
                player.Pause();
                player.SeekTo(0);
            }

            player.Start();
        }

        public void Stop ()
        {
            player?.Stop();
        }

        public void Pause ()
        {
            player?.Pause();
        }

        public void SetVolume (double volume)
        {
            volume = Math.Max(0, volume);
            volume = Math.Min(1, volume);

            player.SetVolume((float)volume, (float)volume);
        }
    }
}