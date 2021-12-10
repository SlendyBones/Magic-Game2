using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    public float life;
    protected float distancePlayer;
    public Transform player;
    public float attackDistance = 10f;
    public float followDistance = 20f;
    public float speed;
    public float _damage;
    public float _realDamege;

    [SerializeField]
    private int _profitsCoins;

    [SerializeField] private GameObject _heal;
    private int _randomNumber;
    private int _probability;

    [SerializeField] private bool _boss = false;


    public void TakeDamage(float dmg)
    {
        life -= dmg;

        if(life <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        _randomNumber = Random.Range(1, 101);

        if(_randomNumber < _probability)
        {
            Instantiate(_heal, transform.position, transform.rotation);
        }

        if(_boss == true)
        {
            EventManager.Trigger("WinScene");
        }

        EventManager.Trigger("AddCoin", _profitsCoins);
        EventManager.Trigger("SubstractEnemy");
        Destroy(gameObject);
    }

    public void CantMakeDamage(params object[] parameter)
    {
        _damage = 0;
    }

    public void CanMakeDamage(params object[] parameter)
    {
        _damage = _realDamege;
    }
}
