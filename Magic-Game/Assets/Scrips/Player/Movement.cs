using System.Collections;
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

    private void Awake()
    {
        _animatorController = new AnimatorController();
        _animatorController.OnStart();
    }

    void Update()
    {
        Walk();
        Run();
        Jump();
        ManaRecharge();

    }

    private void Walk()
    {
        _horizontalMove = Input.GetAxisRaw("Horizontal");
        _verticalMove = Input.GetAxisRaw("Vertical");

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

        if (_playerInput != Vector3.zero)
            _animatorController.Animation("Walk", true);
        else
            _animatorController.Animation("Walk", false);
    }

    private void Run()
    {
        //Correr
        if (Input.GetButtonDown("Sprint"))
        {
            speed *= 2;
        }
        else if (Input.GetButtonUp("Sprint"))
            speed /= 2;
    }

    private void Jump()
    {
        //Saltar
        if (Input.GetButtonDown("Jump") && _onFloor)
        {
            rb.AddForce(new Vector3(0, 300, 0));
            _animatorController.Animation("Jump", true);
            _onFloor = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == _layerFloor)
        {
            Debug.Log("piso");
            _animatorController.Animation("Jump", false);
            _onFloor = true;
        }
    }
}
