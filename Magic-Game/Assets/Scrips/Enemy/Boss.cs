using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Boss : Entity
{
    private delegate void Move();
    Move _move;

    [SerializeField] private float _invokeTime;
    private float _countTime;

    [SerializeField] private GameObject _fireBall;
    [SerializeField] private Transform _spawnPointFire;

    [SerializeField] private GameObject[] _enemys;
    [SerializeField] private Transform[] _spawnPointEnemy;

    [SerializeField] private int _minEnemy, _maxEnemy, _minSpawn, _maxSpawn;

    [SerializeField] private Image _lifeBar;
    [SerializeField] private Animator _animator;

    void Start()
    {
        _move = Movement;
        _ani = new AnimatorController();
        _ani._animator = _animator;
    }

    // Update is called once per frame
    void Update()
    {
        distancePlayer = Vector3.Distance(player.transform.position, transform.position);
        _move();
        //_lifeBar.fillAmount = life/_originalLife;
    }

    void Movement()
    {
        transform.forward = player.position - transform.position;
        transform.position += transform.forward * speed * Time.deltaTime;

        _countTime += Time.deltaTime;

        if (_countTime > _invokeTime)
        {
            _countTime = 0;
            _ani.SetTrigger("SpawnAttack");
        }
        else if (distancePlayer <= attackDistance)
        {
            _ani.SetTrigger("FireAttack");
        }
    }

    
    void Rotate()
    {
        transform.forward = player.position - transform.position;
    }
    
    //Se llama cuando esta casteando la bola de fuego o enemigos
    public void OnlyRotate()
    {
        _move = Rotate;
    }

    //Se llama cuando quieras Instanciar la bola de fuego
    public void AttackFire()
    {
        GameObject fireball = Instantiate(_fireBall, _spawnPointFire.position, _spawnPointFire.rotation);
        Destroy(fireball, 2f);
    }

    public void SpawnEnemy()
    {
        Debug.Log("xd");
        Instantiate(_enemys[Random.Range(_minEnemy, _maxEnemy)], _spawnPointEnemy[Random.Range(_minSpawn, _maxSpawn)].position, _spawnPointEnemy[Random.Range(_minSpawn, _maxSpawn)].rotation);
    }

    //Llamar al final de la animacion para poder volver a caminar
    public void ContinousMoving()
    {
        _move = Movement;
    }
}
