using UnityEngine;
using UnityEngine.Events;

namespace TTS
{
    public abstract class ITTSService : MonoBehaviour
    {
        public abstract void Speak(string transcript);

        public UnityEvent onStartedSpeaking;
        public UnityEvent onStoppedSpeaking;

        protected System.Diagnostics.Process SpeechProcess;
        private bool _wasSpeaking;

        private void Update()
        {
            var isSpeaking = (SpeechProcess != null && !SpeechProcess.HasExited);
            if (isSpeaking == _wasSpeaking) return;
            if (isSpeaking) onStartedSpeaking.Invoke();
            else onStoppedSpeaking.Invoke();
            _wasSpeaking = isSpeaking;
        }
    }
}