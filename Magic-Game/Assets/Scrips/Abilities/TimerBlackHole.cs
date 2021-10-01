using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerBlackHole : MonoBehaviour
{
    [SerializeField]
    float _timer;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timer  -= Time.deltaTime;
        if (_timer <= 0)
            Destroy(this.gameObject);
    }
   
}
