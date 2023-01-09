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
    private void Start()
    {
        statsManager = GetComponent<StatsManager>();
        transform = GetComponent<Transform>();
        rigidbody2D = GetComponent<Rigidbody2D>(); 
    } 

    private void FixedUpdate()
    {
       
        float direction = Input.GetAxisRaw("Horizontal");
        Move(direction);
        

    }

    private void Update()
    {
        RaycastHit2D raycastHit = Physics2D.Raycast(gameObject.GetComponent<Transform>().position, Vector2.down * _distanceRay, _distanceRay, layerMask: LayerMask.GetMask("Ground"));
        Debug.DrawRay(this.gameObject.GetComponent<Transform>().position, Vector2.down * _distanceRay);
        if (raycastHit.collider != null)
        {
            Debug.Log(raycastHit.collider.gameObject.tag);
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
}
