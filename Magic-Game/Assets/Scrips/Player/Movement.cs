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
    [SerializeField]
    private Animator _ani;

    [SerializeField]
    private Shooting _shooting;

    private void Start()
    {
        EventManager.Subscribe("ManaUpgrade", ManaUpgrade);
        EventManager.Subscribe("LifeUpgrade", LifeUpgrade);
        EventManager.Subscribe("LifeRecharge", LifeRecharge);
        EventManager.Subscribe("PlayerDamage", PlayerDamage);
        ComparativeStats();
        ManaRecharge += EmptyVoid;
    }

    void Update()
    {
        Walk();
        Run();
        Jump();
        ManaRecharge();

        if (Input.GetButtonDown("Fire1"))
        {
            _shooting.canShoot();
        }
    }

    private void Walk()
    {
        _horizontalMove = Input.GetAxisRaw("Horizontal");
        _verticalMove = Input.GetAxisRaw("Vertical");

        _ani.SetFloat("HorizontalInput", _horizontalMove);
        _ani.SetFloat("VerticalInput", _verticalMove);

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
            _animatorController.Animation("Jump", false);
            _onFloor = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown("e"))
        {
            if (other.gameObject.tag == "Button")
            {
                EventManager.Trigger("StartTimer");
            }

            if (other.gameObject.tag == "Shop")
            {
                other.gameObject.GetComponent<ShopBeheivor>().Buy();
            }
        }
    }
}
