using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    public float masa = 1f;
    [SerializeField]
    private float dmg =99999999f; 
  

    private void Awake()
    {
        masa = gameObject.GetComponent<Rigidbody>().mass;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            
            masa += collision.gameObject.GetComponent<Rigidbody>().mass;
            Entity entity = collision.gameObject.GetComponent<Entity>();
            if (entity != null)
            {
                entity.TakeDamage(dmg);
            }
        }
    }
    // Update is called once per frame
    
    
}
