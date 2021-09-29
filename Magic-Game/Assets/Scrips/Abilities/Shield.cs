using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
   
    [SerializeField]
    float _timer;
    [SerializeField]
    float _defaultTimer;
    
    public bool activeShield;

    private void Start()
    {
        _timer = _defaultTimer;
        activeShield = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Enemy>())
        {
            if (activeShield == true)
            {
                other.GetComponent<Enemy>().CantMakeDamage();
            }
            else
            {
                other.GetComponent<Enemy>().CanMakeDamage();

            }
        }
    }

    private void Update()
    {
        if (activeShield == true)
        {
            _timer -= Time.deltaTime;
            if (_timer <= 0)
            {
                activeShield = false;
                StartCoroutine(Timer());
            }
        }
        else
        {
            return;
        }
     
       
    }

    IEnumerator Timer()
    {
        _timer = _defaultTimer;
        
        yield return new WaitForSeconds(0.1f);
        this.gameObject.SetActive(false);
        
    }
}
