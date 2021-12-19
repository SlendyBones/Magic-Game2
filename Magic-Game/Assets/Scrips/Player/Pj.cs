using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pj : MonoBehaviour
{
    [SerializeField]
    protected float _life;
    [SerializeField]
    protected float _maxLife;
    [SerializeField]
    protected float _mana;
    [SerializeField]
    protected float _maxMana;

    [SerializeField]
    private float _manaRecharge;

    [SerializeField]
    private float _upgradeValue;

    public bool manaOn = true;
    public HealthBar healthBar;
    public HealthBar manaBar;

    [SerializeField]
    private WLCondition wl;

    protected AnimatorController _ani;

    protected delegate void DelegateManaRecharge();
    protected DelegateManaRecharge ManaRecharge = delegate { };


    public void MRecharge()
    {
        _mana += _manaRecharge * Time.deltaTime;
        if (_mana > _maxMana)
        {
            _mana = _maxMana;
            ManaRecharge = delegate { };
        }

        ManaBar();
    }

    public void LifeRecharge(params object[] parameter)
    {
        _life += (float)parameter[0];
        if (_life > _maxLife)
            _life = _maxLife;

        LifeBar();
    }

    public void PlayerDamage(params object[] parameter)
    {
        TakeDamage((float)parameter[0]);
        LifeBar();
    }

    public void LifeBar()
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
        ManaRecharge = MRecharge;
        if (_mana >= um)
        {
            _mana -= um;
            ManaBar();
            return (true);
        }
        else
            return (false);
    }

    public void ManaUpgrade(params object[] parameter)
    {
        Debug.Log("mana");
        _maxMana += _upgradeValue;
        LevelManager.instances.maxMana += _upgradeValue;
    }
    
    public void LifeUpgrade(params object[] parameter)
    {
        Debug.Log("vida");
        _maxLife += _upgradeValue;
        LevelManager.instances.maxMana += _upgradeValue;
    }

    protected void ComparativeStats()
    {
        _maxLife = LevelManager.instances.maxLife;
        _maxMana = LevelManager.instances.maxMana;
    }

    void Death()
    {
        _ani.Animation("Die" ,true);
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(2);
        EventManager.Trigger("DeathCoin");
        wl.LoseScreen();
    }
}
