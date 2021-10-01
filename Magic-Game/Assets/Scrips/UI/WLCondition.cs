using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WLCondition : MonoBehaviour
{
    public void LoseScreen()
    {
        SceneManager.LoadScene("LoseScene");
    }

    public void WinScreen()
    {
        SceneManager.LoadScene("WinScene");
    }
}
