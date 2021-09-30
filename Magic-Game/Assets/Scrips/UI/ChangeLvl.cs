using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLvl : MonoBehaviour
{
    [SerializeField]
    string _lvl;
    [SerializeField]
    string _anotherScene;
    public void ChangeLVL()
    {
        SceneManager.LoadScene(_lvl);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void AnotherScene()
    {
        SceneManager.LoadScene(_anotherScene);
    }
}
