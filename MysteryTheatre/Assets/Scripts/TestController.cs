using System.Collections;
using System.Collections.Generic;
using NLU;
using TMPro;
using TTS;
using UnityEngine;
using Avatar;

public class TestController : MonoBehaviour
{
    [SerializeField] private TMP_InputField textInputField;
    [SerializeField] private INLUService nluService;
    [SerializeField] public Interaction interaction;


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

    public async void CallOnClick()
    {
        Debug.Log($"ON CLICK QUERY: {textInputField.text}");
        var responses = await nluService.GetResponseAsync(textInputField.text);

        _ttsService.onStartedSpeaking.AddListener(StartSpeaking)
        _ttsService.onStartedSpeaking.AddListener(StopSpeaking)
        
        foreach (var response in responses)
        {
            Debug.Log(response);
            _ttsService.Speak(response);
        }
    }

    void StartSpeaking() 
    {
        interaction.StartSpeaking();
    }

    void StopSpeaking() 
    {
        interaction.StopSpeaking();
    }
}