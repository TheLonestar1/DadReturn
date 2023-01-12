using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayVideo : MonoBehaviour
{
    [SerializeField] private int indexOfDialogueOnVideoPlaying = 4;
    [SerializeField] private float playTime = 3f;

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
        dialogueController.CurrentDialogueLineIndex == indexOfDialogueOnVideoPlaying)
        {
            videoPlayer.Play();
            isVideoPlayed = true;
            timeOfPlaying = 0;
            dialogueController.DeactivateDialoguePanel();
        }
        if (timeOfPlaying < playTime)
        {
            timeOfPlaying += Time.deltaTime;
        }
        if (timeOfPlaying > playTime && isVideoPlayed)
        {
            videoPlayer.Stop();
            dialogueController.ActivateDialoguePanel();
            Destroy(this.gameObject);
        }
    }
}
