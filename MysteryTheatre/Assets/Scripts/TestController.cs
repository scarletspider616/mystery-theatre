using System.Collections;
using System.Collections.Generic;
using NLU;
using TMPro;
using UnityEngine;
using Avatar;

public class TestController : MonoBehaviour
{
    [SerializeField] private TMP_InputField textInputField;
    
    [SerializeField] private INLUService nluService;

    [SerializeField] public Interaction interaction;

    public async void CallOnClick()
    {
        //Debug.Log($"NLU SERVICE RESPONSE: {await nluService.GetResponseAsync(textInputField.text)}");
        //Debug.Log($"{textInputField.text}");
        var response = await nluService.GetResponseAsync(textInputField.text);
        Debug.Log(response);
        interaction.Speak(await nluService.GetResponseAsync(textInputField.text));
    }
}