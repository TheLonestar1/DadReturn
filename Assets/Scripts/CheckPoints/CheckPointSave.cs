using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CheckPointSave : MonoBehaviour
{
    public static event Action<Vector3> OnSavePoint;

    [SerializeField] private Color colorWhenDeactivated;
    [SerializeField] private Color colorWhenActivated;
    [SerializeField] private GameObject lighting;

    private bool _isActivatedBefore;   

    void Start()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && !_isActivatedBefore)
        {
            _isActivatedBefore = true;
            lighting.SetActive(true);
            OnSavePoint?.Invoke(gameObject.transform.position);
        }
    }
}
