using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldEnemy : Entity
{
    [SerializeField] private int _goldPerHit;

    void Start()
    {
        player = LevelManager.instances.player.transform;
        _ani = new AnimatorController();
        _ani._animator = _animator;
    }

    void Update()
    {
        
    }
}
