using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartTimer : WLCondition
{
    [SerializeField]
    private Text _timerText;
    
    private float _timer;
    private int _iTimer;
    private bool _timerIsOn;

    public bool start = false;

    void Update()
    {
        if (start)
            StartCount();

        TimerColor();

        if (_timerIsOn)
        {
            _timer -= 1 * Time.deltaTime;
            _iTimer = (int)_timer;
            _timerText.text = _iTimer.ToString();
            if (_timer <= 0)
            {
                _timer = 0;
                _timerText.text = _iTimer.ToString();
                _timerIsOn = false;
                LoseScreen();
            }
        }
    }

    public void TimerColor()
    {
        if (_timer > 15)
            _timerText.color = Color.black;
        else
            _timerText.color = Color.red;
    }

    public void StartCount()
    {
        start = false;
        _timerText.gameObject.SetActive(true);
        _timer = 60;
        _timerText.text = _iTimer.ToString();
        _timerIsOn = true;
    }

    public bool _timerIsOnClass
    {
        get{ return _timerIsOn; }
    }

}
