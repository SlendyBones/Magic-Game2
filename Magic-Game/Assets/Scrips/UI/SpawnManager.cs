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

    public void WinCondition()
    {
        wl.Shop();
    }

    public void StartSpawn()
    {
        StartCoroutine(StartEnemys());
    }

    public void MinumEnemys(int deathEnemy)
    {
        actualAmountOfEnemy -= deathEnemy;
        if(actualAmountOfEnemy <= 0)
        {
            WinCondition();
        }
    }

    IEnumerator StartEnemys()
    {
        _amountOfEnemy = Random.Range(8, 15);

        for (int i = 0; i < _amountOfEnemy; i++)
        {
            yield return new WaitForSeconds(0.5f);
            Instantiate(_tipeOfEnemy[Random.Range(0, 2)], _spawns[Random.Range(0, 4)].transform.position, _spawns[Random.Range(0, 4)].transform.rotation);
            actualAmountOfEnemy++;
        }
    }
}
