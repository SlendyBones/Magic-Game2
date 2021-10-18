using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBeheivor : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rb;

    [SerializeField]
    private float _rbForce;

    [SerializeField]
    private LayerMask _layerMask;
    [SerializeField]
    private float dmg;
    void Start()
    {
        _rb.AddForce(transform.forward * _rbForce);
    }

    private void OnTriggerEnter(Collider other)
    {
        Entity entity = other.gameObject.GetComponent<Entity>();
        if (entity != null)
        {
            entity.TakeDamage(dmg);
        }
        SoundManager.instance.PlaySound(SoundID.FRASK);
        Destroy(gameObject);
    }
}
