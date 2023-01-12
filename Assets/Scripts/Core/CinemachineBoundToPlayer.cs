using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineBoundToPlayer : MonoBehaviour
{
    private bool isBounded = false;
    private CinemachineVirtualCamera camera = null;

    void Start()
    {
        camera = GetComponent<CinemachineVirtualCamera>();
    }

    void Update()
    {
        if (!isBounded)
        {
            var player = GameObject.FindGameObjectWithTag("Player");
            if (player)
            {
                camera.LookAt = player.transform;
                camera.Follow = player.transform;
                isBounded = true;
            }
        }
    }
}
