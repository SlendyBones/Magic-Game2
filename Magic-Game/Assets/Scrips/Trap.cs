using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private bool _isFireBall = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<StatsManager>().PlayerDamage(_damage);
        }
        else if (_isFireBall)
        {
            Destroy(gameObject);
        }
    }
}
