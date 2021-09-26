using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class BlackHoleFuncion : MonoBehaviour
{
    [SerializeField] public float GRAVITY_PULL = .78f;
    public static float m_GravityRadius = 1f;
    void Awake()
    {
        m_GravityRadius = GetComponent<SphereCollider>().radius;
    }
    
    void OnTriggerStay(Collider other)
    {
        if (other.attachedRigidbody)
        {
            if (other.gameObject.GetComponent<FalsaVida>())
            {
                Debug.Log("Este es el player");
            }
            else
            {
                float gravityIntensity = Vector3.Distance(transform.position, other.transform.position) / m_GravityRadius;
                other.attachedRigidbody.AddForce((transform.position - other.transform.position) * gravityIntensity * other.attachedRigidbody.mass * GRAVITY_PULL * Time.deltaTime);
                Debug.DrawRay(other.transform.position, transform.position - other.transform.position);
            }
        }
           
    }

}

