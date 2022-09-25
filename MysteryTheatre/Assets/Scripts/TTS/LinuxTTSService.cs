namespace TTS
{
    public class LinuxTTSService : ITTSService
    {
        private const string CMD = "/usr/bin/spd-say";

        public override void Speak(string transcript)
        {
            StartCoroutine(DoSpeak(CMD, transcript));
        }
    }
}