using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemy : Entity
{
    private void Start()
    {
        CanMakeDamage();
        SoundManager.instance.PlaySound(SoundID.FLY);
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
        if(other.gameObject.tag == "Shield")
        {
            Destroy(gameObject);
        }
        
        if (other.gameObject.tag == "Player")
        {
            EventManager.Trigger("PlayerDamage", _damage);
            Death();
        }
    }
}
