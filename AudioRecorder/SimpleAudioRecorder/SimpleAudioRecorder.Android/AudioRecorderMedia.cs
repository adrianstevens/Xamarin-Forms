using System.IO;
using System.Threading.Tasks;
using Android.Media;

namespace SimpleAudioRecorder.Droid
{
    internal class AudioRecorderMedia : IAudioRecorder
    {
        public bool CanRecordAudio => true;

        MediaRecorder mediaRecorder;

        bool isRecording = false;

        string audioFilePath;

        public AudioRecorderMedia()
        {
            mediaRecorder = new MediaRecorder();
        }
       
        public string GetAudioFilePath()
        {
            return audioFilePath;
        }

        AudioRecording GetRecording()
        {
            if (isRecording == true ||
                File.Exists(audioFilePath) == false)
                return null;

            return new AudioRecording(audioFilePath);
        }

        public Task RecordAsync()
        {
            if(isRecording)
                return Task.CompletedTask;

            isRecording = true;

            audioFilePath = Path.Combine("/sdcard/", Path.GetTempFileName());

            mediaRecorder.SetAudioSource(AudioSource.Mic);
            mediaRecorder.SetOutputFormat(OutputFormat.Mpeg4);
            mediaRecorder.SetAudioEncoder(AudioEncoder.Aac);
            mediaRecorder.SetOutputFile(audioFilePath);
            mediaRecorder.Prepare();
            mediaRecorder.Start();

            return Task.CompletedTask;
        }

        public Task<AudioRecording> StopAsync()
        {
            if (isRecording)
            {
                mediaRecorder.Stop();
                mediaRecorder.Reset();
            }

            return Task.FromResult(GetRecording());
        }
    }
}