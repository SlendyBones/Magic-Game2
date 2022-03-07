using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampaDisparo : MonoBehaviour
{
    [SerializeField] private GameObject _proyectil;
    [SerializeField] private float _myTimer;
    [SerializeField] private float _shootTime;

    void Update()
    {
        if(_myTimer > _shootTime)
        {
            _myTimer = 0;
            GameObject _thisBullet = Instantiate(_proyectil, transform.position, transform.rotation);
            Destroy(_thisBullet, 2f);
        }

        _myTimer += Time.deltaTime;
    }
}
