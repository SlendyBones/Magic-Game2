using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField]
    private LayerMask _playerMask;
    [SerializeField]
    private StartTimer _startTimer;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKeyDown("e") && _startTimer._timerIsOnClass == false)
        {
            _startTimer.start = true;
            Destroy(this.gameObject);
        }
    }
}
