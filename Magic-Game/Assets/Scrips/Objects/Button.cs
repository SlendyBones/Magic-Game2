using System;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField]
    private StartTimer _startTimer = null;
    [SerializeField]
    private SpawnManager _spawnManager;

    public Action OnTouchButton;


    private void Start()
    {
        EventManager.Subscribe("StartTimer", StartTimer);
    }

    private void StartTimer(params object[] parameter)
    {
        if(_startTimer._timerIsOnClass == false)
        {
            if (OnTouchButton != null)
            {
                OnTouchButton();
            }
            _startTimer.start = true;
            _spawnManager.StartSpawn();
            Destroy(this.gameObject);
        }
    }
}
