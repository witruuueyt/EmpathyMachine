using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectedBox1 : MonoBehaviour
{
    public GameObject canvas;
    public GameObject objectToAnimate;
    public string f_talkExcited;
    public string breath;
    private bool hasCollided = false;

    void OnTriggerEnter(Collider Collider)
    {
        Debug.Log("trigger");
        if (!hasCollided && Collider.gameObject.tag == "Player")
        {
            Debug.Log("animation");
            hasCollided = true;
            objectToAnimate.GetComponent<Animator>().Play(f_talkExcited);
            StartCoroutine(CanvasCoroutine());
        }
    }

    IEnumerator CanvasCoroutine()
    {
        yield return new WaitForSeconds(10f);
        canvas.SetActive(true);
        yield return new WaitForSeconds(30f);
        objectToAnimate.GetComponent<Animator>().Play(breath);
    }
}