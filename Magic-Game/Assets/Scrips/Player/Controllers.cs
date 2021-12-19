using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controllers
{
    public Movement _move;
    public Shooting _shoot;
    private float _hAxie, _vAxie;

    public void OnUpdate()
    {
        Axies();
        Shift();
        Space();
        Interactive();
        RightClick();
    }

    private void Axies()
    {
        _hAxie = Input.GetAxis("Horizontal");
        _vAxie = Input.GetAxis("Vertical");
        _move.Axies(_hAxie, _vAxie);
    }

    private void Shift()
    {
        if (Input.GetButtonDown("Sprint"))
        {
            _move.Run();
        }

        if (Input.GetButtonUp("Sprint"))
        {
            _move.Walk();
        }
    }

    private void Space()
    {
        if (Input.GetButtonDown("Jump"))
        {
            _move.Jump();
        }
    }

    private void Interactive()
    {
        if (Input.GetKeyDown("e"))
        {
            _move.Interactive();
        }
    }

    private void RightClick()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _shoot.canShoot();
        }
    }
}
