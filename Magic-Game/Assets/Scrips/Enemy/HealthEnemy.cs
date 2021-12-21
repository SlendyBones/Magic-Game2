using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemy : Entity
{
    private delegate void Moving();
    Moving _move;

    private List<GameObject> _enemys;

    void Start()
    {
        player = LevelManager.instances.player.transform;
        _ani = new AnimatorController();
        _ani._animator = _animator;
        _move = Movement;

        //_enemys.Add(FindObjectsOfType<>());
    }

    void Update()
    {
        _move();
    }

    void Movement()
    {

    }
}
