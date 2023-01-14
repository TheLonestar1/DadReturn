using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField]int _speed;
    bool _isRunnig;
    Rigidbody2D _rigidbody;
    Animator _anim;
    private StatsManager _statsManager;
    [SerializeField] Transform target;
    // Start is called before the first frame update
    void Start()
    {
       _rigidbody =  GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _isRunnig = true;
        _statsManager = GetComponent<StatsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_isRunnig)
        {
            _anim.SetBool("IsWalk", true);
            var heading = target.position - transform.position;
            var distance = heading.magnitude;
            var direction = heading / distance;
            direction.y = 0;
            if (direction.x > 0)
                transform.localScale = new Vector3(-0.9f, 0.925f, 1);
            else
                transform.localScale = new Vector3(0.9f, 0.925f, 1);
            _rigidbody.velocity = _statsManager.GetModifiedStat(StatType.Speed) * direction;
        }
        else
        {
            _anim.SetBool("IsWalk", false);
        }
    }
}
