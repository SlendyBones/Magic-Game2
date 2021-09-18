using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    
    public int currentlifehearth;
    public int maxcurrentlifehearth;
    public HealthBar healthBar;
    public FalsaVida falsaVida;
    private void Start()
    {
        currentlifehearth = falsaVida.currentLife;
        maxcurrentlifehearth = falsaVida.life;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            if (falsaVida.currentLife == falsaVida.life)
            {
                Debug.Log("You are full mijo");
            }
            else if (falsaVida.currentLife <= falsaVida.life)
            {

                falsaVida.currentLife++;
                healthCheck();
                Destroy(this.gameObject);
            }
        }
    }

    public void healthCheck()
    {
        healthBar.SetHealth(falsaVida.currentLife); 
    }

   
}