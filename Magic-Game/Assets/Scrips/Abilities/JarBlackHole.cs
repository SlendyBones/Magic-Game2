using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JarBlackHole : MonoBehaviour
{
    [SerializeField]
    GameObject _blackHole;
   
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Pj>())
        {
            Debug.Log("El pj");
        }
        else if (collision.gameObject.GetComponent<Rigidbody>())
        {
           Instantiate(_blackHole, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
