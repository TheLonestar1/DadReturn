using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] int sceneToLoad;
    [SerializeField] float fadeOutTime = 0.5f;
    [SerializeField] float fadeWaitTime = 1f;
    [SerializeField] float fadeInTime = 0.5f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartTransition();
        }
    }

    public void StartTransition()
    {
        Fader fader = Fader.GetInstance;
        StopAllCoroutines();
        fader.FadeInImmediately();
        StartCoroutine(Transition(fader));
    }

    private IEnumerator Transition(Fader fader)
    {
        DontDestroyOnLoad(gameObject);
        yield return fader.FadeOut(fadeOutTime);
        yield return new WaitForSeconds(fadeWaitTime);
        yield return SceneManager.LoadSceneAsync(sceneToLoad);
        yield return fader.FadeIn(fadeInTime);
        Destroy(gameObject);
    }
}
