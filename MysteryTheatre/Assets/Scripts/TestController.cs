using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

       if(!_ttsService) {
            Debug.Log("tts service does not exist");
        }

        if(_ttsService.onStartedSpeaking is null || _ttsService.onStoppedSpeaking is null) {
            Debug.Log("onStartedSpeaking service does not exist");
        }

        _ttsService.onStartedSpeaking.AddListener(StartSpeaking);
        _ttsService.onStoppedSpeaking.AddListener(StopSpeaking);
    }

    public async void CallOnClick()
    {
        Debug.Log($"ON CLICK QUERY: {textInputField.text}");
        var responses = await nluService.GetResponseAsync(textInputField.text);
        
        var combinedResponse = string.Join(" ", responses);
        Debug.Log(combinedResponse);
        _ttsService.Speak(combinedResponse);
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