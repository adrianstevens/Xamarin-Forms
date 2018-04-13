using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAudioRecorder
{
    public interface IAudioRecorder
    {
        bool CanRecordAudio { get; }

        Task RecordAsync();

        Task<AudioRecording> StopAsync();
    }
}
