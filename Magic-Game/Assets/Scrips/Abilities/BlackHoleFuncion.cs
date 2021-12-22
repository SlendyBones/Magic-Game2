using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class BlackHoleFuncion : MonoBehaviour
{
    [SerializeField] 
    float _gravityPull = .78f;
    public static float m_GravityRadius = 1f;
    [SerializeField] private LayerMask enemy;
    void Awake()
    {
        m_GravityRadius = GetComponent<SphereCollider>().radius;
    }
    
    void OnTriggerStay(Collider other)
    {
        if (other.attachedRigidbody)
        {
           
            if(other.gameObject.layer == enemy)
            {
                float gravityIntensity = Vector3.Distance(transform.position, other.transform.position) / m_GravityRadius;
                other.attachedRigidbody.AddForce((transform.position - other.transform.position) * gravityIntensity * other.attachedRigidbody.mass * _gravityPull * Time.deltaTime);
                Debug.DrawRay(other.transform.position, transform.position - other.transform.position);
            }
        }
           
    }

     void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {

            if (other.gameObject.layer == enemy)
            {
                float gravityIntensity = Vector3.Distance(transform.position, other.transform.position) / m_GravityRadius;
                other.attachedRigidbody.AddForce((transform.position - other.transform.position) * gravityIntensity * other.attachedRigidbody.mass * _gravityPull * Time.deltaTime);
                Debug.DrawRay(other.transform.position, transform.position - other.transform.position);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.attachedRigidbody)
        {

            if (other.gameObject.layer == enemy)
            {
                float gravityIntensity = Vector3.Distance(transform.position, other.transform.position) / m_GravityRadius;
                other.attachedRigidbody.AddForce((transform.position - other.transform.position) * gravityIntensity * other.attachedRigidbody.mass * _gravityPull * Time.deltaTime);
                Debug.DrawRay(other.transform.position, transform.position - other.transform.position);
            }
        }
    }
}

