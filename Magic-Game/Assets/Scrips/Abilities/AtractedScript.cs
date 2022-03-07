using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtractedScript : MonoBehaviour
{
    private bool _isAtracting;
    private Vector3 _blackHolePosition;
    [SerializeField] private float _atractForce;
    [SerializeField] private Rigidbody rb;
    [SerializeField] float _speed;

    private GameObject _thisBlackHole;

    void Update()
    {
        if(_thisBlackHole == null)
        {
            _isAtracting = false;
        }
        
        if (_isAtracting)
        {
            transform.position += (_blackHolePosition - transform.position) * _speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "AOE")
        {
            Debug.Log("Enter");
            _isAtracting = true;
            _blackHolePosition = other.transform.position;
            _thisBlackHole = other.gameObject;
        }
    }

}
