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
            // m_Animator.GetComponent<Animation>().yourAnimation.wrapMode=WrapMode.Loop;
        }

        public void StartSpeaking()
        {
            Debug.Log("onStartedSpeaking!");
            m_Animator.SetTrigger("Speak");
        }

        public void StopSpeaking() 
        {
            Debug.Log("onStopSpeaking");
            m_Animator.SetTrigger("StopSpeaking");
        }
    }
}