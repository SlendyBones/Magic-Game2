using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Potal : MonoBehaviour
{
    [SerializeField]
    private string _lvlName;
    [SerializeField]
    private string _lvlName2;
    [SerializeField]
    private string _lvlName3;
    private void OnTriggerEnter(Collider other)
    {
        EventManager.ResetEventDictionary();

        if (LevelManager.instances.numberLVL == 0)
            SceneManager.LoadScene(_lvlName);
        else if (LevelManager.instances.numberLVL == 1)
            SceneManager.LoadScene(_lvlName2);
        else if (LevelManager.instances.numberLVL == 2)
            SceneManager.LoadScene(_lvlName3);
    }
}
