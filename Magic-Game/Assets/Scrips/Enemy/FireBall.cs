using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : Entity
{
    private float _timer = 10f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Movement>().PlayerDamage(_damage);
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Floor")
        {
            Destroy(gameObject);
        }
        else if (_timer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
