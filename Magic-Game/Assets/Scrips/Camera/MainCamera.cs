using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public GameObject player;
    private Vector3 _vectorD;

    void Update()
    {
        _vectorD = player.transform.position - transform.position;
        transform.forward = _vectorD;
    }
}
