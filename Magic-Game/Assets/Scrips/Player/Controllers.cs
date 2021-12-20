using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controllers
{
    public Movement _move;
    public Shooting _shoot;
    public Abilities abilities;
    private float _hAxie, _vAxie;
    [SerializeField] private KeyCode _blackHole, _explosion, _shield;

    public void OnUpdate()
    {
        Axies();
        Shift();
        Space();
        Interactive();
        RightClick();
        Abilities();
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

    private void Abilities()
    {
        if(Input.GetKey(_blackHole))
        {
            abilities.Ability1();
        }

        if (Input.GetKey(_explosion))
        {
            abilities.Ability2();
        }

        if (Input.GetKey(_shield))
        {
            abilities.Ability3();
        }
    }
}
