using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemy : Entity
{
    [SerializeField] private float _healAmount;
    [SerializeField] private float _actualTargetDistance;
    [SerializeField] private float _castDistance;
    [SerializeField] private float _timerToCast;
    private float _interenalTimer;
    
    private delegate void Moving();
    Moving _move;

    [SerializeField] private List<GameObject> _enemys = new List<GameObject>();
    private GameObject _nearEnemy = null;

    void Start()
    {
        player = LevelManager.instances.player.transform;
        _ani = new AnimatorController();
        _ani._animator = _animator;
        _move = Movement;

        _enemys = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));

        NearEnemyCheck();
    }

    void Update()
    {
        if(_nearEnemy != null)
        {
            _move();
        }
        else
        {
            _enemys = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
            NearEnemyCheck();
        }
    }

    void Movement()
    {
        _actualTargetDistance = Vector3.Distance(transform.position, _nearEnemy.transform.position);

        if (_actualTargetDistance > _castDistance)
        {
            Rotate();
            transform.position += transform.forward * Time.deltaTime * speed;
        }
        else if (_interenalTimer > _timerToCast)
        {
            _ani.SetTrigger("Heal");
            _interenalTimer = 0;
        }

        _interenalTimer += 1 * Time.deltaTime;
    }

    void Rotate()
    {
        transform.forward = _nearEnemy.transform.position - transform.position;
    }

    void NearEnemyCheck()
    {
        for (int i = 0; i < _enemys.Count; i++)
        {
            if (_nearEnemy = null)
            {
                _nearEnemy = _enemys[i];
            }

            float comparativeDistance = Vector3.Distance(transform.position, _enemys[i].transform.position);

            float actualDistance = Vector3.Distance(transform.position, _nearEnemy.transform.position);

            if (comparativeDistance < actualDistance)
            {
                _nearEnemy = _enemys[i];
            }
        }
    }

    public void Heal()
    {
        _nearEnemy.GetComponent<Entity>().Heal(_healAmount);
    }

    public void CanMove()
    {
        _move = Movement;
    }

    public void OnlyRotate()
    {
        _move = Rotate;
    }

    public void CantMove()
    {
        _move = delegate { };
    }
}
