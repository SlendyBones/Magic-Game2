using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private int _amountOfEnemy = 1;
    public int actualAmountOfEnemy = 0;

    private bool _finishSpawn = false;
    private bool _isOff = true;
    [SerializeField]
    private GameObject[] _spawns;
    [SerializeField]
    private GameObject[] _tipeOfEnemy;

    [SerializeField]
    private WLCondition wl;

    void Update()
    {
        if (_amountOfEnemy > actualAmountOfEnemy && _finishSpawn == false && _isOff == false)
        {
            for (int i = 0; i < _amountOfEnemy; i++)
            {
                Instantiate(_tipeOfEnemy[Random.Range(0, 2)], _spawns[Random.Range(0, 4)].transform.position, _spawns[Random.Range(0, 4)].transform.rotation);
                actualAmountOfEnemy++;
            }
            _finishSpawn = true;
        }

        /*if (_amountOfEnemy == actualAmountOfEnemy && _isOff == false)
        {
            _finishSpawn = true;
            Debug.Log("aca");
        }*/
            

        if (actualAmountOfEnemy == 0 && _finishSpawn == true && _isOff == false)
            WinCondition();
    }

    public void WinCondition()
    {


        wl.WinScreen();

    }

    public void StartSpawn()
    {
        _amountOfEnemy = Random.Range(14, 18);
        Debug.Log(_amountOfEnemy);
        _isOff = false;
    }
}
