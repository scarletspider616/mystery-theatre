using System.Collections;
using System.Collections.Generic;
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
        protected bool WasSpeaking;
        protected bool IsSpeaking;

        private void Update()
        {
            if (IsSpeaking == WasSpeaking) return;
            if (IsSpeaking) onStartedSpeaking.Invoke();
            else onStoppedSpeaking.Invoke();
            WasSpeaking = IsSpeaking;
        }

        protected IEnumerator DoSpeak(string cmd, string transcript)
        {
            transcript = transcript.Replace("'", @"\'");
            IsSpeaking = true;
            while (SpeechProcess?.HasExited == false)
            {
                yield return null;
            }

            SpeechProcess = System.Diagnostics.Process.Start(cmd, transcript);
            IsSpeaking = false;
            yield return null;
        }
    }
}