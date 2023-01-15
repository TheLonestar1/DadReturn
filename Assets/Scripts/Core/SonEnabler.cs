using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonEnabler : MonoBehaviour
{
    [SerializeField] private DialogueController dialogueController;
    [SerializeField] private bool _isEnabled = false;
    [SerializeField] private int onWhichDialogueEnable;
    [SerializeField] private GameObject girl;

    void Start()
    {
        girl.SetActive(false);
    }

    void Update()
    {
        if (!_isEnabled && 
        dialogueController.CurrentDialogueLineIndex == onWhichDialogueEnable) 
        {
            girl.SetActive(true);
        }
    }
}
