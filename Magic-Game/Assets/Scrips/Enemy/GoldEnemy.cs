using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldEnemy : Entity
{
    [SerializeField] private int _goldPerHit;
    [SerializeField] private float _distanceToRun;
    private float _actualDistance;
    [SerializeField] private LayerMask _wall;
    [SerializeField] private float _rayCastDistance;

    private bool _turn = false;

    private delegate void Moving();
    Moving _move;
    Moving _rotate;

    void Start()
    {
        player = LevelManager.instances.player.transform;
        _ani = new AnimatorController();
        _ani._animator = _animator;
        _rotate = RotateOut;
    }

    void Update()
    {
        _actualDistance = Vector3.Distance(player.transform.position, transform.position);
        _rotate();
        if(_actualDistance < _distanceToRun)
        {
            _rotate();

            if (_turn == false)
            {
                RotateOut();
                _turn = true;
            }

            if (!Physics.Raycast(transform.position, transform.forward, _rayCastDistance, _wall))
            {
                Escape();
            }
            else
            {
                _rotate = FixRotate;
            }
        }

        else
        {
            _turn = false;
            _rotate = RotateIn;
        }
    }

    void RotateOut()
    {
        transform.forward = transform.forward - player.transform.forward;
    }
    
    void RotateIn()
    {
        transform.forward =  player.transform.forward - transform.forward;
    }

    void FixRotate()
    {
        transform.forward = transform.right;
    }

    void Escape()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
