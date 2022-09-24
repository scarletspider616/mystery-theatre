using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TestController : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField textInputField;

    public void CallOnClick()
    {
        // TODO: call NLU lib to test and log result
        Debug.Log($"{textInputField.text}");
    }
}
