using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyConroller : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject _target;
    void Start()
    {
        CheckPointController.onRespawn += ChangePosition;
    }

    // Update is called once per frame

    void ChangePosition()
    {
        Vector3 prevpos = transform.position;
        prevpos.x = _target.transform.position.x + (Vector2.right.x * 40);
        transform.position = prevpos;
    }
}
