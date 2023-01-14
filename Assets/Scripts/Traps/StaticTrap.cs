using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticTrap : MonoBehaviour
{
    public static event Action OnEnteringTrap;
    
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (audioSource.clip != null) 
            {
                audioSource.Play();
            }
            OnEnteringTrap?.Invoke();
        }
    }
}
