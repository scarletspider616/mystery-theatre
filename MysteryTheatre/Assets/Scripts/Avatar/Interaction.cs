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

        Animator m_Animator;

        private void Start()
        {
            _avatar = gameObject.GetComponent<AvatarCustomization>();
            // Get the animator associated with the gameObject
            m_Animator = _avatar.Animator;
        }

        public void Speak()
        {
            m_Animator.SetTrigger("Speak");
        }

        public void StopSpeaking() 
        {
            m_Animator.SetTrigger("Stop");
        }
    }
}