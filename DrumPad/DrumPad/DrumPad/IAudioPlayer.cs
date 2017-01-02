using System.IO;

namespace SimpleAudio
{
    public interface ISimpleAudioPlayer
    {
        bool Load(Stream audioStream);

        void Play();

        void Pause();

        void Stop();

        void SetVolume(double volume);
    }
}