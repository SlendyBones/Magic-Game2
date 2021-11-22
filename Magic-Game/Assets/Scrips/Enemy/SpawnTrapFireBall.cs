using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrapFireBall : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _fireBall;
    [SerializeField]
    private float _timer;
    [SerializeField]
    private float _timeforspawn;


    private void Update()
    {
        _timer -= Time.deltaTime;
    }

    private void OnTriggerStay(Collider other)
    {
        if (_timer <= 0)
        {
            if (other.gameObject.tag == "Player")
            {
                int _spawnFireBall = (Random.Range(0, 6));
                Instantiate(_fireBall[_spawnFireBall], transform.position, transform.rotation);
            }
            _timer = _timeforspawn;
        }
    }

}
