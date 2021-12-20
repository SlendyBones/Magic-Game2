﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : Entity
{
    private float _distance;
    private float _timer;


    [SerializeField]
    private GameObject _shoot;

    private void Start()
    {
        player = LevelManager.instances.player.transform;
    }

    void Update()
    {
        transform.forward = player.transform.position - transform.position;
        _distance = Vector3.Distance(player.transform.position, transform.position);
        if (_distance < attackDistance && _timer > 1)
        {
            _ani.Animation("Walk", false);
            Shoot();
        }
        else
        {
            transform.position += transform.forward * Time.deltaTime;
            _ani.Animation("Walk", true);
        }
            

        _timer += 1 * Time.deltaTime;
    }
    public void Shoot()
    {
        GameObject Bullet = Instantiate(_shoot, transform.position + transform.forward, transform.localRotation);
        Destroy(Bullet, 3f);
        _timer = 0;
    }
}
