using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StatsManager))]
public class Movement : MonoBehaviour
{
    private StatsManager _statsManager;
    private Transform _transform;
    private Rigidbody2D _rigidbody2D;
    private bool _isGrounded;
    private bool _isInJumpPoint;

    [SerializeField] private float _lastGroundedTime;
    [SerializeField]  private float _distanceRay;
    [SerializeField] private float _jumpSlowing;
    [SerializeField] private bool _isMovementActive = true;

    private void Start()
    {
        _statsManager = GetComponent<StatsManager>();
        _transform = GetComponent<Transform>();
        _rigidbody2D = GetComponent<Rigidbody2D>(); 
        DialogueController.OnDialogueStart += DisableMovement;
        DialogueController.OnDialogueEnd += EnableMovement;
        JumpPoint.onJumpPointEntering += EnableJumpingOnPoint;
        JumpPoint.onJumpPointExiting += DisableJumpingOnPoint;
    } 

    private void FixedUpdate()
    {
       if (!_isMovementActive) return;
        float direction = Input.GetAxisRaw("Horizontal");
        Move(direction);
    }

    private void Update()
    {
        if (!_isMovementActive) return;
        RaycastHit2D raycastHit = Physics2D.Raycast(gameObject.GetComponent<Transform>().position, Vector2.down * _distanceRay, _distanceRay, layerMask: LayerMask.GetMask("Ground"));
        Debug.DrawRay(this.gameObject.GetComponent<Transform>().position, Vector2.down * _distanceRay);
        if (raycastHit.collider != null)
        {
            if (raycastHit.collider.gameObject.CompareTag("Ground"))
                _isGrounded = true;
            else
                _isGrounded = false;
        }
        else
        {
            _isGrounded = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) && (_isGrounded || _isInJumpPoint ))
        {
            Jump();
        }
    }
    
    private void Move(float direction)
    {
        if(_isGrounded)
        _rigidbody2D.velocity = new Vector2(
            _statsManager.GetModifiedStat(StatType.Speed) * direction, 
            _rigidbody2D.velocity.y);
        else
            _rigidbody2D.velocity = new Vector2(
                _statsManager.GetModifiedStat(StatType.Speed) * direction  / _jumpSlowing,
                _rigidbody2D.velocity.y);
    }

    private void Jump()
    {
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 0);
        Debug.Log(_statsManager.GetModifiedStat(StatType.JumpStrength));
        _rigidbody2D.AddForce(new Vector2(
            0, 
            _statsManager.GetModifiedStat(StatType.JumpStrength)),ForceMode2D.Impulse);
    }

    private void EnableMovement()
    {
        _isMovementActive = true;
    }

    private void DisableMovement()
    {
        _isMovementActive = false;
        _rigidbody2D.velocity = new Vector2(0, 0);
    }

    private void EnableJumpingOnPoint()
    {
        _isInJumpPoint = true;
    }

    private void DisableJumpingOnPoint()
    {
        _isInJumpPoint = false;
    }
}
