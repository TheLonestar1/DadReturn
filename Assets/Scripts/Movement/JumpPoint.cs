using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPoint : MonoBehaviour
{
    public static event Action onJumpPointEntering; // Когда игрок заходит в точку прыжка
    public static event Action onJumpPointExitingOrUsed; // когда игрок выходит из точки прыжка

    [SerializeField] private float _reloadPointTime = 3; // время перезарядки точки
    [SerializeField] SpriteRenderer _sprite; 
    [SerializeField] Color _colorOnNotReady = Color.white; // цвет, когда точка неактивна

    private float _timeAfterLastJump = Mathf.Infinity;
    private Color _colorOnReady; // Цвет, когда точка активна
    private bool _isPointReady; // активна ли точка
    private Movement _playerOnPoint;

    void Start()
    {
        _colorOnReady = _sprite.color;
    }

    private void Update()
    {
        if (_reloadPointTime < _timeAfterLastJump) // если точка готова
        {
            _sprite.color = _colorOnReady;
            _isPointReady = true;
        }
        _timeAfterLastJump += Time.deltaTime;
    }

    public void SetPointAsUsed()
    {
        _sprite.color = _colorOnNotReady;
        _isPointReady = false;
        _timeAfterLastJump = 0f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<Movement>();
        if (player.gameObject && _isPointReady)
        {
            _playerOnPoint = player;
            onJumpPointEntering?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            onJumpPointExitingOrUsed?.Invoke();
        }
    }
}
