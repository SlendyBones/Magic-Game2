using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    [SerializeField]
    float _damage;
    [SerializeField]
    GameObject _bullet;
    [SerializeField]
    Transform _bulletSpawnPoint;
    
    [SerializeField]
    float _attackDistance = 10f;
    [SerializeField]
    float _followDistance = 20f;

    bool shoot = false;
    bool follow = false;
    [SerializeField]
    float _speed;
    private PatrolEnemy _patrolEnemy;

    public Transform player;


    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player").transform;
        _patrolEnemy = gameObject.GetComponent<PatrolEnemy>();
    }

    // Update is called once per frame
    void Update()
    {

        float dist = Vector3.Distance(player.transform.position, this.transform.position);
      
        if (dist < _followDistance)
        {
            follow = true;
            if (follow==true)
            {
                _patrolEnemy.start = false;
                if (dist < _attackDistance)
                {
                    shoot = true;
                    Shoot();
                    Debug.Log("pui");
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, player.position, _speed * Time.deltaTime);
                    Debug.Log("Jose");
                }
            }

            else if (shoot)
            {
                transform.position = Vector3.MoveTowards(transform.position, transform.position, _speed * Time.deltaTime);
                Debug.Log("Josa");

            }
          

        }
        else if (follow == false)
        {
            _patrolEnemy.start = true;
            Debug.Log("kill me");
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Pj>())
        {
            collision.gameObject.GetComponent<Pj>().PlayerDamage(_damage);
        }
    }

    void Shoot()
    {
        Instantiate(_bulletSpawnPoint, transform.position, transform.rotation);
    }

}
