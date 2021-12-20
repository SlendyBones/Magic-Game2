using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Abilities : MonoBehaviour
{
    [Header("Ability One")]
    [SerializeField] private int _blackHoleMana;

    [Header("Ability Two")]
    [SerializeField] private int _explosionMana;

    [Header("Ability Three")]
    [SerializeField] private int _shieldMana;

    [Header("Spawn Ability")]
    public Transform spawnAbilities;
    public GameObject player;
    public GameObject jarAbility;
    public GameObject bombAbility;
    public GameObject shield;


    [Header("Pj")]
    [SerializeField] private Movement pj;

    private AnimatorController _ani;
    [SerializeField] private Animator _animator;

    [SerializeField] private UIManager _uiManager;

    private void Start()
    {
        _ani = new AnimatorController();
        _ani._animator = _animator;
    }

    public void Ability1()
    {
        Debug.Log("antes if");
        if (_uiManager._isCD[0] == false)
        {
            Debug.Log("Despues if");
            if (pj.UseMana(_blackHoleMana))
            {
                Debug.Log("uso mana");
                _uiManager.SetOff(0);

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
                _uiManager.SetOff(1);

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
                pj.ShieldOn();
                _uiManager.SetOff(2);
                Shield _sh = shield.GetComponent<Shield>();
                _sh.activeShield = true;
                shield.SetActive(true);
                _animator.SetTrigger("Shield");
            }
        }
    }
}
