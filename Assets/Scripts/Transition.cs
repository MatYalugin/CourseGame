using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public int sceneTo;
    public bool cutScene;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(sceneTo);
            if(cutScene == true)
            {
                PlayerPrefs.SetFloat("currentHealth", 100);
            }
        }
    }
}
