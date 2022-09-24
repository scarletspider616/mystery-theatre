using UnityEngine;

namespace TTS
{
    public abstract class ITTSService : MonoBehaviour
    {
        // TODO return type?
        public abstract void GetAudioClip(string transcript);
    }
}