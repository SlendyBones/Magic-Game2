using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeDontDestroy : MonoBehaviour
{
    void Start()
    {
        LevelManager.instances.LevelFakeAwake();
        CoinBeheivor.cb.CoinFakeAwake();
    }
}
