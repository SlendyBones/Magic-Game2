using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float rotationSpeedX;
    public float rotationSpeedY;
    private float _mouseX;
    private float _mouseY;
    private Vector3 _rotationVector;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        _mouseX = Input.GetAxis("Mouse X");
        _mouseY = Input.GetAxis("Mouse Y");

        //_rotationVector = new Vector3(_mouseY * rotationSpeedY, _mouseX * rotationSpeedX, 0);

        _rotationVector.y += _mouseX * rotationSpeedX;
        _rotationVector.x += _mouseY * rotationSpeedY;

        _rotationVector.x = Mathf.Clamp(_mouseY, -400, 400);
        //_rotationVector = transform.up * _mouseX * rotationSpeedX + transform.right * _mouseY * rotationSpeedY;

        //transform.Rotate(_rotationVector * Time.deltaTime);
        transform.rotation = Quaternion.Euler(_rotationVector);

        //Mathf.Clamp(_rotationVector.z, -40, 80);
    }
}
