using System.Collections;
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

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKeyDown("e") && _startTimer._timerIsOnClass == false)
        {
            _startTimer.start = true;
            _spawnManager.StartSpawn();
            Destroy(this.gameObject);
        }
    }
}
