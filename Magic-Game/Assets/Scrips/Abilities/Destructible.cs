using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public GameObject destoyedVercion;
    
    public void Destroy()
    {
        Instantiate(destoyedVercion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
