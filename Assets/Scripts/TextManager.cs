using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextManager : MonoBehaviour
{
    public TMP_InputField inputField; 
    public TMP_Text waitingText;
    public TMP_Text nextText; 


    private void Start()
    {
        
        string savedText = PlayerPrefs.GetString("savedText", "");
        waitingText.text = savedText;
    }

    public void SaveText()
    {
        
        string inputText = inputField.text;
        PlayerPrefs.SetString("savedText", inputText);
        waitingText.text = inputText;
        StartCoroutine(WaitingCoroutine());

    }

    IEnumerator WaitingCoroutine()
    {
        yield return new WaitForSeconds(30f);
        nextText.text = waitingText.text;
        waitingText.text = "";
    }
}
