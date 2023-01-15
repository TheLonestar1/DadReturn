using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapAudioSource : MonoBehaviour
{
    private AudioSource audioSource;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            audioSource.Play();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            audioSource.Stop();
        }
    }
}
