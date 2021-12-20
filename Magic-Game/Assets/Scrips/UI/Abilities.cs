using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Abilities : MonoBehaviour
{
    [Header("Ability One")]
    private int _blackHoleMana;

    [Header("Ability Two")]
    private int _explosionMana;

    [Header("Ability Three")]
    private int _shieldMana;

    [Header("Spawn Ability")]
    public Transform spawnAbilities;
    public GameObject player;
    public GameObject jarAbility;
    public GameObject bombAbility;
    public GameObject shield;


    [Header("Pj")]
    [SerializeField] private Movement pj;
    [SerializeField] private AnimatorController _animator;

    [SerializeField] private StatsManager _stats;
    [SerializeField] private UIManager _uiManager;

    public void Ability1()
    {
        if (_uiManager._isCD[0] == false)
        {
            if (pj.UseMana(_blackHoleMana))
            {
                _uiManager._isCD[0] = true;

                GameObject jar =Instantiate(jarAbility, spawnAbilities.position, player.transform.rotation);
                _animator.SetTrigger("Atack");
            }
        }
    }
    public void Ability2()
    {
        if (_uiManager._isCD[1] == false)
        {
            if (pj.UseMana(_explosionMana))
            {
                _uiManager._isCD[1] = true;

                GameObject bomb = Instantiate(bombAbility, spawnAbilities.position, player.transform.rotation);
                _animator.SetTrigger("Atack");
            }
        }
    }

    public void Ability3()
    {
        if (_uiManager._isCD[2] == false)
        {
            if (pj.UseMana(_shieldMana))
            {
                _stats.ShieldOn();
                _uiManager._isCD[2] = true;
                Shield _sh = shield.GetComponent<Shield>();
                _sh.activeShield = true;
                shield.SetActive(true);
                _animator.SetTrigger("Shield");
            }
        }
    }
}
