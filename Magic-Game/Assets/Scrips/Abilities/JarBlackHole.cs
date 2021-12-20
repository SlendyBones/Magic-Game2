using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JarBlackHole : MonoBehaviour
{
    [SerializeField] private GameObject _blackHole;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float forceOfTroward;

    private void Start()
    {
        rb.AddForce(transform.forward * forceOfTroward);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(_blackHole, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
