using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemy : Entity
{
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
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Pj>().TakeDamage(_damage);
        }
        Death();
    }
}
