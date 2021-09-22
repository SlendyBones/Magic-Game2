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
        //Fijar el cursor al centro e invesible
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //Inputs de Mouse
        _mouseX += Input.GetAxis("Mouse X") * Time.deltaTime * rotationSpeedX;
        _mouseY += Input.GetAxis("Mouse Y") * Time.deltaTime * rotationSpeedY;

        //Clamp Manual, el clamp de unity falla al volver
        if (_mouseY > 60)
            _mouseY = 60;
        else if (_mouseY < -20)
            _mouseY = -20;

        //Pasando rotacion en X
        _rotationVector.y = _mouseX;

        //Aplicando rotacion
        transform.localRotation = Quaternion.Euler(_rotationVector);
    }
}
