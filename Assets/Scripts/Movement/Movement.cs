using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StatsManager))]
public class Movement : MonoBehaviour
{
    private StatsManager statsManager;
    private new Transform transform;
    private Rigidbody2D rigidbody2D;
    private bool _isGrounded;

    [SerializeField] private float _lastGroundedTime;
    [SerializeField]  private float _distanceRay;
    [SerializeField] private float _jumpSlowing;
    [SerializeField] private bool _isMovementActive = true;

    private void Start()
    {
        statsManager = GetComponent<StatsManager>();
        transform = GetComponent<Transform>();
        rigidbody2D = GetComponent<Rigidbody2D>(); 
        DialogueController.OnDialogueStart += DisableMovement;
        DialogueController.OnDialogueEnd += EnableMovement;
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
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            Jump();
        }
    }
    private void Move(float direction)
    {
        if(_isGrounded)
        rigidbody2D.velocity = new Vector2(
            statsManager.GetModifiedStat(StatType.Speed) * direction, 
            rigidbody2D.velocity.y);
        else
            rigidbody2D.velocity = new Vector2(
                statsManager.GetModifiedStat(StatType.Speed) * direction  / _jumpSlowing,
                rigidbody2D.velocity.y);
    }

    private void Jump()
    {
        Debug.Log(statsManager.GetModifiedStat(StatType.JumpStrength));
        rigidbody2D.AddForce(new Vector2(
            0, 
            statsManager.GetModifiedStat(StatType.JumpStrength)),ForceMode2D.Impulse);
    }

    private void EnableMovement()
    {
        _isMovementActive = true;
    }

    private void DisableMovement()
    {
        _isMovementActive = false;
        rigidbody2D.velocity = new Vector2(0, 0);
    }
}
