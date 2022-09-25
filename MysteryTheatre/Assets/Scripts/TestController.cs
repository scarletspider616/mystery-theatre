using System.Collections;
using System.Collections.Generic;
using NLU;
using TMPro;
using TTS;
using UnityEngine;

public class TestController : MonoBehaviour
{
    [SerializeField] private TMP_InputField textInputField;

    [SerializeField] private INLUService nluService;

    private ITTSService _ttsService;

    private void Start()
    {
        // TODO this shouldn't be here
        if (Application.platform is RuntimePlatform.WindowsEditor or RuntimePlatform.WindowsPlayer)
        {
            gameObject.AddComponent<WindowsTTSService>();
        }
        else if (Application.platform is RuntimePlatform.OSXEditor or RuntimePlatform.OSXPlayer)
        {
            gameObject.AddComponent<MacTTSService>();
        }
        else if (Application.platform is RuntimePlatform.LinuxEditor or RuntimePlatform.LinuxEditor)
        {
            gameObject.AddComponent<LinuxTTSService>();
        }

        _ttsService = gameObject.GetComponent<ITTSService>();
        if (!_ttsService)
        {
            Debug.LogError("COULD NOT GRAB TTS SERVICE FOR PLATFORM");
        }
    }

    public void CallOnClick()
    {
        Debug.Log($"NLU SERVICE RESPONSE: {nluService.GetResponse(textInputField.text)}");
        Debug.Log($"{textInputField.text}");
        
        _ttsService.Speak(nluService.GetResponse(textInputField.text));
    }
}