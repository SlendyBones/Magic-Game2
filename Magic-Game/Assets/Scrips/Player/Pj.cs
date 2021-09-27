using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pj : MonoBehaviour
{
    [SerializeField]
    private float _life;
    [SerializeField]
    private float _mana;

    public bool manaOn = true;
    public HealthBar healthBar;
    public HealthBar manaBar;

    public void  PlayerDamage(float dmg)
    {
        TakeDamage(dmg);
        healthcheck();
    }

    public void healthcheck()
    {
        healthBar.SetHealth(_life);
    }

    public void ManaBar()
    {
        manaBar.SetHealth(_mana);
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
        if (_mana >= um)
        {
            _mana -= um;
            ManaBar();
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
