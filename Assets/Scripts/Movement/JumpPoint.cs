using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPoint : MonoBehaviour
{
    public static event Action onJumpPointEntering; // Когда игрок заходит в точку прыжка
    public static event Action onJumpPointExiting; // когда игрок выходит из точки прыжка

    [SerializeField] private float _reloadPointTime = 3; // время перезарядки точки
    [SerializeField] SpriteRenderer _sprite; 
    [SerializeField] Color _colorOnNotReady = Color.white; // цвет, когда точка неактивна

    private float _timeAfterLastJump = Mathf.Infinity;
    private Color _colorOnReady; // Цвет, когда точка активна
    private bool _isPointReady; // активна ли точка

    void Start()
    {
        _colorOnReady = _sprite.color;
    }

    private void Update()
    {
        _timeAfterLastJump += Time.deltaTime;
        if (_reloadPointTime < _timeAfterLastJump) // если точка готова
        {
            _sprite.color = _colorOnReady;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && _reloadPointTime < _timeAfterLastJump)
        {
            onJumpPointEntering?.Invoke();
            _timeAfterLastJump = 0f;
            _sprite.color = _colorOnNotReady;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            onJumpPointExiting?.Invoke();
        }
    }
}
