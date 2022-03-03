using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    //public GameObject destoyedVercion;
    
    public void Destroy()
    {
        //Instantiate(destoyedVercion, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bomb")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
