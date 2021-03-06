using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float delay=2;
    public float radius = 5f;
    public float force = 500f;
    public float damage = 15f;

    [SerializeField] private Rigidbody rb;
    [SerializeField] private float forceOfTroward = 40f;

    [SerializeField]
    private GameObject _particleExplosion;

    private float _countDown;
    bool _hasExploded = false;
    void Start()
    {
        _countDown = delay;
        rb.AddForce(transform.forward * forceOfTroward);
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
        SoundManager.instance.PlaySound(SoundID.EXPLOSION);

        Collider[] collidersToMove = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in collidersToMove)
        {
            Rigidbody _rb = nearbyObject.GetComponent<Rigidbody>();
            if (_rb != null && nearbyObject.gameObject.tag!="Player")
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
        foreach (Collider nearbyObject in collidersToMakeDamage)
        {
            RangeEnemy rangeeni = nearbyObject.GetComponent<RangeEnemy>();
            if (rangeeni != null)
            {
                rangeeni.TakeDamage(damage);

            }
        }
        foreach (Collider nearbyObject in collidersToMakeDamage)
        {
            FlyEnemy flyeni = nearbyObject.GetComponent<FlyEnemy>();
            if (flyeni != null)
            {
                flyeni.TakeDamage(damage);

            }
        }
        foreach (Collider nearbyObject in collidersToMakeDamage)
        {
            MeleEnemy meleeni = nearbyObject.GetComponent<MeleEnemy>();
            if (meleeni != null)
            {
               meleeni.TakeDamage(damage);

            }
        }
        foreach (Collider nearbyObject in collidersToMakeDamage)
        {
            Boss bossu = nearbyObject.GetComponent<Boss>();
            if (bossu != null)
            {
                bossu.TakeDamage(damage);

            }
        }
        foreach (Collider nearbyObject in collidersToMakeDamage)
        {
            HealthEnemy heal = nearbyObject.GetComponent<HealthEnemy>();
            if (heal != null)
            {
                heal.TakeDamage(damage);

            }
        }
        foreach (Collider nearbyObject in collidersToMakeDamage)
        {
            GoldEnemy gold = nearbyObject.GetComponent<GoldEnemy>();
            if (gold != null)
            {
                gold.TakeDamage(damage);

            }
        }
        Instantiate(_particleExplosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
