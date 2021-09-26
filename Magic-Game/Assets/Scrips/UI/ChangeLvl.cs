using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLvl : MonoBehaviour
{
    [SerializeField]
    string _lvl;
    public void ChangeLVL()
    {
        SceneManager.LoadScene(_lvl);
    }
}
