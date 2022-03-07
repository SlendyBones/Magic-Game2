using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public void Open()
    {
        transform.Rotate(new Vector3(0, -90, 0));
    }
}
