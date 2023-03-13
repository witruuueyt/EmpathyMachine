using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectedBox2 : MonoBehaviour
{
    public GameObject door1;
    public GameObject door2;
    public string door;
    private bool hasCollided = false;

    void OnTriggerEnter(Collider Collider)
    {
        Debug.Log("trigger");
        if (!hasCollided && Collider.gameObject.tag == "Player")
        {
            Debug.Log("animation");
            hasCollided = true;
            door1.GetComponent<Animator>().Play(door);
            door2.GetComponent<Animator>().Play(door);
        }
    }

}
