using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLvl : MonoBehaviour
{
    [SerializeField]
    string _lvl;
    [SerializeField]
    string _scene;
    public void ChangeLVL()
    {
        SceneManager.LoadScene(_lvl);
    }
    public void AnotherScene()
    {
        SceneManager.LoadScene(_scene);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    
}
