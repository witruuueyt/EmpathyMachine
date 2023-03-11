using UnityEngine;
using UnityEngine.Video;

public class ActivateTVVideo : MonoBehaviour
{
    public VideoPlayer videoPlayer; // assign this in the Inspector
    public float activationDistance = 2f; // how close the player needs to be to activate the video

    private Transform player; // reference to the player's transform

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= activationDistance)
        {
            videoPlayer.Play(); // start playing the video if the player is close enough
        }
        else
        {
            videoPlayer.Pause(); // pause the video if the player is too far away
        }
    }
}

