using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Potal : MonoBehaviour
{
    [SerializeField]
    private string _lvlName;
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(_lvlName);
    }
}
