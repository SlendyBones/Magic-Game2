﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Entity
{
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * 10;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            EventManager.Trigger("PlayerDamage", _damage);
            SoundManager.instance.PlaySound(SoundID.EBULLET);
            Destroy(gameObject);
        }
    }
}
