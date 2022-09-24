using System.Collections;
using System.Collections.Generic;
using Sunbox.Avatars;
using TTS;
using UnityEngine;

namespace Avatar
{
    public class Interaction : MonoBehaviour
    {
        private AvatarCustomization _avatar;
        [SerializeField] private ITTSService _ttsService;

        private void Start()
        {
            _avatar = gameObject.GetComponent<AvatarCustomization>();
        }

        public void Speak(string transcript)
        {
            
        }
    }
}