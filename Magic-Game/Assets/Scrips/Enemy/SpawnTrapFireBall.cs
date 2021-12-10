using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrapFireBall : MonoBehaviour
{
    [SerializeField]
    private GameObject _fireBall;
    [SerializeField]
    private float _timer;
    [SerializeField]
    private float _timeforspawn;
    [SerializeField]
    private bool _on = false;
    [SerializeField]
    private Button button;

    [SerializeField] private bool _isButton = true;

    private void Start()
    {
        _timer = _timeforspawn;

        if (_isButton == true)
        {
            button.OnTouchButton += Star;
        }
        else
            _on = true;
    }
    private void Update()
    {
        if (_on == true)
        {
            _timer -= Time.deltaTime;
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (_timer <= 0)
        {
            if (other.gameObject.tag == "Player")
            {
                Instantiate(_fireBall, transform.position, transform.rotation);
                _timer = _timeforspawn;

            }

        }
    }
    public void Star()
    {
        _on = true;
    }
}



