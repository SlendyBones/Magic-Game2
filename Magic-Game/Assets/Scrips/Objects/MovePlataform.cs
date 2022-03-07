using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlataform : MonoBehaviour
{
    [SerializeField] private bool _left;
    [SerializeField] private float _speed;
   
    void Update()
    {
        if (_left)
        {
            transform.position += transform.forward * -1 * _speed * Time.deltaTime;
        }
        else
        {
            transform.position += transform.forward * _speed * Time.deltaTime;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Left")
        {
            _left = true;
        }
        else if(other.gameObject.tag == "Right")
        {
            _left = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(null);
        }
    }

}
