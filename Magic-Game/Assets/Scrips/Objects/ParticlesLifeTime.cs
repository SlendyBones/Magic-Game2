using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesLifeTime : MonoBehaviour
{
    [SerializeField]
    private float _deadTime;
    void Update()
    {
        Destroy(this.gameObject, _deadTime);

    }
}
