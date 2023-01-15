using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportAfterDialogue : MonoBehaviour
{
    [SerializeField] private int afterWhichDialogueTeleport = 1;

    private int dialoguesEnded = 0;

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
        dialoguesEnded++;
        if (dialoguesEnded == afterWhichDialogueTeleport)
        {
            Debug.Log("Teleporting");
            sceneTransition.StartTransition();
        }
    }
}
