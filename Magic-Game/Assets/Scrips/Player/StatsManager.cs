using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : Entity
{
    [SerializeField] protected UIManager _uiManager;

    protected delegate void DelegateManaRecharge();
    protected DelegateManaRecharge _manaDelegate = delegate { };

    public delegate void DelegatePlayerDamage(float dmg);
    public DelegatePlayerDamage _dmgDelegate;

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
        _mana = _maxMana;
        LevelManager.instances.maxMana = _maxMana;
        LevelManager.instances.manaLVL++;
    }

    public void DamageUpgrade(float addDmg)
    {
        _damage += addDmg;
        LevelManager.instances.dmg = _damage;
        LevelManager.instances.dmgLVL++;
    }

    public void LifeUpgrade(float addHealth)
    {
        _maxLife += addHealth;
        _life = _maxLife;
        LevelManager.instances.maxLife = _maxLife;
        LevelManager.instances.lifeLVL++;
    }

    protected void ComparativeStats()
    {
        _maxLife = LevelManager.instances.maxLife;
        _life = _maxLife;
        _maxMana = LevelManager.instances.maxMana;
        _mana = _maxMana;
        _damage = LevelManager.instances.dmg;
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
