using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField]
    float _timer;
    [SerializeField]
    float _defaultTimer = 0;
    
    public bool activeShield;

    [SerializeField] Movement stats;

    private void Start()
    {
        _timer = _defaultTimer;
        activeShield = true;
    }

    private void OnEnable()
    {
        stats.ShieldOn();
    }

    private void Update()
    {
        if (activeShield == true)
        {
            _timer -= Time.deltaTime;
            if (_timer <= 0)
            {
                stats.ShieldOff();
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
        gameObject.SetActive(false);
    }
}
