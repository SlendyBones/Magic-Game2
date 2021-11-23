using System;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField]
    private LayerMask _playerMask;
    [SerializeField]
    private StartTimer _startTimer = null;
    [SerializeField]
    private SpawnManager _spawnManager;

    public Action OnTouchButton;

   
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKeyDown("e") && _startTimer._timerIsOnClass == false)
        {
            if (OnTouchButton !=null)
            {
                OnTouchButton();
            }
            _startTimer.start = true;
            _spawnManager.StartSpawn();
            Destroy(this.gameObject);
        }
    }
}
