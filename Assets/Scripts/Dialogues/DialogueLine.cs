using UnityEngine;


// Информация о строчке диалога и о том, кто произносит эту строчку
[System.Serializable]
public class DialogueLine
{
    public SpeakerData speakerData;
    public string text;
    public AudioClip voiceText;
}