using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
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

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _horizontalMove = Input.GetAxisRaw("Horizontal");
        _verticalMove = Input.GetAxisRaw("Vertical");

        _movementMagnitud = _playerInput.magnitude;

        _playerInput = transform.right * _horizontalMove + transform.forward * _verticalMove * Mathf.Abs(_verticalMove);

        _playerInput.y = 0;

        if (_movementMagnitud > 1)
        {
            rb.MovePosition(transform.position + _playerInput.normalized* (speed* Time.deltaTime));
            _movementMagnitud = 1;
        }
        else
            rb.MovePosition(transform.position + _playerInput * (speed * Time.deltaTime));

        RunJump();

    }

    private void RunJump()
    {
        //Correr
        if (Input.GetButtonDown("Sprint"))
        {
            speed = 10;
        } 
        else if (Input.GetButtonUp("Sprint"))
            speed = 5;

        //Saltar
        if (Input.GetButtonDown("Jump") && _onFloor)
        {
            rb.AddForce(new Vector3(0, 300, 0));
            _onFloor = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == _layerFloor)
        {
            Debug.Log("piso");
            _onFloor = true;
        }
    }
}
