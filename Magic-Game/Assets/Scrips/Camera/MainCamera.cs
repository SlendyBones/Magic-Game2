using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public GameObject player;
    private Vector3 _vectorD;
    private float _maxDistance;
    private float _actualDistance;
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

        _actualDistance = Vector3.Distance(player.transform.position, transform.position);

        if (Physics.Raycast(transform.position, transform.forward * -1, 2, _wall) && _actualDistance > 0.5f)
        {
            transform.position += transform.forward * Time.deltaTime * 10;
        }
        else if(_actualDistance < _maxDistance)
        {
            transform.position += transform.forward * -1 * Time.deltaTime;
        }
    }
}
