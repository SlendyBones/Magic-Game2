using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : Entity
{
    private float _distance;
    private float _timer;


    [SerializeField]
    private GameObject _shoot;

    private void Start()
    {
        player = LevelManager.instances.player.transform;
        _ani = new AnimatorController();
        _ani._animator = _animator;
    }

    void Update()
    {
        if (player == null)
        {
            player = LevelManager.instances.player.transform;
        }
        transform.forward = player.transform.position - transform.position;
        _distance = Vector3.Distance(player.transform.position, transform.position);

        if (_distance < followDistance && _distance > attackDistance)
        {
            transform.position += transform.forward * Time.deltaTime;
            _ani.Animation("Walk", true);
        }
        else if (_distance < attackDistance && _timer > 1)
        {
            _ani.Animation("Walk", false);
            Shoot();
        }
        else
        {
            _ani.Animation("Walk", true);
        }  

        _timer += 1 * Time.deltaTime;
    }
    public void Shoot()
    {
        GameObject Bullet = Instantiate(_shoot, transform.position + transform.forward, transform.localRotation);
        Destroy(Bullet, 3f);
        _timer = 0;
    }
}
