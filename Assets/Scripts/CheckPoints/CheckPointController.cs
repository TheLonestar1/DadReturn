using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CheckPointController : MonoBehaviour
{
    public static event Action onDie;
    public static event Action onRespawn;
    [SerializeField] private float FadeInTime = 0.5f;
    [SerializeField] private float fadeWaitTime = 0.2f;
    [SerializeField] private float fadeOutTime = 0.4f;

    private Vector3 currentCheckPoint;

    void Start()
    {
        currentCheckPoint = transform.position;
        CheckPointSave.OnSavePoint += SaveNewPoint;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var trap = other.GetComponent<StaticTrap>();
        Fader fader = Fader.GetInstance;
        if (trap)
        {
            StopAllCoroutines();
            if (fader != null)
            {
                fader.FadeInImmediately();
            }
            
            StartCoroutine(TeleportOnPoint(fader));
        }
    }

    void SaveNewPoint(Vector3 point)
    {
        currentCheckPoint = point;
    }

    private IEnumerator TeleportOnPoint(Fader fader)
    {
        onDie?.Invoke();
        yield return fader.FadeOut(fadeOutTime);
        transform.position = currentCheckPoint;
        yield return new WaitForSeconds(fadeWaitTime);
        onRespawn?.Invoke();
        yield return fader.FadeIn(FadeInTime);
        
    }
}
