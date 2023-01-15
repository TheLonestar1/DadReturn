using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] int _speed;
    bool _isRunnig;
    Rigidbody2D _rigidbody;
    Animator _anim;
    private StatsManager _statsManager;
    [SerializeField] Transform target;
    [SerializeField] DialogueController controller;
    float _koeef = 1f;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _isRunnig = false;
        _statsManager = GetComponent<StatsManager>();
        DialogueController.onDialogueEnd += t;
        DialogueController.onDialogueStart += t2;
    }

    void t()
    { 
        if (controller.NumberOfFinishedDialogues == 1)
            _isRunnig = true;
        
    }
    void t2()
    {
        if (controller.NumberOfFinishedDialogues == 1)
            _koeef = -1f;
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
                transform.localScale = new Vector3(-0.9f * _koeef, 0.925f, 1);
            else
                transform.localScale = new Vector3(0.9f * _koeef, 0.925f, 1);
            _rigidbody.velocity = _statsManager.GetModifiedStat(StatType.Speed) * direction * _koeef;
        }
        else
        {
            _anim.SetBool("IsWalk", false);
        }
    }
}
