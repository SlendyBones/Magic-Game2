using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pj : MonoBehaviour
{
    [SerializeField]
    private float _life;
    [SerializeField]
    private float _mana;
    
    public HealthBar healthBar;

    public void  PlayerDamage(float dmg)
    {
        TakeDamage(dmg);
        healthcheck();
    }

    public void healthcheck()
    {
        healthBar.SetHealth(_life);
    }

    public void TakeDamage(float dmg)
    {
        if (_life <= 0)
        {
            Death();
        }
        else
        {
            _life -= dmg;
        }
    }
    public bool UseMana(float um)
    {
        if (_mana > um)
        {
            _mana -= um;
            return (true);
        }
        else
            return (false);
    }

    void Death()
    {
        Destroy(gameObject);
    }
}
