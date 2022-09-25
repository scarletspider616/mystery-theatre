namespace TTS
{
    public class LinuxTTSService : ITTSService
    {
        public override void Speak(string transcript)
        {
            SpeechProcess = System.Diagnostics.Process.Start("/usr/bin/spd-say", transcript);
        }
    }
}