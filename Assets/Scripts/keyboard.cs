using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class keyboard : MonoBehaviour
{
    public TMP_InputField inputField;
    public ButtonManager buttonManager;
    public string letter;

    public void SetLetter(string newLetter)
    {
        letter = newLetter;
    }

    public void OnClick()
    {
        inputField.text += letter;
    }
}
