using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : Entity
{
    private float _distance;
    private float _timer;


    [SerializeField]
    private GameObject _shoot;

    // Update is called once per frame
    void Update()
    {
        transform.forward = player.transform.position - transform.position;
        _distance = Vector3.Distance(player.transform.position, transform.position);
        if (_distance < attackDistance && _timer > 1)
        {
            GameObject Bullet = Instantiate(_shoot, transform.position + transform.forward, transform.localRotation);
            Destroy(Bullet, 3f);
            _timer = 0;
        }
        else
            transform.position += transform.forward * Time.deltaTime;

        _timer += 1 * Time.deltaTime;
    }
}
