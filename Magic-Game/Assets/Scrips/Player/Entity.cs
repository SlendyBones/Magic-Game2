using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public float life;
    
   

    public void TakeDamage(float dmg)
    {
        life -= dmg;

        if(life <= 0)
        {
            Death();
        }
    }

    public virtual void Death()
    {
        Destroy(gameObject);
    }

  
 
}
