using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StatsManager))]
public class TestMovement : MonoBehaviour
{
    private StatsManager statsManager;
    private new Transform transform;
    private Rigidbody2D rigidbody2D;

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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Move(float direction)
    {
        Debug.Log(statsManager.GetModifiedStat(StatType.Speed));
        rigidbody2D.velocity = new Vector2(
            statsManager.GetModifiedStat(StatType.Speed) * direction, 
            rigidbody2D.velocity.y);
    }

    private void Jump()
    {
        Debug.Log(statsManager.GetModifiedStat(StatType.JumpStrength));
        rigidbody2D.AddForce(new Vector2(
            0, 
            statsManager.GetModifiedStat(StatType.JumpStrength)));
    }
}
