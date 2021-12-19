﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : Pj
{
    [Header("Inputs")]
    private float _horizontalMove;
    private float _verticalMove;
    private Vector3 _playerInput;

    [Header("Components")]
    public Rigidbody rb;

    [Header("Variables")]
    public float speed;
    private float _movementMagnitud;
    private bool _onFloor;
    private int _layerFloor = 8;

    [Header("GameObjects")]
    public GameObject rotationPoint;

    public bool can = true;

    private bool _shop = false;
    private bool _timer = false;

    [SerializeField] private Animator _animator; 


    private ShopBeheivor _shopBeheivor;
    private Controllers _controlls;
    [SerializeField] private Shooting _shoting;

    private void Start()
    {
        EventManager.Subscribe("ManaUpgrade", ManaUpgrade);
        EventManager.Subscribe("LifeUpgrade", LifeUpgrade);
        EventManager.Subscribe("LifeRecharge", LifeRecharge);
        EventManager.Subscribe("PlayerDamage", PlayerDamage);
        ComparativeStats();

        _controlls = new Controllers();
        _controlls._move = this;
        _controlls._shoot = _shoting;

        _ani = new AnimatorController();
        _ani._animator = _animator;

        _shoting._animator = _ani;
    }

    void Update()
    {
        _controlls.OnUpdate();
        Move();
        ManaRecharge();
    }

    private void Move()
    {
        _movementMagnitud = _playerInput.magnitude;

        _playerInput = rotationPoint.transform.right * _horizontalMove + rotationPoint.transform.forward * _verticalMove * Mathf.Abs(_verticalMove);

        _playerInput.y = 0;

        if (_movementMagnitud > 1)
        {
            rb.MovePosition(transform.position + _playerInput.normalized * (speed * Time.deltaTime));
            _movementMagnitud = 1;
        }
        else
            rb.MovePosition(transform.position + _playerInput * (speed * Time.deltaTime));
    }

    public void Axies(float h, float v)
    {
        _horizontalMove = h;
        _verticalMove = v;
        _ani.MovementAnimation(_horizontalMove, _verticalMove);
    }

    public void Run()
    {
        speed *= 2;
    }

    public void Walk()
    {
        speed *= 0.5f;
    }

    public void Jump()
    {
        if (_onFloor)
        {
            rb.AddForce(new Vector3(0, 300, 0));
            _ani.Animation("Jump", true);
            _onFloor = false;
        }
    }

    public void Interactive()
    {
        if(_timer)
            EventManager.Trigger("StartTimer");

        if (_shop)
            _shopBeheivor.Buy();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == _layerFloor)
        {
            _ani.Animation("Jump", false);
            _onFloor = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Button")
        {
            _timer = true;
        }

        if (other.gameObject.tag == "Shop")
        {
            _shop = true;
            _shopBeheivor = other.gameObject.GetComponent<ShopBeheivor>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Button")
        {
            _timer = false;
        }

        if (other.gameObject.tag == "Shop")
        {
            _shop = false;
            _shopBeheivor = null;
        }
    }
}
