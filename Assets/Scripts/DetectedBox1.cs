using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectedBox1 : MonoBehaviour
{
   
    public GameObject objectToAnimate;
    public string f_talkExcited;
    private bool hasCollided = false;

    void OnCollisionEnter(Collision collision)
    {
        if (!hasCollided && collision.gameObject.tag == "Player")
        {
            hasCollided = true;
            objectToAnimate.GetComponent<Animator>().Play(f_talkExcited);
        }
    }
}