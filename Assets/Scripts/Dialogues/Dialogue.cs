using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewDialogue", menuName = "Dialogues/Create New Dialogue", order = 2)]
public class Dialogue : ScriptableObject
{
    [SerializeField] private List<DialogueLine> dialogueLines = null;

    // Следующая строчка диалога, если индекс больше количества
    // диалоговых строчек - возвращение значения null
    public DialogueLine GetDialogueLine(int index)
    {
        if (index >= dialogueLines.Count) return null;
        return dialogueLines[index];
    }
}