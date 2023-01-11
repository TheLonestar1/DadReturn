using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayVideo : MonoBehaviour
{
    [SerializeField] private int indexOnVideoPlaying = 4;

    private VideoPlayer videoPlayer;
    private DialogueController dialogueController;
    private bool isVideoPlayed = false;
    private float timeOfPlaying = Mathf.Infinity;

    private void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        dialogueController = FindObjectOfType<DialogueController>();
    }

    void Update()
    {
        if (!isVideoPlayed && 
        dialogueController.CurrentDialogueLineIndex == indexOnVideoPlaying)
        {
            videoPlayer.Play();
            isVideoPlayed = true;
            timeOfPlaying = 0;
            dialogueController.DeactivateDialoguePanel();
        }
        if (timeOfPlaying < 2f)
        {
            timeOfPlaying += Time.deltaTime;
        }
        if (timeOfPlaying > 2f && isVideoPlayed)
        {
            videoPlayer.Stop();
            dialogueController.ActivateDialoguePanel();
            Destroy(this.gameObject);
        }
    }
}
