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
    private Fader fader;

    void Start()
    {
        currentCheckPoint = transform.position;
        CheckPointSave.OnSavePoint += SaveNewPoint;
        fader = GameObject.FindObjectOfType<Fader>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var trap = other.GetComponent<StaticTrap>();

        if (trap)
        {
            StopAllCoroutines();
            if (fader != null)
            {
                fader.FadeInImmediately();
            }
            
            StartCoroutine(TeleportOnPoint());
        }
    }

    void SaveNewPoint(Vector3 point)
    {
        currentCheckPoint = point;
    }

    private IEnumerator TeleportOnPoint()
    {
        onDie?.Invoke();
        yield return fader.FadeOut(fadeOutTime);
        transform.position = currentCheckPoint;
        yield return new WaitForSeconds(fadeWaitTime);
        onRespawn?.Invoke();
        yield return fader.FadeIn(FadeInTime);
        
    }
}
