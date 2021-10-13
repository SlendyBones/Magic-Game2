﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemy : Entity
{
    private void Start()
    {
        CanMakeDamage();
    }


    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.forward = player.position - transform.position;
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Movement>().PlayerDamage(_damage);
        Death();
    }
}
