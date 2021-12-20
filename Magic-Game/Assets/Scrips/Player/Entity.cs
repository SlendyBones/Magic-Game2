using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [Header("GeneralVar")]
    [SerializeField]protected float _life, _maxLife, _mana, _maxMana, _manaRecharge;
    public float speed;
    public float _damage;
    
    protected AnimatorController _ani;

    [Header("PlayerVar")]
    protected WLCondition winLose;

    [Header("EnemyVar")]
    [SerializeField] private bool isEnemy;
    [SerializeField] private bool _boss = false;

    [SerializeField] private GameObject _heal;
    private int _randomNumber;
    private int _probability;
    [SerializeField] private int _profitsCoins;

    #region EnemyVar
    protected float distancePlayer;
    public Transform player;

    public float attackDistance = 10f;
    public float followDistance = 20f;
    #endregion


    public void TakeDamage(float dmg)
    {
        _life -= dmg;

        if (_life <= 0)
        {
            if (isEnemy)
                EnemyDeath();
            else
                Death();
        }
    }

    protected void EnemyDeath()
    {
        _randomNumber = Random.Range(1, 101);

        if (_randomNumber < _probability)
        {
            Instantiate(_heal, transform.position, transform.rotation);
        }

        if (_boss == true)
        {
            EventManager.Trigger("WinScene");
        }

        EventManager.Trigger("AddCoin", _profitsCoins);
        EventManager.Trigger("SubstractEnemy");
        Destroy(gameObject);
    }

    protected void Death()
    {
        _ani.Animation("Die", true);
        StartCoroutine(LoadScene());
    }
    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(2);
        EventManager.Trigger("DeathCoin");
        winLose.LoseScreen();
    }
}
