using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : Entity
{
    [SerializeField] private UIManager _uiManager;

    protected delegate void DelegateManaRecharge();
    protected DelegateManaRecharge _manaDelegate = delegate { };

    protected delegate void DelegatePlayerDamage(float dmg);
    protected DelegatePlayerDamage _dmgDelegate;

    public void ManaRecharge()
    {
        _mana += _manaRecharge * Time.deltaTime;
        if (_mana > _maxMana)
        {
            _mana = _maxMana;
            _manaDelegate = delegate { };
        }

        ManaBar();
    }

    public void LifeRecharge(float health)
    {
        _life += health;
        if (_life > _maxLife)
            _life = _maxLife;

        LifeBar();
    }

    public void PlayerDamage(float dmg)
    {
        TakeDamage(dmg);
        LifeBar();
    }

    public void ShieldOn()
    {
        _dmgDelegate = delegate { };
    }

    public void ShieldOff()
    {
        _dmgDelegate = PlayerDamage;
    }

    public bool UseMana(float um)
    {
        _manaDelegate = ManaRecharge;
        if (_mana >= um)
        {
            _mana -= um;
            ManaBar();
            return (true);
        }
        else
            return (false);
    }

    public void ManaUpgrade(float addMana)
    {
        _maxMana += addMana;
        LevelManager.instances.maxMana += addMana;
    }
    
    public void LifeUpgrade(float addHealth)
    {
        _maxLife += addHealth;
        LevelManager.instances.maxMana += addHealth;
    }

    protected void ComparativeStats()
    {
        _maxLife = LevelManager.instances.maxLife;
        _maxMana = LevelManager.instances.maxMana;
    } 

    public void LifeBar()
    {
        _uiManager.SetHealth(_life);
    }

    public void ManaBar()
    {
        _uiManager.SetMana(_mana);
    }
}
