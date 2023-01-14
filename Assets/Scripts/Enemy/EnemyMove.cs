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
            _rigidbody.velocity = _statsManager.GetModifiedStat(StatType.Speed) * Vector2.left;
        }
        else
        {
            _anim.SetBool("IsWalk", false);
        }
    }
}
