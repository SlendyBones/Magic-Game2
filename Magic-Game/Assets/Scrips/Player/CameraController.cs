using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera mainCamera;
    private float _mouseX;
    private float _mouseY;
    private Vector3 _inputCamera;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _inputCamera = new Vector3 (_mouseX, _mouseY, _inputCamera.z);

    }
}
