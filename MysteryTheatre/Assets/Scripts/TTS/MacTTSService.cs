using System.Collections;
using UnityEngine;

// https://forum.unity.com/threads/easy-speech-synthesis-on-a-mac.524216/

namespace TTS
{
    public class MacTTSService : ITTSService
    {
        private const string CMD = "/usr/bin/say";

        public override void Speak(string transcript)
        {
            StartCoroutine(DoSpeak(CMD, transcript));
        }
    }
}