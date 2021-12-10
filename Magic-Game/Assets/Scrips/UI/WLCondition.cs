using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WLCondition : MonoBehaviour
{

    private void Start()
    {
        EventManager.Subscribe("LoseScene", LoseScreen);
        EventManager.Subscribe("WinScene", WinScreen);
    }
    public void LoseScreen(params object[] parameter)
    {
        EventManager.ResetEventDictionary();
        SceneManager.LoadScene("LoseScene");
    }

    public void WinScreen(params object[] parameter)
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
