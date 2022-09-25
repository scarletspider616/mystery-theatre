using UnityEngine.Events;

// https://forum.unity.com/threads/easy-speech-synthesis-on-a-mac.524216/

namespace TTS
{
    public class MacTTSService : ITTSService
    {
        public override void Speak(string transcript)
        {
            SpeechProcess = System.Diagnostics.Process.Start("/usr/bin/say", transcript);
        }
    }
}