using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueArea : MonoBehaviour
{
    public static event Action<Dialogue> OnEnteringDialogue;

    [SerializeField] private Dialogue dialogue;

    private bool _isActivatedBefore = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        // если триггер задел игрок и при этом диалог не был активирован ранее:
        // Вызов диалога
        if (other.gameObject.tag == "Player" && !_isActivatedBefore)
        {
            _isActivatedBefore = true;
            OnEnteringDialogue?.Invoke(dialogue);
        }
    }
}
