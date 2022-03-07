using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public GameObject player;
    private Vector3 _vectorD;
    private float _maxDistance;
    [SerializeField] private LayerMask _wall;

    private void Start()
    {
        _maxDistance = Vector3.Distance(player.transform.position, transform.position);
    }

    void Update()
    {
        //La camara siempre mira al personaje aunque rote
        _vectorD = player.transform.position - transform.position;
        transform.forward = _vectorD;

        if(Physics.Raycast(transform.position, transform.forward * -1, 2, _wall))
        {
            Debug.Log("ola");
            transform.position += transform.forward * Time.deltaTime * 10;
        }
        else if(Vector3.Distance(player.transform.position, transform.position) < _maxDistance)
        {
            transform.position += transform.forward * -1 * Time.deltaTime;
        }
    }
}
