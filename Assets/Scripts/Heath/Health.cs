using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Health : MonoBehaviour
{
    [SerializeField] Stats stat;
    [SerializeField] Sprite image;
    List<GameObject> _healths = new List<GameObject>();
    [SerializeField] float _indent;

    float _curretHealth;
    private void Start()
    {
        
        Canvas canvas = GetComponent<Canvas>();
        for(int i = 0; i < stat.GetStatValue(StatType.Health); i++)
        {
            _healths.Add(new GameObject($"testAAA-{i}"));
            RectTransform trans = _healths[i].AddComponent<RectTransform>();
            trans.transform.SetParent(canvas.transform); // setting parent
            trans.localScale = Vector3.one;
            trans.anchorMax = new Vector2(0, 1); // setting position, will be on center
            trans.anchorMin = new Vector2(0, 1); // setting position, will be on center
            trans.pivot = new Vector2(0, 1);
            trans.sizeDelta = new Vector2(50, 50); // custom size
            _healths[i].AddComponent<Image>().sprite = image;
            _healths[i].GetComponent<RectTransform>().anchoredPosition = new Vector3((0 + _indent) * i, 0,0);
        }
    }

    public void DecreasHealth()
    {
        Destroy(_healths[^1]);
        _healths.Remove(_healths[^1]);
        Debug.Log(_healths.Count);
        if (_healths.Count == 0)
        {
            //GameOver
        }
    }
    public void AddHealth()
    {
        Canvas canvas = GetComponent<Canvas>();
        _healths.Add(new GameObject($"testAAA-{_healths.Count}"));
        RectTransform trans = _healths[_healths.Count-1].AddComponent<RectTransform>();
        trans.transform.SetParent(canvas.transform); // setting parent
        trans.localScale = Vector3.one;
        trans.anchorMax = new Vector2(0, 1); // setting position, will be on center
        trans.anchorMin = new Vector2(0, 1); // setting position, will be on center
        trans.pivot = new Vector2(0, 1);
        trans.sizeDelta = new Vector2(50, 50); // custom size
        _healths[_healths.Count-1].AddComponent<Image>().sprite = image;
        _healths[_healths.Count-1].GetComponent<RectTransform>().anchoredPosition = new Vector3((0 + _indent) * _healths.Count - 1, 0, 0);
    }
}
