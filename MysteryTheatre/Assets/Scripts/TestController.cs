using System.Collections;
using System.Collections.Generic;
using NLU;
using TMPro;
using UnityEngine;

public class TestController : MonoBehaviour
{
    [SerializeField] private TMP_InputField textInputField;
    
    [SerializeField] private INLUService nluService;

    public void CallOnClick()
    {
        Debug.Log($"NLU SERVICE RESPONSE: {nluService.GetResponse(textInputField.text)}");
        Debug.Log($"{textInputField.text}");
    }
}