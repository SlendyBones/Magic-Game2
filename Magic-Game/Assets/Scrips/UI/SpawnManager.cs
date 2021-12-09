using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private int _amountOfEnemy = 1;
    public int actualAmountOfEnemy = 0;

    [SerializeField]
    private GameObject[] _spawns;
    [SerializeField]
    private GameObject[] _tipeOfEnemy;

    [SerializeField]
    private WLCondition wl;

    [SerializeField]
    private int _minEnemy;
    [SerializeField]
    private int _maxEnemy;

    [Header("EnemyDmg")]
    public float enemyDamage;




    private void Awake()
    {
        EventManager.Subscribe("SubstractEnemy", MinumEnemys);
        EventManager.Subscribe("SpawnAddWave", SpawnAddWave);
        EventManager.Subscribe("SpawnAddWave", SpawnAddWave);
        EventManager.Trigger("StartScene");
    }

    public void WinCondition()
    {
        EventManager.Trigger("AddWave");
        wl.Shop();
    }

    public void StartSpawn()
    {
        StartCoroutine(StartEnemys());
    }

    public void MinumEnemys(params object[] parameter)
    {
        actualAmountOfEnemy -= 1;
        if(actualAmountOfEnemy <= 0)
        {
            WinCondition();
        }
    }

    private void SpawnAddWave(params object[] parameter)
    {
        _minEnemy += (int)parameter[0] * 2;
        _maxEnemy += (int)parameter[0] * 2;
    }

    IEnumerator StartEnemys()
    {
        _amountOfEnemy = Random.Range(_minEnemy, _maxEnemy);

        for (int i = 0; i < _amountOfEnemy; i++)
        {
            yield return new WaitForSeconds(1f);
            Instantiate(_tipeOfEnemy[Random.Range(0, 3)], _spawns[Random.Range(0, 4)].transform.position, _spawns[Random.Range(0, 4)].transform.rotation);
            actualAmountOfEnemy++;
        }
    }

}
