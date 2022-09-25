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

    public void CallOnClick()
    {
        Debug.Log($"NLU SERVICE RESPONSE: {nluService.GetResponse(textInputField.text)}");
        Debug.Log($"{textInputField.text}");
        interaction.Speak("hi");

    }
}