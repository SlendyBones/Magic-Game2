using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
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


    private void Awake()
    {
        player = LevelManager.instances.player.transform;
    }

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
        EventManager.Trigger("AddCoin", _profitsCoins);
        EventManager.Trigger("SubstractEnemy");
        Destroy(gameObject);
    }

    public void CantMakeDamage()
    {
        _damage = 0;
    }

    public void CanMakeDamage()
    {
        _damage = _realDamege;
    }
}
