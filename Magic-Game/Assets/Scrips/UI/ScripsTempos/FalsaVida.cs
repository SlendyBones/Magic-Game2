using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalsaVida : MonoBehaviour
{
    public int life=10;
    public int currentLife=10;
    public HealthBar healthBar;

    public int mana=30;
    public int currentMana=30;
    public GameObject Damague;

    private void Start()
    {
        Damague.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            currentLife--;
            healthcheck();
            Damague.SetActive(true);
        }
    }
    public void healthcheck()
    {
        healthBar.SetHealth(currentLife);
    }

    
}
