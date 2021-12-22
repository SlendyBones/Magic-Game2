using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    public float masa = 1f;
    [SerializeField]
    private float dmg =10f;
    [SerializeField] private LayerMask enemy;
  

    private void Awake()
    {
        masa = gameObject.GetComponent<Rigidbody>().mass;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == enemy)
        {
            
            masa += collision.gameObject.GetComponent<Rigidbody>().mass;
            Entity entity = collision.gameObject.GetComponent<Entity>();
            if (entity != null)
            {
                entity.TakeDamage(dmg);
            }
        }
    }
   
    
    
}
