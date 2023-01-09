using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    // Объекты для хранения информации о диалоге
    [SerializeField] private GameObject dialoguePanel = null;
    [SerializeField] private TMP_Text tmp_speakerName = null;
    [SerializeField] private TMP_Text tmp_dialogueLine = null;
    [SerializeField] private Image portrait = null;
    [SerializeField] private Dialogue currentDialogue = null;

    private int _currentDialogueLineIndex = -1;
    private bool isDialogueActive = false;

    private void Start()
    {   
        // подписка на событие для начала диалога
        DialogueArea.OnEnteringDialogue += LoadDialogue;
    }

    private void Update() 
    {
        if (isDialogueActive)
        {
            // при нажатии клавиши - следующая строчка диалога
            if (Input.GetKeyUp(KeyCode.F))
            {
                NextDialogueLine();
            }
        }
    }

    public void LoadDialogue(Dialogue dialogue)
    {
        ActivateDialoguePanel();
        currentDialogue = dialogue;
        // -1 
        _currentDialogueLineIndex = -1;
        NextDialogueLine();
    }

    public void ActivateDialoguePanel()
    {
        dialoguePanel.SetActive(true);
        isDialogueActive = true;
    }

    public void DeactivateDialoguePanel()
    {
        dialoguePanel.SetActive(false);
        isDialogueActive = false;
    }

    // Загрузка следующей строчки диалога
    public void NextDialogueLine()
    {
        _currentDialogueLineIndex++;
        DialogueLine dialogueLine = currentDialogue.GetDialogueLine
            (
            _currentDialogueLineIndex
            );

        if (dialogueLine == null)
        {
            DeactivateDialoguePanel();
            return;
        }

        tmp_speakerName.text = dialogueLine.speakerData.name;
        tmp_dialogueLine.text = dialogueLine.text;
        portrait.sprite = dialogueLine.speakerData.portrait;
        portrait.color = dialogueLine.speakerData.color;
    }
}
