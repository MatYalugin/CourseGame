using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject controls;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            controls.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.U))
        {
            controls.SetActive(false);
        }
    }
}
