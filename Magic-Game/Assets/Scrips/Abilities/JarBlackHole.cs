using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JarBlackHole : MonoBehaviour
{
    [SerializeField]
    GameObject _blackHole;

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(_blackHole, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
