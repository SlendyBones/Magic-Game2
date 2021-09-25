using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float delay=2;
    public float radius = 5f;
    public float force = 500f;
    public float damage = 15f;

    public GameObject explosionEffect;

    private float _countDown;
    bool _hasExploded = false;
    void Start()
    {
        _countDown = delay;
    }

    void Update()
    {
        _countDown -= Time.deltaTime;
        if (_countDown <= 0f && !_hasExploded)
        {
            Explote();
            _hasExploded = true;
        }
    }

    void Explote()
    {
        Debug.Log("Boom");
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Collider [] collidersToDestroy =Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearbyObject in collidersToDestroy)
        {
            Destructible dest = nearbyObject.GetComponent<Destructible>();
            if (dest != null)
            {
                dest.Destroy();
            }
        }

        Collider[] collidersToMove = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in collidersToMove)
        {
            Rigidbody _rb = nearbyObject.GetComponent<Rigidbody>();
            if (_rb != null)
            {
                _rb.AddExplosionForce(force, transform.position, radius);
            }
        }
        Collider[] collidersToMakeDamage = Physics.OverlapSphere(transform.position, radius);
        
        foreach (Collider nearbyObject in collidersToMakeDamage)
        {
            Enemy eni = nearbyObject.GetComponent<Enemy>();
            if(eni != null)
            {
                eni.TakeDamage(damage);
               
            }
        }
        Destroy(gameObject);
    }
}
