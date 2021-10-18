using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pj : MonoBehaviour
{
    [SerializeField]
    private float _life;
    [SerializeField]
    private float _mana;
    public float manararecharge;

    public bool manaOn = true;
    public HealthBar healthBar;
    public HealthBar manaBar;

    [SerializeField]
    public AnimatorController _animatorController;

    [SerializeField]
    private WLCondition wl;

    private void Awake()
    {
        healthBar.SetMaxHealth(_life);
        manaBar.SetMaxHealth(_mana);
    }

    public void ManaRecharge()
    {
        _mana += manararecharge * Time.deltaTime;
        if (_mana > 50)
            _mana = 50;

        if (_mana < 0)
            _mana = 0;

        ManaBar();
    }

    public void PlayerDamage(float dmg)
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
        _life -= dmg;
        if (_life <= 0)
            Death();
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
        _animatorController.Animation("Die" ,true);
        /*move.GetComponent<Movement>().enabled = false;
        move.GetComponent<CameraRotation>().enabled = false;*/
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(2);
        wl.LoseScreen();
    }
}
