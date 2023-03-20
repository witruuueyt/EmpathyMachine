using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextManager : MonoBehaviour
{
    public TMP_Text inputField; 
    public TMP_Text waitingText;
    public TMP_Text nextText;
    public GameObject after;
    public GameObject decetedbox2;
    private void Start()
    {
        PlayerPrefs.SetString("savedText", "");
        string savedText = PlayerPrefs.GetString("savedText", "");
        waitingText.text = savedText;
    }

    public void SaveText()
    {

        // keyboard kb = FindObjectOfType<keyboard>();
        //  string inputText = kb.letter;

        string inputText = inputField.text;

        PlayerPrefs.SetString("savedText", inputText);
        waitingText.text = inputText;
        StartCoroutine(WaitingCoroutine());

    }

    IEnumerator WaitingCoroutine()
    {
        yield return new WaitForSeconds(3f);
        after.SetActive(true);
        yield return new WaitForSeconds(60f);
        nextText.text = waitingText.text;
        waitingText.text = "";
        decetedbox2.SetActive(true);
    }
}
