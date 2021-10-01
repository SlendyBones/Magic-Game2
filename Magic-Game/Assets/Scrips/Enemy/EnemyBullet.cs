using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Entity
{
    private void Start()
    {
        CanMakeDamage();
    }
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * 10;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.GetComponent<Pj>().PlayerDamage(_damage);
            Destroy(gameObject);
        }
    }
}
