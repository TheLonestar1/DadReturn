using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fader : MonoBehaviour
{
    public static Fader GetInstance { get { return _instance; } }

    [SerializeField] private float FadeInStartTime = 1f;

    private static Fader _instance;
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else 
        {
            Destroy(this.gameObject);
        }
        StartCoroutine(FadeIn(FadeInStartTime));
    }

    public void FadeInImmediately()
    {
        canvasGroup.alpha = 0;
    }

    public IEnumerator FadeIn(float time)
    {
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime / time;
            yield return null;
        }
    }

    public IEnumerator FadeOut(float time)
    {
        while (canvasGroup.alpha < 1f)
        {
            canvasGroup.alpha += Time.deltaTime / time;
            yield return null;
        }
    }
}
