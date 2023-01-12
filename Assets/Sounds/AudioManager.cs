using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource { get; private set; }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    
}
