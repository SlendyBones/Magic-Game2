using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pj : Entity
{
    public HealthBar healthBar;
    public void  PlayerDamage(float dmg)
    {
        TakeDamage(dmg);
        healthcheck();
    }

    public void healthcheck()
    {
        healthBar.SetHealth(life);
    }
}
