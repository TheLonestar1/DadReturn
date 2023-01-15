using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalconVoices : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && audioSource.clip != null)
        {
            audioSource.Play();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // if (other.gameObject.tag == "Player" && audioSource.isPlaying)
        // {
        //     audioSource.Stop();
        // }
    }
}
