using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerCamera : MonoBehaviour
{
    private Transform player;
    private new Transform transform;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        transform = GetComponent<Transform>();
    }

    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, -10);
    }
}
