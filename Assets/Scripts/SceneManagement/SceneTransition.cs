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
            StartCoroutine(Transition());
        }
    }

    public IEnumerator Transition()
    {
        Fader fader = FindObjectOfType<Fader>();
        DontDestroyOnLoad(gameObject);
        yield return fader.FadeOut(fadeOutTime);
        yield return SceneManager.LoadSceneAsync(sceneToLoad);
        yield return new WaitForSeconds(fadeWaitTime);
        yield return fader.FadeIn(fadeInTime);
        Destroy(gameObject);
    }
}
