using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    public float masa = 1f;
  

    private void Awake()
    {
        masa = gameObject.GetComponent<Rigidbody>().mass;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody>())
        {
            masa += collision.gameObject.GetComponent<Rigidbody>().mass;
            Destroy(collision.gameObject);
        }
    }
    // Update is called once per frame
    
    
}
