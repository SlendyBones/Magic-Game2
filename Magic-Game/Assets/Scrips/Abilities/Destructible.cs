using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    [SerializeField] private GameObject _particle;
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bomb")
        {
            GameObject particulas = Instantiate(_particle, transform.position, transform.rotation);
            Destroy(particulas, 2f);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
