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
    void Start()
    {
        _rb.AddForce(transform.forward * _rbForce);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != _layerMask)
            Destroy(gameObject);
    }
}
