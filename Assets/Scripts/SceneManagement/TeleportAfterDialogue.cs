using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportAfterDialogue : MonoBehaviour
{
    private SceneTransition sceneTransition;

    void OnEnable()
    {
        DialogueController.onDialogueEnd += Teleport;
    }

    void OnDisable()
    {
        DialogueController.onDialogueEnd -= Teleport;
    }

    void Start()
    {   
        sceneTransition = GetComponent<SceneTransition>();
        Debug.Log(sceneTransition == null);
    }

    private void Teleport()
    {
        Debug.Log("Teleporting");
        sceneTransition.StartTransition();
    }
}
