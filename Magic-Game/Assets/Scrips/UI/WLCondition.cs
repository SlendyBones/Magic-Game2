using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WLCondition : MonoBehaviour
{

    public void LoseScreen()
    {
        EventManager.ResetEventDictionary();
        SceneManager.LoadScene("LoseScene");
    }

    public void WinScreen()
    {
        EventManager.ResetEventDictionary();
        SceneManager.LoadScene("WinScene");
    }

    public void Shop()
    {
        EventManager.ResetEventDictionary();
        SceneManager.LoadScene("LobbyShop");
    }
}
