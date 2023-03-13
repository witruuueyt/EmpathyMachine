using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    private keyboard[] keyboards;

    void Start()
    {
        keyboards = FindObjectsOfType<keyboard>();
    }

    public void SetLetter(string letter)
    {
        foreach (var kb in keyboards)
        {
            kb.SetLetter(letter);
        }
    }
}
