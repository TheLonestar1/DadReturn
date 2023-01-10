using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CheckPointSave : MonoBehaviour
{
    public static event Action<Vector3> OnSavePoint;
    bool _isActivatedBefore;
    void OnTriggerEnter2D(Collider2D other)
    {
        // если триггер задел игрок и при этом диалог не был активирован ранее:
        // Вызов диалога
        if (other.gameObject.tag == "Player" && !_isActivatedBefore)
        {
            _isActivatedBefore = true;
            OnSavePoint?.Invoke(gameObject.transform.position);
        }
    }
}
